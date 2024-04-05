using kerberos;
using System.Text;

string message = "ABCDEFG";
string key = "12345678";

string encryptedMessage = Encoding.ASCII.GetString(
	Des.Encrypt(
		Encoding.ASCII.GetBytes(message), 
		Encoding.ASCII.GetBytes(key)
		)
	);
string decryptedMessage = Encoding.ASCII.GetString(
	Des.Decrypt(
		Encoding.ASCII.GetBytes(encryptedMessage),
		Encoding.ASCII.GetBytes(key)
		)
	);
Console.WriteLine($"initial message: {message}");
Console.WriteLine($"encrypted message: {encryptedMessage}");
Console.WriteLine($"decrypted message: {decryptedMessage}");


//string message1 = "ABCDEFG";
//string key1 = "HBGYOJIN";

//string encryptedMessage1 = Encoding.ASCII.GetString(
//	Des.Encrypt(
//		Encoding.ASCII.GetBytes(message1),
//		Encoding.ASCII.GetBytes(key1)
//		)
//	);
//string decryptedMessage1 = Encoding.ASCII.GetString(
//	Des.Decrypt(
//		Encoding.ASCII.GetBytes(encryptedMessage1),
//		Encoding.ASCII.GetBytes(key1)
//		)
//	);
//Console.WriteLine($"initial message: {message1}");
//Console.WriteLine($"encrypted message: {encryptedMessage1}");
//Console.WriteLine($"decrypted message: {decryptedMessage1}");
