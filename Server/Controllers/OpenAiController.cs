using Azure;
using Azure.AI.OpenAI;
using Madeni.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Madeni.Server.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAiController : ControllerBase
    {
        // GET: api/<OpenAiController>
        [HttpPost]
        public async Task<MadeniTransacation> Post(string message, string apiKey)
        {
            var result = await ProcessMessage(message, apiKey);
            return result;
        }

        // Create method to process the message
        private async Task<MadeniTransacation> ProcessMessage(string message, string apiKey)
        {           
            var responses = new List<string>();

            OpenAIClient client = new OpenAIClient(apiKey);

            Response<Completions> response = await client.GetCompletionsAsync(
                "text-davinci-003", // assumes a matching model deployment or model name
                "Get the key elements and return as a json object with the properties: TransactionType (indicates if money was sent or received), TransactionDate, Amount, Source from this message:" + message);

            foreach (Choice choice in response.Value.Choices)
            {
                Console.WriteLine(choice.Text);
                responses.Add(choice.Text);
            }

            var ans = response.Value.Choices[0].Text;
            //Reeplace special characters in response
            ans = ans.Replace("\n", "");

            var transaction = JsonConvert.DeserializeObject<MadeniTransacation>(ans);

            return transaction;
        }
    }
}
