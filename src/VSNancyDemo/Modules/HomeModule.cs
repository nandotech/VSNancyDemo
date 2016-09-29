using Nancy;
using Nancy.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace VSNancyDemo.Modules
{
    public class HomeModule : NancyModule
    {

        public HomeModule()
        {
            //Before += (ctx) => 
            //{
            //    Thread.Sleep(5000);

            //    return null;
            //};

            Get("/", args => "Hello From Home Module.");
            Get("/test", args => "Test Message.");
            Get("/os", x =>
            {
                return System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            });
        }
    }
}
