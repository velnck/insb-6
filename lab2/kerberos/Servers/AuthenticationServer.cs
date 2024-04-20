using Kerberos.Tickets;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Kerberos.Servers
{
	internal class AuthenticationServer
	{
		private Socket _serverSocket = new Socket(AddressFamily.InterNetwork, 
			SocketType.Stream, ProtocolType.Tcp);
		private List<Socket> _clientSockets = new List<Socket>();
		private byte[] _buffer = new byte[1024];

		public void SetupServer()
		{
			_serverSocket.Bind(new IPEndPoint(IPAddress.Any, Config.AuthenticationServerPort));
			_serverSocket.Listen(3);
			_serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
		}
		
		private void AcceptCallback(IAsyncResult result)
		{
			Socket socket = _serverSocket.EndAccept(result);
			_clientSockets.Add(socket);
			socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, 
				new AsyncCallback(ReceiveCallback), socket);
			_serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), socket);
		}

		private void ReceiveCallback(IAsyncResult result)
		{
			Socket socket = (Socket)result.AsyncState;
			if (socket == null)
			{
				return;
			}
			int recieved = socket.EndReceive(result);
			byte[] dataBuffer = new byte[recieved];
			Array.Copy(_buffer, dataBuffer, recieved);
			string clientId = Encoding.ASCII.GetString(dataBuffer);

			byte[] responseToClient;
			if (Keys.ASClientsKeys.ContainsKey(clientId))
			{
                Console.WriteLine("[STEP 1] Client " + clientId + " found in database.");
                TicketGrantingTicket tgt = new(clientId, new TimeSpan(0, 10, 0), Keys.AS_TGSKey);
				byte[] encryptedTgt = Des.Encrypt(tgt.ToString(), Keys.AS_TGSKey);
                Console.WriteLine("[STEP 2] TGT: " + tgt);
                responseToClient = Des.Encrypt(
					Convert.ToHexString(encryptedTgt) + "|" + Keys.TGSClientsKeys[clientId], 
					Keys.ASClientsKeys[clientId]);
			}
			else
			{
				responseToClient = Encoding.ASCII.GetBytes("[STEP 1] Authentication for client " 
					+ clientId + " failed.");
			}
			socket.BeginSend(responseToClient, 0, responseToClient.Length, SocketFlags.None,
				new AsyncCallback(SendCallback), socket);
			socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None,
				new AsyncCallback(ReceiveCallback), null);
		}

		private void SendCallback(IAsyncResult result)
		{
			Socket socket  = (Socket)result.AsyncState;
			socket.EndSend(result);
		}

		private string GenerateKey()
		{
			Random rand = new Random();
			string key = "";

			for (int i = 0; i < 8; i++)
			{
				int nextChar = rand.Next((int)'a', (int)'z' + 1);
				key = key + (char)nextChar;
			}
			return key;
		}
	}
}
