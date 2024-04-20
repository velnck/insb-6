namespace Kerberos.Tickets
{
	internal class TicketGrantingService
	{
		public string ClientId;
		public DateTime Timestamp;
		public TimeSpan ValidityPeriod;
		public string ServiceServerKey;

		public TicketGrantingService(string clientId, TimeSpan validityPeriod, string serviceServerKey)
		{
			ClientId = clientId;
			Timestamp = DateTime.Now;
			ValidityPeriod = validityPeriod;
			ServiceServerKey = serviceServerKey;
		}

		private TicketGrantingService(string clientId, DateTime timestamp, 
			TimeSpan validityPeriod, string serviceServerKey)
		{
			ClientId = clientId;
			Timestamp = timestamp;
			ValidityPeriod = validityPeriod;
			ServiceServerKey = serviceServerKey;
		}

		public override string ToString()
		{
			string str = ClientId + "|" +
				Timestamp.ToString() + "|" +
				ValidityPeriod.ToString() + "|" +
				ServiceServerKey;
			Console.WriteLine("TGS: " + str);
			return str;
		}

		public static TicketGrantingService FromString(string data)
		{
			string[] words = data.Split('|');
			return new TicketGrantingService(words[0], DateTime.Parse(words[1]),
				TimeSpan.Parse(words[2]), words[3]);
		}
	}
}
