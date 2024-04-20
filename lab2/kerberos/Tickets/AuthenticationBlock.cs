namespace Kerberos.Tickets
{
	internal class AuthenticationBlock
	{
		public string ClientId;
		public DateTime Timestamp;

		public AuthenticationBlock(string clientId)
		{
			ClientId = clientId;
			Timestamp = DateTime.Now;
		}

		private AuthenticationBlock(string clientId, DateTime timestamp)
		{
			ClientId = clientId;
			Timestamp = timestamp;
		}

		public override string ToString()
		{
			string str = ClientId + "|" + Timestamp.ToString();
            return str;
		}

		public static AuthenticationBlock FromString(string data)
		{
			string[] words = data.Split('|');
			return new AuthenticationBlock(words[0], DateTime.Parse(words[1]));
		}
	}
}
