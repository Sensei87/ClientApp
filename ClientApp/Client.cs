using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace ClientApp
{
    public static class Client
    {
        // This client method receives data from the server
        public static void Receiver(string? multicastAddress, int port)
        {
            ConcurrentBag<double> data = new ConcurrentBag<double>();
            CancellationTokenSource cts = new CancellationTokenSource();
            using (UdpClient udpClient = new UdpClient(port))
            {
                udpClient.JoinMulticastGroup(IPAddress.Parse(multicastAddress));

                Task.Run(() =>
                {
                    while (!cts.Token.IsCancellationRequested)
                    {
                        IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                        byte[] receivedBytes = udpClient.Receive(ref remoteEndPoint);
                        string receivedData = Encoding.ASCII.GetString(receivedBytes);
                        if (double.TryParse(receivedData, out double result))
                        {
                            data.Add(result);
                        }
                    }
                }, cts.Token);

                while (!cts.Token.IsCancellationRequested)
                {
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        var fixedCollection = data.ToArray();
                        double average = fixedCollection.Average();
                        double median = fixedCollection.OrderBy(x => x).Skip(fixedCollection.Length / 2).First();
                        double mode = fixedCollection.GroupBy(x => x).OrderByDescending(g => g.Count()).First().Key;
                        double standardDeviation = Math.Sqrt(fixedCollection.Average(x => Math.Pow(x - average, 2)));

                        Console.WriteLine($"Average: {average}");
                        Console.WriteLine($"Median: {median}");
                        Console.WriteLine($"Mode: {mode}");
                        Console.WriteLine($"Standard deviation: {standardDeviation}");
                    }
                    else if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        cts.Cancel();
                    }
                }
            }
        }



    }
}
