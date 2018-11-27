using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace HelloWorldClient
{
    public class HelloWorldClient
    {
        static void  Main(string[]  args)
        {
            //var greetingServiceAddress = new Uri("http://localhost:51047/api/greeting");
            //var client = new HttpClient();
            //var result = client.GetAsync(greetingServiceAddress).Result;
            //var greeting = result.Content.ReadAsStringAsync().Result;

            //Console.WriteLine(greeting);
            var config = new HttpSelfHostConfiguration(new Uri("http://localhost:51047/"));
            config.Routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "api/{controller}/{id}", defaults: new { id = RouteParameter.Optional });

            var host = new HttpSelfHostServer(config);
            host.OpenAsync().Wait();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            host.CloseAsync().Wait();
          
        }
    }
}
