using System.Net.Sockets;
using System.Net;
using System.Text;
using TCPAttacks;

namespace TPCAttacks.Attacks
{
    internal class ResetAttack
    {
        private int _clientPort;
        private IPEndPoint _serverEndPoint;
        public ResetAttack(int clientPort, IPEndPoint serverEndPoint)
        {
            _clientPort = clientPort;
            _serverEndPoint = serverEndPoint;
        }

        public async Task Attack(CancellationToken token)
        {
            await Task.Delay(500);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                clientSocket.Connect(_serverEndPoint);

                SendPacket(clientSocket, Packet.GetEmptyPacket(4, _clientPort, _serverEndPoint.Port, 0, 0, syn: true));

                Packet packet = ReceivePacket(clientSocket);

                if (!packet.SYN || !packet.ACK)
                {
                    throw new Exception("Invalid first packet from server.");
                }

				SendPacket(clientSocket, Packet.GetEmptyPacket(4, _clientPort, _serverEndPoint.Port, 1, 1, ack: true));

                for (int i = 5; i < 100; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }
                    Thread.Sleep(100);
                    try
                    {
                        SendPacket(clientSocket, Packet.GetEmptyPacket(4, _clientPort, _serverEndPoint.Port,
                            1, 1, rst: true, ack: true));
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Attacker failed to connect to server: {ex.Message}");
            }
            finally
            {
                if (clientSocket.Connected)
                    clientSocket.Close();
            }
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
