using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace BitcoinPrice
{
    public static class BitcoinPrice
    {
        [FunctionName("BitcoinPrice")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            HttpClient client = new HttpClient();
            
            var response = await client.GetAsync("https://api.coinbase.com/v2/prices/BTC-USD/sell");
            var responseBody = await response.Content.ReadAsStreamAsync();

            return new OkObjectResult(responseBody);
        }
    }
}
