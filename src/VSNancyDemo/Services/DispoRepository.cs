using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using VSNancyDemo.Data;

namespace VSNancyDemo.Services
{
    public class DispoRepository : IDispoRepository
    {
        //private IDbConnection dbConn;
        private string dbConnectionString;
        public DispoRepository(IConfiguration _dbConn)
        {
            dbConnectionString = _dbConn.GetConnectionString("DefaultConnection"); ;
        }

        internal IDbConnection dbConn
        {
            get
            {
                return new SqlConnection(dbConnectionString);
            }
        }
        public IEnumerable<Disposition> GetAll()
        {
            using (IDbConnection active = dbConn)
            {
                active.Open();
                return active.Query<Disposition>("SELECT * FROM Dispositions");
            }
        }
        public Disposition Get(int id)
        {
            using (IDbConnection active = dbConn)
            {
                active.Open();
                return active.QueryFirst<Disposition>("SELECT * FROM Dispositions WHERE id = @Id", new { Id = id });
            }
        }
        public void Add(Disposition dispo)
        {
            string sQuery = "INSERT INTO dbo.Dispositions (Name, Description, Timestamp)"
                + " VALUES(@Name, @Description, @Timestamp)";
            using (IDbConnection active = dbConn)
            {
                active.Open();
                active.Execute(sQuery, dispo);
            }
        }
        public void Remove(int id)
        {
            using (IDbConnection active = dbConn)
            {
                active.Open();
                active.Execute("DELETE FROM Dispositions WHERE Id = @Id", new { Id = id });
            }
        }

    }
}
