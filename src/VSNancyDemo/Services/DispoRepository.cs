using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VSNancyDemo.Data;

namespace VSNancyDemo.Services
{
    public class DispoRepository
    {
        private IDbConnection dbConn;

        public DispoRepository(IDbConnectionProvider _dbConn)
        {
            dbConn = _dbConn.Connection;
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
