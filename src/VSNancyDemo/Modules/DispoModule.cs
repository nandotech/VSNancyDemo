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

        public DispoModule(IDbConnectionProvider _dbConn)
            : base("/dispo")
        {
            var _repo = new DispoRepository(_dbConn);

            Get("/", args =>
            {
                return _repo.GetAll();
            });

            Get("Id={id}", args =>
            {
                return _repo.Get(args.id);
            });

            Post("/Name={name}&Desc={description}", args =>
            {
                var posted = new Disposition();
                posted.Name = args.Name;
                posted.Description = args.Description;
                posted.Timestamp = DateTime.Now;
                _repo.Add(posted);

                return posted;
            });

            Delete("Id={id}", args =>
            {
                _repo.Remove(args.id);
                return $"{args.id} Removed";
            });
        }

    }
}
