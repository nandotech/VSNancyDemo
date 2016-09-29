using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSNancyDemo.Modules
{
    public class HomeModule : NancyModule
    {

        public HomeModule()
        {

            Get("/", args => "Hello From Home Module.");
            Get("/test", args => "Test Message.");
        }
    }
}
