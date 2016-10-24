using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSNancyDemo.Modules
{
    public class SaleModule : NancyModule
    {
        public SaleModule() : base("/sale")
        {

            Post("{info}&{info2}", args =>
                {
                    //TODO: Insert sale info from CRM
                    return HttpStatusCode.OK;
                });

        }
    }
}

