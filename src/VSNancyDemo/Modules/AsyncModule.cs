using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace VSNancyDemo.Modules
{
    public class AsyncModule : NancyModule
    {
        public AsyncModule()
        {
            Before += async (ctx, ct) =>
            {
                this.AddToLog("Before Hook Delay\n");
                await Task.Delay(5000);

                return null;
            };

            After += async (ctx, ct) =>
            {
                this.AddToLog("After Hook Delay\n");
                await Task.Delay(5000);
                this.AddToLog("After Hook Complete\n");

                ctx.Response = this.GetLog();
            };

            Get("/async", async (args, ct) =>
            {
                this.AddToLog("Delay 1\n");
                await Task.Delay(1000);

                this.AddToLog("Delay 2\n");
                await Task.Delay(1000);

                this.AddToLog("Executing async http client\n");
                var client = new HttpClient();
                var res = await client.GetAsync("http://nancyfx.org");
                var content = await res.Content.ReadAsStringAsync();

                this.AddToLog("Response: " + content.Split('\n')[0] + "\n");

                return (Response)this.GetLog();
            });
            
        }

        private void AddToLog(string logLine)
        {
            if (!this.Context.Items.ContainsKey("Log"))
            {
                this.Context.Items["Log"] = string.Empty;
            }

            this.Context.Items["Log"] = (string)this.Context.Items["Log"] + DateTime.Now + " : " + logLine;
        }

        private string GetLog()
        {
            if (!this.Context.Items.ContainsKey("Log"))
            {
                this.Context.Items["Log"] = string.Empty;
            }

            return (string)this.Context.Items["Log"];
        }
    }
}
