using kerberos;
using System.Text;

string message = "ABCDEFG";
string key = "12345678";

string encryptedMessage = Encoding.ASCII.GetString(
	Des.Encrypt(Encoding.ASCII.GetBytes(message), Encoding.ASCII.GetBytes(key)));
Console.WriteLine(encryptedMessage);
