using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSNancyDemo.Services
{
    public class GreeterService : IGreeterService
    {
        private string _greeting;

        public GreeterService(IConfiguration config)
        {
            _greeting = config["Greeting"];
        }

        public string GetGreeting()
        {
            return _greeting;
        }
    }
}
