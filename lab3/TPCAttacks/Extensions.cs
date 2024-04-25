using System.Text;
using System.Text.Json;


namespace TCPAttacks
{
	internal static class Extensions
	{
		public static byte[] GetBytes(this Packet packet)
		{
			return JsonSerializer.Serialize(packet).GetBytes();
		}

		public static byte[] GetBytes(this string str)
		{
			return Encoding.UTF32.GetBytes(str);
		}

		public static string GetString(this byte[] bytes, int offset)
		{
			return Encoding.UTF32.GetString(bytes, 0, offset);
		}

		public static string GetString(this byte[] bytes)
		{
			return Encoding.UTF32.GetString(bytes);
		}

		public static Packet GetTcpPacket(this byte[] data)
		{
			try
			{
				string str = data.GetString();
				return JsonSerializer.Deserialize<Packet>(data.GetString())!;
			}
			catch
			{
				throw;
			}
		}
	}
}
