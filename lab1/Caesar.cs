using System.Text;

class Caesar
{
	public static void Encrypt(int key, string filename)
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
					foreach (char ch in line)
					{
						char encryptedCh;
						if ('A' <= ch && ch <= 'Z')

						{
							encryptedCh = (char)('A' + (ch + key) % 'A');
						}
						else
						{
							encryptedCh = ch;
						}
						encryptedMessage.Append(encryptedCh);
					}
					streamWriter.WriteLine(encryptedMessage.ToString());
				}
			}
		}
		File.Delete(tmpFilename);
	}


	public static void Decrypt(int key, string filename)
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
					foreach (char ch in line)
					{
						char decryptedCh;
						if ('A' <= ch && ch <= 'Z')

						{
							decryptedCh = (char)('A' + (ch - key + 'A') % 'A');
						}
						else
						{
							decryptedCh = ch;
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