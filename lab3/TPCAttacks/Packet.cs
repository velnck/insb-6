namespace TCPAttacks
{
	internal class Packet
	{
		public int SourcePort { get; set; }
		public int DestinationPort { get; set; }
		public uint SequenceNumber { get; set; }
		public uint AcknowledgmentNumber { get; set; }
		public bool ACK { get; set; }
		public bool FIN { get; set; }
		public bool RST { get; set; }
		public bool SYN { get; set; }
		public ushort WindowSize { get; set; }
		public byte[] Data { get; set; } = [];

		public override string ToString()
		{
			return $"\tSource: {SourcePort}.\n" +
				$"\tDestination: {DestinationPort}.\n" +
				$"\tSN: {SequenceNumber}.\n" +
				$"\tACK Number: {AcknowledgmentNumber}.\n" +
				$"\tWindow: {WindowSize}.\n" +
				$"\tData: {String.Join(' ', Data)}.\n" +
				$"\tFlags: ACK = {ACK}, FIN = {FIN}, RST = {RST}, SYN = {SYN}.";
		}

		public static Packet GetEmptyPacket(ushort windowsSize, int sourcePort, int destinationPort,
												uint seqNum, uint ackNum,
												bool ack = false, bool syn = false, bool rst = false, bool fin = false)
		{
			return new Packet()
			{
				SourcePort = sourcePort,
				DestinationPort = destinationPort,
				SequenceNumber = seqNum,
				AcknowledgmentNumber = ackNum,
				WindowSize = windowsSize,
				ACK = ack,
				RST = rst,
				SYN = syn,
				FIN = fin
			};
		}

		public static IEnumerable<Packet> GetPackets(byte[] data, ushort windowsSize, 
			int sourcePort, int destinationPort, uint seqNum, uint ackNum)
		{
			List<Packet> packets = new();
			int id = 0;

			do
			{
				packets.Add(new Packet()
				{
					SourcePort = sourcePort,
					DestinationPort = destinationPort,
					SequenceNumber = seqNum,
					AcknowledgmentNumber = ackNum,
					WindowSize = windowsSize,
					Data = data[id..(id + windowsSize < data.Length ? id + windowsSize : data.Length)],
				});

				seqNum += windowsSize;
			}
			while ((id += windowsSize) < data.Length);

			return packets;
		}
	}
}
