// See https://aka.ms/new-console-template for more information
using WebSocketSharp;
using WebSocketSharp.Server;
using ErrorEventArgs = WebSocketSharp.ErrorEventArgs;

Console.WriteLine("Hello, World!");

Console.Write($"Please enter address: ");
var server = new WebSocketServer("ws://" + Console.ReadLine());

server.AddWebSocketService<ServerBehaviour>("/server");
server.AddWebSocketService<PlayerBehaviour>("/player");

server.Start();
Console.ReadKey (true);
server.Stop();

public class ServerBehaviour: WebSocketBehavior
{
    protected override void OnOpen()
    {
        Console.WriteLine($"Server is open!");
        base.OnOpen();
    }

    protected override void OnMessage(MessageEventArgs e)
    {
        Console.WriteLine(e);
        base.OnMessage(e);
    }

    protected override void OnClose(CloseEventArgs e)
    {
        base.OnClose(e);
    }

    protected override void OnError(ErrorEventArgs e)
    {
        base.OnError(e);
    }
}

public class PlayerBehaviour : WebSocketBehavior
{
    protected override void OnOpen()
    {
        base.OnOpen();
    }

    protected override void OnMessage(MessageEventArgs e)
    {
        base.OnMessage(e);
    }

    protected override void OnClose(CloseEventArgs e)
    {
        base.OnClose(e);
    }

    protected override void OnError(ErrorEventArgs e)
    {
        base.OnError(e);
    }
}

public class ServerBaseRequest
{
    public ServerMessageType MessageType;
}

public enum ServerMessageType
{
    Connect,
    Disconnect
}