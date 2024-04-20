using Kerberos.Tickets;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Kerberos.Servers
{
	internal class TicketGrantingServer
	{
		private Socket _serverSocket = new Socket(AddressFamily.InterNetwork,
			SocketType.Stream, ProtocolType.Tcp);
		private List<Socket> _clientSockets = new List<Socket>();
		private byte[] _buffer = new byte[1024];

		public void SetupServer()
		{
			_serverSocket.Bind(new IPEndPoint(IPAddress.Any, Config.TicketGrantingServerPort));
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
			string message = Encoding.ASCII.GetString(dataBuffer);
			TicketGrantingTicket tgt = TicketGrantingTicket.FromString(
				Des.Decrypt(Convert.FromHexString(message.Split('|')[0]), Keys.AS_TGSKey)
				);
			string clientId = tgt.ClientId;
			AuthenticationBlock authenticationBlock = AuthenticationBlock.FromString(
				Des.Decrypt(Convert.FromHexString(message.Split('|')[1]),
				Keys.TGSClientsKeys[clientId])
				);
			Console.WriteLine("[STEP 3] Ticket Granting Server received client id \"" + clientId 
				+ "\", TGT: \"" + tgt + "\", authentication block: \"" + authenticationBlock + "\".");

			if (authenticationBlock.ClientId != tgt.ClientId) 
			{
                Console.WriteLine("[STEP 3] Client id in TGT and authentucation block are NOT the same.");
				return;
			}
			else
			{
                Console.WriteLine("[STEP 3] Client id in TGT and authentucation block are the same.");
            }
			if (tgt.Timestamp + tgt.ValidityPeriod < authenticationBlock.Timestamp)
			{
				Console.WriteLine("[STEP 3] TGT expired.");
				return;
			}
			else
			{
				Console.WriteLine("[STEP 3] TGT is valid.");
			}

			byte[] messageToClient = Des.Encrypt((Convert.ToHexString(Des.Encrypt(
				new TicketGrantingService(clientId, new TimeSpan(0, 10, 0), Keys.C_SSKey).ToString(), 
				Keys.TGS_SSKey))
				+ "|" + Keys.C_SSKey),
				Keys.TGSClientsKeys[tgt.ClientId]);

            socket.BeginSend(messageToClient, 0, messageToClient.Length, SocketFlags.None,
				new AsyncCallback(SendCallback), socket);
			socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None,
				new AsyncCallback(ReceiveCallback), null);
		}

		private void SendCallback(IAsyncResult result)
		{
			Socket socket = (Socket)result.AsyncState;
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
