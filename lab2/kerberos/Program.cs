using Kerberos;
using Kerberos.Tickets;
using Kerberos.Servers;
using System.Text;

AuthenticationServer authenticationServer = new();
TicketGrantingServer ticketGrantingServer = new();
ServiceServer serviceServer = new();

authenticationServer.SetupServer();
ticketGrantingServer.SetupServer();
serviceServer.SetupServer();

Client client = new Client("user1", "abcdefgh");
client.Authenticate();

Console.ReadLine();