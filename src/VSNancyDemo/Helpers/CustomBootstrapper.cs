using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nancy.TinyIoc;
using Nancy.Bootstrapper;
using VSNancyDemo.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Nancy.Diagnostics;
using VSNancyDemo.Data;
using System.Data;

namespace VSNancyDemo.Helpers
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        public IConfigurationRoot Configuration;
        public CustomBootstrapper()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(RootPathProvider.GetRootPath())
                            .AddJsonFile("appsettings.json")
                            .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            //base.ConfigureApplicationContainer(container);
            container.Register<IGreeterService, GreeterService>();
            container.Register<IConfiguration>(Configuration);
            //container.Register<IDbConnectionProvider, DbConnectionProvider>();
            container.Register<IDispoRepository, DispoRepository>();
        }

    }
}
