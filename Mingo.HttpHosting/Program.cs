using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace Mingo.HttpHosting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hostPort = int.Parse(ConfigurationManager.AppSettings["hostPort"]);
            var localHostOnly = bool.Parse(ConfigurationManager.AppSettings["localHostOnly"]);
            IPAddress hostIp = IPAddress.Any;
            if (localHostOnly) { hostIp = IPAddress.Loopback; }
            Console.WriteLine($"Run Web Hosting on http://{hostIp}:{hostPort} ...");

            var config = new HttpSelfHostConfiguration($"http://{hostIp}:{hostPort}");

            config.Routes.MapHttpRoute("Default", "{*url}"
                , defaults: new { controller = "Index", action = "Handle" });

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Press Enter to exit.");
                Console.ReadLine();
            }
        }
    }
}
