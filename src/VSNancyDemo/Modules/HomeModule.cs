using Nancy;
using Nancy.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VSNancyDemo.Services;

namespace VSNancyDemo.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule(IGreeterService greeter)
        {
            //! Build module to accept Vici posts, display stats

            Get("/", args =>
            {
                
                return View["index.html", greeter.GetGreeting()];
            });

            Get("/test", args => greeter.GetGreeting());

            Get("/os", x =>
            {
                return System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            });
        }
    }
}
