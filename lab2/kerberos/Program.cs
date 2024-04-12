using kerberos;


string message = "ABCDEFGH";
string key = "HBGYOJIN";

Console.WriteLine($"Initial message: {message}");

var encryptedMessage = Des.Encrypt(message, key);
Console.WriteLine($"Encrypted message: {Convert.ToHexString(encryptedMessage)}");

var decryptedMessage = Des.Decrypt(encryptedMessage, key);
Console.WriteLine($"Decrypted message: {decryptedMessage}");