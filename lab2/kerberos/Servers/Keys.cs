namespace Kerberos.Servers
{
	internal class Keys
	{
		public static string AS_TGSKey = "astgskey";
		public static string TGS_SSKey = "tgssskey";
		public static string C_SSKey = "cltgskey";

		public static Dictionary<string, string> ASClientsKeys = new Dictionary<string, string>()
		{
			{ "user1", "abcdefgh"}
		};
		public static Dictionary<string, string> SSClientsKeys = new Dictionary<string, string>()
		{
			{ "user1", "cltgskey"}
		};

		public static Dictionary<string, string> TGSClientsKeys = new Dictionary<string, string>()
		{
			{ "user1", "tgskeyyy"}
		};
	}
}
