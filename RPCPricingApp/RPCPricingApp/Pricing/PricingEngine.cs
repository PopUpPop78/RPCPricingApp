using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RPCPricingApp.Data;
using RPCPricingApp.Models;

namespace RPCPricingApp.Pricing
{


    public interface IPricingEngine
    {
        void Calculate(PricingDocument Document);
    }
    public class BasicPricingEngine : IPricingEngine
    {
        public void Calculate(PricingDocument Document)
        {
            var rndTime = ThreadSafeRandom.Next(1, 5) * 1000; // Random time between 1 and 5 seconds
            var rndResults = ThreadSafeRandom.Next(5, 20); // Random number of results
            var count = 0;

            Enumerable.Range(1, rndResults).ToList().ForEach(x =>
            {
                Document.Response.Add(new PricingResponse()
                {
                    ReferenceDate = DateTime.Today.AddDays(count),
                    BenchmarkOne = ThreadSafeRandom.NextDouble(),
                    BenchmarkTwo = ThreadSafeRandom.NextDouble()
                });
                count++;
            });
            System.Threading.Thread.Sleep(rndTime);
        }
    }
    class ThreadSafeRandom
    {
        private static Random random = new Random();

        public static double NextDouble()
        {
            lock (random)
            {
                return random.NextDouble();
            }
        }
        public static int Next(int Start, int Max)
        {
            lock (random)
            {
                return random.Next(Start, Max);
            }
        }
    }

}