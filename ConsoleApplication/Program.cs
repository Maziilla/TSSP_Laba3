using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace WcfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceMetadataBehavior behavior = new ServiceMetadataBehavior
            {
                HttpGetEnabled = true,
                MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 }
            };
            var host = new ServiceHost(typeof(WcfServiceLibrary.DuckService), new Uri("http://localhost:13044"));
            host.Description.Behaviors.Add(behavior);
            host.AddServiceEndpoint(typeof(WcfServiceLibrary.IDuckService), new BasicHttpBinding(), "basic");
            //host.AddServiceEndpoint(typeof(WcfServiceLibrary.IDuckService), new WSHttpBinding(), "ws");
            //host.AddServiceEndpoint(typeof(WcfServiceLibrary.IDuckService), new NetTcpBinding(), "net.tcp://localhost:13054/our/service/tcp");
            //host.AddServiceEndpoint(typeof(WcfServiceLibrary.IDuckService), new NetNamedPipeBinding(), "net.pipe://localhost/our/service/pipe");
            host.Open();
            Console.WriteLine("Server is running");
            Console.ReadLine();
        }
    }

}
