using Kerberos.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kerberos.Servers
{
	internal class ServiceServer
	{

		private Socket _serverSocket = new Socket(AddressFamily.InterNetwork,
			SocketType.Stream, ProtocolType.Tcp);
		private List<Socket> _clientSockets = new List<Socket>();
		private byte[] _buffer = new byte[1024];

		public void SetupServer()
		{
			_serverSocket.Bind(new IPEndPoint(IPAddress.Any, Config.ServiceServerPort));
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
			TicketGrantingService tgs = TicketGrantingService.FromString(
				Des.Decrypt(Convert.FromHexString(message.Split('|')[0]), Keys.TGS_SSKey)
				);
			string clientId = tgs.ClientId;
			AuthenticationBlock authenticationBlock = AuthenticationBlock.FromString(
				Des.Decrypt(Convert.FromHexString(message.Split('|')[1]),
				Keys.SSClientsKeys[clientId])
				);
			Console.WriteLine("[STEP 5] Service Server received client id \"" + clientId
				+ "\", TGS: \"" + tgs + "\", authentication block: \"" + authenticationBlock + "\".");

			if (authenticationBlock.ClientId != tgs.ClientId)
			{
				Console.WriteLine("[STEP 5] Client id in TGS " +
					"and authentucation block are NOT the same.");
				return;
			}
			else
			{
				Console.WriteLine("[STEP 5] Client id in TGS and authentucation block are the same.");
			}
			if (tgs.Timestamp + tgs.ValidityPeriod < authenticationBlock.Timestamp)
			{
				Console.WriteLine("[STEP 5] TGS expired.");
				return;
			}
			else
			{
                Console.WriteLine("[STEP 5] TGS is valid.");
            }

			byte[] messageToClient = Des.Encrypt(
				(authenticationBlock.Timestamp + new TimeSpan(0, 0, 1)).ToString(),
				Keys.SSClientsKeys[clientId]);

            Console.WriteLine("[STEP 6] Confirm Service server authenticity.");
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
	}
}
