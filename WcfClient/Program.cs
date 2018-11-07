using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfClient.ServiceReference;

namespace WcfClient
{
    class Program
    {
        private static long Benchmark(string endpointConfigurationName)
        {
            IDuckService serviceClient = new DuckServiceClient(endpointConfigurationName);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (var i = 0; i < 2000; i++)
            {
                serviceClient.GetDuck(null);
            }

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        private static void Main(string[] args)
        {
            int? proxyPort = 18000; // 18000;
            if (!proxyPort.HasValue)
            {
                var configurationNames = new List<string>
                {
                    "BasicHttpBinding_IDuckService", "NetNamedPipeBinding_IDuckService",
                    "NetTcpBinding_IDuckService", "WSHttpBinding_IDuckService"
                };
                foreach (var configurationName in configurationNames)
                {
                    Console.WriteLine($"{configurationName}: {Benchmark(configurationName)}");
                }

                Console.WriteLine("\nBenchmarking has been completed");
            }
            else
            {
                // mitmweb --web-port 28000 --listen-port 18000 --mode reverse:http://localhost:13044
                var kk =new DuckServiceClient("BasicHttpBinding_IDuckService",
                    $"http://localhost:{proxyPort.Value}/our/service/basic").GetDuck(null);
                kk = new DuckServiceClient("BasicHttpBinding_IDuckService",
                    $"http://localhost:{proxyPort.Value}/our/service/basic").GetDuck(kk);
                kk = new DuckServiceClient("BasicHttpBinding_IDuckService",
                    $"http://localhost:{proxyPort.Value}/our/service/basic").Separate(kk);
                Console.WriteLine("Querying through proxy has been completed");
            }

            Console.ReadLine();
        }
    }
}
