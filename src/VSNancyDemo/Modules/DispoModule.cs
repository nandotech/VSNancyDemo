using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSNancyDemo.Data;
using VSNancyDemo.Services;

namespace VSNancyDemo.Modules
{
    public class DispoModule : NancyModule
    {

        public DispoModule(IDataService<Disposition> data) : base("/dispo")
        {
            Get("/", args =>
            {
                return HttpStatusCode.OK;
            });

            Post("/{info}", args =>
            {
                //! Insert args info into database as requested

                return HttpStatusCode.OK;
            });

        }

    }
}
