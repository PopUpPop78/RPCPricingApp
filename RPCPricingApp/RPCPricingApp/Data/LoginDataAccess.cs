using Dapper;
using RPCPricingApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RPCPricingApp.Data
{

    public class LoginDataAccess : DataAccess<Login>
    {
        public LoginDataAccess(string ConnectionString) : base(ConnectionString)
        {

        }
        public override Login LoadData(Login Data)
        {
            using (var db = new SqlConnection(this.ConnectionString))
            {
                var results = db.Query<Login>(Data.ConvertLoadSql());
                if (results.Count() <= 0)
                    throw new Exception("There is no login for this user");
                return results.First();
            }
        }

        public override void StoreData(Login Data)
        {
            using (var db = new SqlConnection(this.ConnectionString))
            {
                db.Query(Data.ConvertStoreSql().First());
            }
        }
    }
}