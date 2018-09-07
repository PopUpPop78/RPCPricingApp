using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using RPCPricingAppCore.Data;
using RPCPricingAppCore.Models;

namespace RPCPricingAppCore.Data
{

    public interface ISql
    {
        IEnumerable<string> ConvertStoreSql();
        string ConvertLoadSql();
    }
    public abstract class DataAccess<T> where T : ISql
    {
        public DataAccess(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }
        protected readonly string ConnectionString;

        public abstract void StoreData(T Data);
        public abstract T LoadData(T Data);
    }
    public class PricingDataAccess : DataAccess<PricingDocument>
    {
        public PricingDataAccess(string ConnectionString) : base(ConnectionString)
        {
        }
        
        public string[] LoadExecutionTypes()
        {
            using (var db = new SqlConnection(this.ConnectionString))
            {
                return db.Query<string>("select ExecutionType from RPC.ExecutionTypes").ToArray();
            }
        }

        public override PricingDocument LoadData(PricingDocument Data)
        {
            using (var db = new SqlConnection(this.ConnectionString))
            {
                Data.Response.AddRange(db.Query<PricingResponse>(Data.ConvertLoadSql()));
            }
            return Data;
        }

        public override void StoreData(PricingDocument Data)
        {
            using (var db = new SqlConnection(this.ConnectionString))
            {
                foreach(var sql in Data.ConvertStoreSql())
                {
                    db.Query(sql);
                }
            }
        }
    }

}