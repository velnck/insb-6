using TCPAttacks;
using TPCAttacks.Attacks;


CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
CancellationToken token = cancelTokenSource.Token;

Client client = new Client(7002);
Server server = new Server(7001);
SynFloodAttack synFlood = new SynFloodAttack(client.Port, server.EndPoint);
ResetAttack reset = new ResetAttack(client.Port, server.EndPoint);

try
{
	Task.WaitAll([server.Listen(token),
		reset.Attack(token),
		//synFlood.Attack(),
		client.ConnectToServer(server.EndPoint, cancelTokenSource)]);

	Thread.Sleep(500);
}
catch (AggregateException ex) when (ex.InnerException is TaskCanceledException)
{ }
