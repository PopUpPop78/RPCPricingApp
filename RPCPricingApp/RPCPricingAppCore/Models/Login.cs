using RPCPricingAppCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPCPricingAppCore.Models
{
    public class Login : ISql
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string ConvertLoadSql()
        {
            return string.Format("select Password from RPC.LoginData where Username='{0}'", this.Username);
        }

        public IEnumerable<string> ConvertStoreSql()
        {
            return new List<string>() { string.Format("insert into RPC.LoginData (Username, Password) values ('{0}', '{1}')", this.Username, this.HashPassword()) };
        }

        public string HashPassword()
        {
            return Security.Security.ComputeSha256Hash(this.Password);
        }
    }
}