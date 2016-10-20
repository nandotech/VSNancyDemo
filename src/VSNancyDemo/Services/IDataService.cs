using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSNancyDemo.Services
{
    public interface IDataService<TDataType> 
        where TDataType : class
    {
        IEnumerable<TDataType> GetAll();
        TDataType GetById(int id);
        void Add(TDataType InsertData);
        void Remove(TDataType RemoveData);

    }
}
