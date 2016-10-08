using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSNancyDemo.Modules
{
    public class DispoModule : NancyModule
    {

        public DispoModule() : base("/dispo")
        {
            Post("/{info:string}", args =>
            {
                //! Insert args info into database as requested

                return HttpStatusCode.OK;
            });

        }

    }
}
