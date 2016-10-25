using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace VSNancyDemo.Services
{
    public interface IDbConnectionProvider
    {
        IDbConnection Connection { get; }
    }
}
