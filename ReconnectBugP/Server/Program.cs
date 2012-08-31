using System;
using System.Diagnostics;
using SignalR;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Listeners.Add(new ConsoleTraceListener());
            Debug.AutoFlush = true;

            const string url = "http://*:5000/";
            var server = new SignalR.Hosting.Self.Server(url);
            server.Configuration.DisconnectTimeout = TimeSpan.Zero;

            // Map connections
            server.MapConnection<MyConnection>("/echo")
                  .MapHubs();

            server.Start();

            Console.WriteLine("Server running on {0}", url);
            Console.ReadKey();
        }
    }

    internal class MyConnection : PersistentConnection
    {
        protected override System.Threading.Tasks.Task OnConnectedAsync(IRequest request, string connectionId)
        {
            // Put the breakpoint here.  Once it has been hit once, clear it and hit F5
            return base.OnConnectedAsync(request, connectionId);
        }
    }
}
