using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RPCPricingApp.Models;
using RPCPricingApp.Data;
using RPCPricingApp.Pricing;

namespace RPCPricingApp.Controllers
{
    public class BasicPricingController : ApiController
    {

        private PricingDataAccess dataAccess = new PricingDataAccess(System.Configuration.ConfigurationManager.ConnectionStrings["ExampleDB"].ConnectionString);
        private BasicPricingEngine engine = new BasicPricingEngine();
        
        public string[] Get()
        {
            return dataAccess.LoadExecutionTypes();
        }

        // POST: api/BasicPricing
        [ResponseType(typeof(PricingDocument))]
        public IHttpActionResult Post(PricingDocument value)
        {

            try
            {
                engine.Calculate(value);
                dataAccess.StoreData(value);
                return CreatedAtRoute("DefaultApi", new { id = value.PricingId.ToString() }, value);

            }
            catch (Exception ex)
            {
                // TODO: ...
                return InternalServerError();
            }
        }
    }



}
