using ApiPromotion.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace ApiPromotion.Repository
{
    public abstract class DataRepository
    {
        protected IData DataFactory { get;private set; }
        protected readonly DbContext Dbcontext;
        protected DataRepository(IData databaseFactory,IDbContext dbContext)
        {
            DataFactory = databaseFactory;
            Dbcontext = dbContext as DbContext;
        }
        protected SqlConnection GetSqlConnect( string database= "myprotion")
        {
            var sql = DataFactory.GetSqlconnect(database);
            if (sql.State != ConnectionState.Open) sql.Open();
            {
                return sql;
            }
        }

    }
}