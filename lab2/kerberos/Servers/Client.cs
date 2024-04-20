using Kerberos.Tickets;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Kerberos.Servers
{
	internal class Client
	{
		public string Id { private set; get; }
		private Socket _clientSocket = new Socket(AddressFamily.InterNetwork,
			SocketType.Stream, ProtocolType.Tcp);
		private string _key { set; get; }
		
		public Client(string id, string key)
		{
			Id = id;
			_key = key;
		}

		public void Authenticate()
		{
            while (!_clientSocket.Connected) 
			{
				try
				{
					_clientSocket.Connect(IPAddress.Loopback, Config.AuthenticationServerPort);
				}
				catch (SocketException) { }
			}

            // send client id to authentication server and get tgt and tgs key
            Console.WriteLine("[STEP 1] Sending client id to authentication server.");
            _clientSocket.Send(Encoding.ASCII.GetBytes(Id));
			byte[] receivedFromASBuffer = new byte[1024];
			int recievedFromASCount = _clientSocket.Receive(receivedFromASBuffer);
			byte[] dataFromAS = new byte[recievedFromASCount];
			Array.Copy(receivedFromASBuffer, dataFromAS, recievedFromASCount);
			string decryptedDataFromAS = Des.Decrypt(dataFromAS, _key);

			string tgtEncrypted = decryptedDataFromAS.Split('|')[0];
			string clientTGSKey = decryptedDataFromAS.Split('|')[1];
			Console.WriteLine("[STEP 2] Client received C-TGS key: " + clientTGSKey);

			_clientSocket.Shutdown(SocketShutdown.Both);
			_clientSocket.Dispose();


			// send tgt, athentication block and client id to ticket granting server
			// and recieve tgs and client - service server key
			_clientSocket = new Socket(AddressFamily.InterNetwork,
				SocketType.Stream, ProtocolType.Tcp);
			while (!_clientSocket.Connected)
			{
				try
				{
					_clientSocket.Connect(IPAddress.Loopback, Config.TicketGrantingServerPort);
				}
				catch (SocketException) { }
			}
            string messageToTGS = tgtEncrypted + "|" +
				Convert.ToHexString(
					Des.Encrypt(new AuthenticationBlock(Id).ToString(), clientTGSKey)
					) + "|" + Id;
            Console.WriteLine("[STEP 3] Client message to TGS: " + messageToTGS);
            _clientSocket.Send(Encoding.ASCII.GetBytes(messageToTGS));
			byte[] receivedFromTGSBuffer = new byte[1024];
			int recievedFromTGSCount = _clientSocket.Receive(receivedFromTGSBuffer);
			byte[] dataFromTGS = new byte[recievedFromTGSCount];
			Array.Copy(receivedFromTGSBuffer, dataFromTGS, recievedFromTGSCount);
			string decryptedDataFromTGS = Des.Decrypt(dataFromTGS, clientTGSKey);
			Console.WriteLine("[STEP 4] Client received from TGS: \"" 
				+ Convert.ToHexString(dataFromTGS) + "\".");


			_clientSocket.Shutdown(SocketShutdown.Both);
			_clientSocket.Dispose();

			// send tgs and auhtentication block to service server
			// and recieve service server authenticity confirmation
			string tgsEncrypted = decryptedDataFromTGS.Split('|')[0];
			string clientSSKey = decryptedDataFromTGS.Split('|')[1];
			_clientSocket = new Socket(AddressFamily.InterNetwork,
				SocketType.Stream, ProtocolType.Tcp);
			while (!_clientSocket.Connected)
			{
				try
				{
					_clientSocket.Connect(IPAddress.Loopback, Config.ServiceServerPort);
				}
				catch (SocketException) { }
			}
			AuthenticationBlock authBlockForSS = new AuthenticationBlock(Id);
			string messageToSS = tgsEncrypted + "|" +
				Convert.ToHexString(
					Des.Encrypt(authBlockForSS.ToString(), clientSSKey)
					);
			Console.WriteLine("[STEP 5] Client sending TGS and authentication block to SS: \"" 
				+ messageToSS + "\".");
			_clientSocket.Send(Encoding.ASCII.GetBytes(messageToSS));
			byte[] receivedFromSSBuffer = new byte[1024];
			int recievedFromSSCount = _clientSocket.Receive(receivedFromSSBuffer);
			byte[] dataFromSS = new byte[recievedFromSSCount];
			Array.Copy(receivedFromSSBuffer, dataFromSS, recievedFromSSCount);
			string decryptedDataFromSS = Des.Decrypt(dataFromSS, clientSSKey);
			
			// compare message received from SS to expected
            if ((authBlockForSS.Timestamp + new TimeSpan(0, 0, 1)).ToString().CompareTo(
				decryptedDataFromSS) == 0)
			{
                Console.WriteLine("[STEP 6] Service server proved authenticity.");
            }
			else
			{
				Console.WriteLine("[STEP 6] Service server did NOT prove authenticity.");
			}

			_clientSocket.Shutdown(SocketShutdown.Both);
			_clientSocket.Dispose();
		}
	}
}
