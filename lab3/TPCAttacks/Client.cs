using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPAttacks
{
	internal class Client
	{
		public int Port { get; set; }
		public IPEndPoint EndPoint { private set; get; }

		public Client(int port) 
		{ 
			Port = port;
			EndPoint = new (IPAddress.Loopback, port);
		}

		public Task ConnectToServer(IPEndPoint serverIP, CancellationTokenSource cancelTokenSource)
		{
			Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			clientSocket.Bind(EndPoint);

			try
			{
				clientSocket.Connect(serverIP);
				// three-way handshake
				// send syn packet
				SendPacket(clientSocket, Packet.GetEmptyPacket(4, Port, serverIP.Port, 0, 0, syn: true));
				// receive syn-ack
				Packet packet = ReceivePacket(clientSocket);
				if (!packet.SYN || !packet.ACK)
				{
					throw new Exception("Invalid SYN-ACK packet from server.");
				}
				// send ack
				SendPacket(clientSocket, Packet.GetEmptyPacket(4, Port, serverIP.Port, 1, 1, ack: true));

				StringBuilder serverMessage = new();
				packet = ReceivePacket(clientSocket);
				do
				{
					serverMessage.Append(packet.Data.GetString());
					Thread.Sleep(200);
					SendPacket(clientSocket, Packet.GetEmptyPacket(4, Port, serverIP.Port, 1, packet.SequenceNumber + (uint)packet.Data.Length, ack: true));
					packet = ReceivePacket(clientSocket);
				}
				while (!packet.FIN);

				Console.WriteLine($"Received message from server: \"{serverMessage}\".");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Client failed to connect to server: {ex.Message}");
			}
			finally
			{
				if (clientSocket.Connected)
					clientSocket.Close();
			}

			cancelTokenSource.Cancel();
			return Task.CompletedTask;
		}

		private void SendPacket(Socket socket, Packet packet)
		{
			byte[] responseBuffer = packet.GetBytes();
			socket.Send(responseBuffer);
		}

		public Packet ReceivePacket(Socket socket)
		{
			byte[] receivedBuffer = new byte[2048];
			int receivedCount = socket.Receive(receivedBuffer);
			byte[] data = new byte[receivedCount];
			Array.Copy(receivedBuffer, data, receivedCount);

			return data.ToArray().GetTcpPacket();
		}
	}
}
