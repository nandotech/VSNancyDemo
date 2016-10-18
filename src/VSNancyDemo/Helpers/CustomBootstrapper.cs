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

namespace VSNancyDemo.Helpers
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        protected override IRootPathProvider RootPathProvider
        {
            get { return new CustomRootPathProvider(); }
        }
        public IConfiguration Configuration;
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
            container.Register(Configuration);
        }
    }
}
