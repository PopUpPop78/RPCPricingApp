using Microsoft.AspNetCore.Mvc;
using RPCPricingAppCore.Data;
using RPCPricingAppCore.Models;
using System;

namespace RPCPricingAppCore.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        private LoginDataAccess dataAccess = new LoginDataAccess(ConfigurationManager.AppSetting["ConnectionString"]);



        // POST: api/Login
        [HttpPost]
        public bool Post([FromBody] Login Login)
        {
            try
            {
                if (dataAccess.LoadData(Login).Password == Login.HashPassword())
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                // Log error
                return false;
            }
        }

    }
}
