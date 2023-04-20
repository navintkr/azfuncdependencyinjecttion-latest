using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;

namespace httpclient3
{
    public class MyHttpTrigger
    {
        private readonly HttpClient _client;

        public MyHttpTrigger(IHttpClientFactory httpClientFactory)
        {
            this._client = httpClientFactory.CreateClient();
        }

        [FunctionName("MyHttpTrigger")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var response = await _client.GetAsync("https://microsoft.com");

            return new OkObjectResult("Response from function with injected dependencies.");
        }
    }
}