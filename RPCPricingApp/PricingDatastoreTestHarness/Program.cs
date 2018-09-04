using System;

using RPCPricingApp.Models;
using RPCPricingApp.Data;
using RPCPricingApp.Pricing;

namespace PricingDatastoreTestHarness
{
    class Program
    {
        static void Main(string[] args)
        {

            var store = new PricingDataAccess("data source=LAPTOP-F0TL3ONH;initial catalog=Examples;integrated security=True;MultipleActiveResultSets=True;");

            //var loginData = new Login() { Username = "MScott", Password = "Zurich2012" };
            var engine = new BasicPricingEngine();

            var doc = new PricingDocument();
            doc.Request = new PricingRequest();
            doc.Request.MainLimit = 2000000L;
            doc.Request.MainRetention = 1500000L;
            doc.Request.ExecutionType = "Simple";

            try
            {
                //store.StoreData(loginData);
                //loginData = store.LoadData(loginData);
                //Console.WriteLine(string.Format("Login for {0} stored successfully", loginData.Username));
                engine.Calculate(doc);
                Console.WriteLine("Priced successfully");
                store.StoreData(doc);
                Console.WriteLine("Stored successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
