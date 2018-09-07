using System;
using RPCPricingAppCore.Models;
using RPCPricingAppCore.Data;
using RPCPricingAppCore.Pricing;
using Microsoft.AspNetCore.Mvc;

namespace RPCPricingAppCore.Controllers
{
    [Route("api/[controller]")]
    public class BasicPricingController : Controller
    {

        private PricingDataAccess dataAccess = new PricingDataAccess(ConfigurationManager.AppSetting["ConnectionString"]);
        private BasicPricingEngine engine = new BasicPricingEngine();
        
        [HttpGet]
        public ActionResult<string[]> Get()
        {
            return dataAccess.LoadExecutionTypes();
        }

        // POST: api/BasicPricing
        [HttpPost]
        public PricingDocument Post([FromBody] PricingDocument value)
        {

            try
            {
                engine.Calculate(value);
                dataAccess.StoreData(value);
                return value;

            }
            catch (Exception ex)
            {
                // TODO: ...
                value.Error = ex.Message;
                return value;
            }
        }
    }



}
