using System.Text;

class Vigenere
{
	private static string GetFullKey(string key, string message)
	{
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < message.Length / key.Length + 1; i++) 
		{
			sb.Append(key);
		}
		sb.Length = message.Length;
		return sb.ToString();

	}

	public static void Encrypt(string key, string filename)
	{
		string tmpFilename = Path.Combine(Path.GetDirectoryName(filename),
			Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(filename)));
		File.Move(filename, tmpFilename);
		using (StreamReader streamReader = new StreamReader(tmpFilename))
		{
			using (StreamWriter streamWriter = new StreamWriter(filename))
			{
				string? line;
				while ((line = streamReader.ReadLine()) != null)
				{
					StringBuilder encryptedMessage = new StringBuilder();
					string fullKey = GetFullKey(key, line);
					for (int i = 0; i < line.Length; i++)
					{
						char encryptedCh;
						if ('A' <= line[i] && line[i] <= 'Z')

						{
							encryptedCh = (char)(line[i] - 'A' + (fullKey[i] - 'A'));
							if (encryptedCh > ('Z' - 'A'))
							{
								encryptedCh = (char)(encryptedCh % ('Z' - 'A' + 1));
							}
							encryptedCh += 'A';
						}
						else
						{
							encryptedCh = line[i];
						}
						encryptedMessage.Append(encryptedCh);
					}
					streamWriter.WriteLine(encryptedMessage.ToString());
				}
			}
		}
		File.Delete(tmpFilename);
	}

	public static void Decrypt(string key, string filename)
	{
		string tmpFilename = Path.Combine(Path.GetDirectoryName(filename),
			Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(filename)));
		File.Move(filename, tmpFilename);
		using (StreamReader streamReader = new StreamReader(tmpFilename))
		{
			using (StreamWriter streamWriter = new StreamWriter(filename))
			{
				string? line;
				while ((line = streamReader.ReadLine()) != null)
				{
					StringBuilder decryptedMessage = new StringBuilder();
					string fullKey = GetFullKey(key, line);
					for (int i = 0; i < line.Length; i++)
					{
						char decryptedCh;
						if ('A' <= line[i] && line[i] <= 'Z')

						{
							decryptedCh = (char)(line[i] + 'A' - (fullKey[i] - 'A'));
							if (decryptedCh > ('Z' - 'A'))
							{
								decryptedCh = (char)(decryptedCh % ('Z' - 'A' + 1));
							}
							decryptedCh += 'A';
						}
						else
						{
							decryptedCh = line[i];
						}
						decryptedMessage.Append(decryptedCh);
					}
					streamWriter.WriteLine(decryptedMessage.ToString());
				}
			}
		}
		File.Delete(tmpFilename);
	}
}