using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RPCPricingAppCore.Data;
using RPCPricingAppCore.Pricing;

namespace RPCPricingAppCore.Models
{
       
    public interface IPricing
    {
        Guid PricingId { get; }
    }
    public class PricingRequest
    {
        public double MainLimit { get; set; }
        public double MainRetention { get; set; }
        public string ExecutionType { get; set; }
    }
    public class PricingResponse
    {
        public DateTime ReferenceDate { get; set; }
        public double BenchmarkOne { get; set; }
        public double BenchmarkTwo { get; set; }
    }
    public class PricingDocument : IPricing, ISql
    {
        public PricingDocument()
        {
            this.pricingId = Guid.NewGuid();
        }

        public Guid PricingId { get { return this.pricingId; } }
        private readonly Guid pricingId;

        public PricingRequest Request { get; set; }
        public string Error { get; set; }

        public List<PricingResponse> Response { get { return this.response; } }
        private List<PricingResponse> response = new List<PricingResponse>();

        public string ConvertLoadSql()
        {
            var sql = "select ReferenceDate, BenchmarkOne, BenchmarkTwo from RPC.Pricing where Pricing = ";
            sql += string.Concat("'", this.PricingId, "'");
            return sql;
        }

        public IEnumerable<string> ConvertStoreSql()
        {
            var sqlList = new List<string>();
            foreach (var res in this.Response)
            {
                var sql = "insert into RPC.Pricing (ReferenceDate,MainLimit,MainRetention,ExecutionType,BenchmarkOne,BenchmarkTwo,PricingId,Updated) values (";
                sql += string.Concat("'", res.ReferenceDate.ToString("yyyy-MM-dd"), "',");
                sql += this.Request.MainLimit.ToString() + ",";
                sql += this.Request.MainRetention.ToString() + ",";
                sql += string.Concat("'", this.Request.ExecutionType, "',");
                sql += string.Concat(res.BenchmarkOne.ToString(), ",");
                sql += string.Concat(res.BenchmarkTwo.ToString(), ",");
                sql += string.Concat("'", this.PricingId, "',");
                sql += string.Concat("'", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), "'");
                sql += ")";
                sqlList.Add(sql);
            }
            return sqlList;
        }
    }




}