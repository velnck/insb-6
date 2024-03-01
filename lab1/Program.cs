while (true)
{
	Console.WriteLine("1. Encrypt Caesar.");
	Console.WriteLine("2. Decrypt Caesar.");
	Console.WriteLine("3. Encrypt Vigenere.");
	Console.WriteLine("4. Decrypt Vigenere.");
	Console.WriteLine("5. Exit.");

	int op;
	if (!int.TryParse(Console.ReadLine(), out op))
	{
		Console.WriteLine("Invalid input.");
		continue;
	}

	switch (op)
	{
		case 1:
			string filename = GetFilename();
			int keyInt = GetIntKey();
			Caesar.Encrypt(keyInt, filename);
			Console.WriteLine("Done.");
			break;
		case 2:
			filename = GetFilename();
			keyInt = GetIntKey();
			Caesar.Decrypt(keyInt, filename);
			Console.WriteLine("Done.");
			break;
		case 3:
			filename = GetFilename();
			string keyStr = GetStringKey();
			Vigenere.Encrypt(keyStr, filename);
			Console.WriteLine("Done.");
			break;
		case 4:
			filename = GetFilename();
			keyStr = GetStringKey();
			Console.WriteLine("Done.");
			Vigenere.Decrypt(keyStr, filename);
			break;
		case 5:
			return;
		default: 
			Console.WriteLine("Invalid input.");
			break;
	}
}


string GetFilename()
{
	while (true)
	{
		Console.WriteLine("Enter file name: ");
		string? filename = Console.ReadLine();
		if (File.Exists(filename))
		{
			return filename;
		}
		else
		{
			Console.WriteLine("Invalid file.");
		}
	}
}

int GetIntKey()
{
	while (true)
	{
		Console.Write("Enter key: ");
		int key;
		if (!int.TryParse(Console.ReadLine(), out key) || key < 0)
		{
			Console.WriteLine("Invalid key.");
		}
		else
		{
			return key;

		}
	}
}

string GetStringKey()
{
	while (true)
	{
		Console.Write("Enter key: ");
		string? key = Console.ReadLine();
		if (key is null || !key.All(Char.IsLetter))
		{
			Console.WriteLine("Invalid key.");
		}
		else
		{
			return key.ToUpper();
		}
	}
}