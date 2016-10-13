using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using VSNancyDemo.Data;

namespace VSNancyDemo.Services
{
    public class DataService<TDataType> : IDataService<TDataType>
        where TDataType : class
    {
        
            private string connectionString;
            public DataService()
            {
                connectionString = @"Server=localhost;Database=DapperDemo;Trusted_Connection=true;";
            }

            public IDbConnection Connection
            {
                get
                {
                    return new SqlConnection(connectionString);
                }
            }

            public void Add(TDataType prod)
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = "INSERT INTO Products (Name, Quantity, Price)"
                                    + " VALUES(@Name, @Quantity, @Price)";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, prod);
                }
            }

            public IEnumerable<TDataType> GetAll()
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    return dbConnection.Query<TDataType>("SELECT * FROM Products");
                }
            }

            public TDataType GetById(int id)
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = "SELECT * FROM Products"
                                   + " WHERE ProductId = @Id";
                    dbConnection.Open();
                    return dbConnection.Query<TDataType>(sQuery, new { Id = id }).FirstOrDefault();
                }
            }

            public void Remove(TDataType prod)
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = "DELETE FROM Products"
                                 + " WHERE ProductId = @Id";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, new { Id = prod });
                }
            }

            public void Update(TDataType prod)
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = "UPDATE Products SET Name = @Name,"
                                   + " Quantity = @Quantity, Price= @Price"
                                   + " WHERE ProductId = @ProductId";
                    dbConnection.Open();
                    dbConnection.Query(sQuery, prod);
                }
            }
        }
    }