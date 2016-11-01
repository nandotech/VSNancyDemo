using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSNancyDemo.Data;

namespace VSNancyDemo.Services
{
    public interface IDispoRepository
    {
        IEnumerable<Disposition> GetAll();
        Disposition Get(int id);
        void Add(Disposition dispo);
        void Remove(int id);


    }
}
