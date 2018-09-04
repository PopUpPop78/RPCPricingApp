using RPCPricingApp.Data;
using RPCPricingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RPCPricingApp.Controllers
{
    public class LoginController : ApiController
    {

        private LoginDataAccess dataAccess = new LoginDataAccess(System.Configuration.ConfigurationManager.ConnectionStrings["ExampleDB"].ConnectionString);



        // POST: api/Login
        public IHttpActionResult Post(Login Login)
        {
            try
            {
                if (dataAccess.LoadData(Login).Password == Login.HashPassword())
                    return CreatedAtRoute("DefaultApi", new { id = Login.Username }, true);
                else
                    return CreatedAtRoute("DefaultApi", new { id = Login.Username }, false);
            }
            catch (Exception ex)
            {
                // Log error
                return CreatedAtRoute("DefaultApi", new { id = Login.Username }, false);
            }
        }

    }
}
