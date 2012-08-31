using System;
using System.Threading;
using SignalR.Client;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(200);

            const string serverUrl = "http://localhost:5000/echo/";
            var connection = new Connection(serverUrl);

            connection.StateChanged += OnConnectionStateChanged;

            try
            {
                connection.Start().Wait();
            }
            catch(AggregateException ex)
            {
                throw ex.Flatten();
            }

            Console.ReadKey();
        }

        private static void OnConnectionStateChanged(StateChange obj)
        {
            Console.WriteLine(obj.NewState.ToString());
        }
    }
}
