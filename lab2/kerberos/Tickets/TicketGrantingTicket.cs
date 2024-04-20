namespace Kerberos.Tickets
{
	internal class TicketGrantingTicket
	{
		public string ClientId;
		public DateTime Timestamp;
		public TimeSpan ValidityPeriod;
		public string TicketGrantingServerKey;

		public TicketGrantingTicket(string clientId,
			TimeSpan validityPeriod, string ticketGrantingServerKey)
		{
			ClientId = clientId;
			Timestamp = DateTime.Now;
			ValidityPeriod = validityPeriod;
			TicketGrantingServerKey = ticketGrantingServerKey;
		}

		private TicketGrantingTicket(string clientId, DateTime timestamp,
			TimeSpan validityPeriod, string ticketGrantingServerKey)
		{
			ClientId = clientId;
			Timestamp = timestamp;
			ValidityPeriod = validityPeriod;
			TicketGrantingServerKey = ticketGrantingServerKey;
		}

		public override string ToString()
		{
			string str = ClientId + "|" +
				Timestamp.ToString() + "|" +
				ValidityPeriod.ToString() + "|" +
				TicketGrantingServerKey;
            return str;
		}

		public static TicketGrantingTicket FromString(string data)
		{
			string[] words = data.Split('|');
			return new TicketGrantingTicket(words[0], DateTime.Parse(words[1]), 
				TimeSpan.Parse(words[2]), words[3]);
		}
	}
}
