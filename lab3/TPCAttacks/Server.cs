using System.Net;
using System.Net.Sockets;
using System.Text;


namespace TCPAttacks
{
	internal class Server
	{
		private int _port { get; set; }
		public IPEndPoint EndPoint { private set; get; }

		public Server(int port)
		{
			_port = port;
			EndPoint = new (IPAddress.Loopback, port);
		}

		//Нужно для того, чтобы раазорвать соединение с конкретным клиентом
		//т.к. шарпы не позволят подключиться к серверу с аналогичными данными
		//ключ - порт
		private readonly Dictionary<int, Socket> _clients = [];

		public async Task Listen(CancellationToken token)
		{
			Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket.ReceiveTimeout = 1000;

			try
			{
				socket.Bind(EndPoint);
				socket.Listen(8);
				Console.WriteLine($"Server: {EndPoint}");

				// Бесконечный цикл для прослушивания новых подключений
				while (true)
				{
					if (token.IsCancellationRequested)
					{
						break;
					}
					Socket clientSocket = await socket.AcceptAsync(token);
					Console.WriteLine($"Connecting client: {clientSocket.RemoteEndPoint}");

					_clients.Add((clientSocket.RemoteEndPoint as IPEndPoint).Port, clientSocket);

					Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));
					clientThread.Start((clientSocket.RemoteEndPoint as IPEndPoint).Port);
				}
			}
			catch (OperationCanceledException)
			{ }
			catch (Exception ex)
			{
				Console.WriteLine($"Server error: {ex.Message}");
			}
		}

		private void HandleClient(object obj)
		{
			int port = (int)obj;
			try
			{
				// receive syn packet
				Packet packet = ReceivePacket(port);
				if (!packet.SYN || packet.Data.Length != 0)
				{
					throw new Exception($"Invalid SYN packet from {port}:\n" + packet.ToString());
				}


				uint ackNum = packet.SequenceNumber + 1;
				ushort windowSize = packet.WindowSize;
				uint seqNum = 0;
				// send syn-ack packet
				SendPacket(port, Packet.GetEmptyPacket(windowSize, _port, port, seqNum, ackNum, syn: true, ack: true));
				// receive ack
				packet = ReceivePacket(port);

				if (!packet.ACK || packet.Data.Length != 0)
				{
					throw new Exception($"Invalid ACK packet from {port}:\n" + packet.ToString());
				}
				Console.WriteLine("\nClient connected.\nServer starts sending message.\n");

				StringBuilder str = new();

				str.Append("Message from server.");

				List<Packet> packets = Packet.GetPackets(str.ToString().GetBytes(), 
					windowSize, _port, port, seqNum, ackNum).ToList();

				foreach (var pack in packets)
				{
					Thread.Sleep(10);
					SendPacket(port, pack);

					packet = ReceivePacket(port);

					if (!packet.ACK || packet.Data.Length != 0)
					{
						throw new Exception("Incorrect acknowledgement packet from client.");
					}
					if (packet.RST)
					{
						Console.WriteLine($"Connection crashed with client {packet.SourcePort}.\nReceived:\n{packet}");
						_clients[packet.SourcePort].Close();
						return;
					}

					if (pack.SequenceNumber + windowSize != packet.AcknowledgmentNumber)
					{
						throw new Exception("Wrong acknowledgment number");
					}
				}
				SendPacket(port, Packet.GetEmptyPacket(windowSize, _port, port, seqNum, ackNum, fin: true));
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Client processing error ({port}): {ex.Message}");
			}
			finally
			{
				if (_clients[port].Connected)
					_clients[port].Close();
			}
		}

		private void SendPacket(int port, Packet packet)
		{
			byte[] buffer = packet.GetBytes();
			_clients[port].Send(buffer);
		}

		public Packet ReceivePacket(int port)
		{
			byte[] receivedBuffer = new byte[2048];
			int receivedCount = _clients[port].Receive(receivedBuffer);
			byte[] data = new byte[receivedCount];
			Array.Copy(receivedBuffer, data, receivedCount);

			return data.ToArray().GetTcpPacket();
		}
	}
}
