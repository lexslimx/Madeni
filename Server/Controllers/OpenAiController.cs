using Azure;
using Azure.AI.OpenAI;
using Madeni.Server.Models;
using Madeni.Server.Services;
using Madeni.Shared.Dtos;
using Madeni.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Madeni.Server.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAiController : ControllerBase
    {
        private readonly IExpenseService expenseService;
        private readonly IIncomeService incomeService;
        public OpenAiController(IExpenseService expenseService, IIncomeService incomeService)
        {
            this.expenseService = expenseService;
            this.incomeService = incomeService;
        }
        // GET: api/<OpenAiController>
        [HttpPost]
        public async Task<MadeniTransacation> Post([FromBody] MobileTransaction mobileTransaction)
        {
            var message = $"Get the key elements and return as a json object with the properties: TransactionType (indicates if money was sent, paid, bought or purchase. Indicate as unknown if not one of these. If it is a ), TransactionDate (convert this to dotnet datetime format), Amount (as a decimal value), Source (indicate who sent to, paid to, received from or what was bought) from this message: {mobileTransaction.Message}";
            var result = await QueryChatGpt4(message, mobileTransaction.ApiKey);

            if (result.TransactionType == "sent" || result.TransactionType == "paid" || result.TransactionType == "purchase")
            {
                // Add transacation to user
                ExpenseDto expense = new ExpenseDto
                {
                    Amount = Decimal.TryParse(result.Amount, out decimal amount) ? amount : 0,
                    Date = DateTime.TryParse(result.TransactionDate, out DateTime date) ? date : DateTime.Now,
                    UserId = mobileTransaction.UserId,
                    Name = result.Source,
                };
                this.expenseService.AddExpense(expense);
            }
            else if(result.TransactionType == "received")
            {
                // Add income to user
                IncomeDto income = new IncomeDto
                {
                    Amount = Decimal.TryParse(result.Amount, out decimal amount) ? amount : 0,
                    Date = DateTime.TryParse(result.TransactionDate, out DateTime date) ? date : DateTime.Now,
                    UserId = mobileTransaction.UserId,
                    Name = result.Source,
                };
                this.incomeService.AddIncome(income);
            }
            else
            {

            }

            return result;
        }

        //// Create method to process the message
        //private async Task<MadeniTransacation> ProcessMessage(string message, string apiKey)
        //{
        //    var responses = new List<string>();

        //    OpenAIClient client = new OpenAIClient(apiKey);

        //    Response<Completions> response = await client.GetCompletionsAsync(
        //        "GPT-3.5", // assumes a matching model deployment or model name
        //        "Get the key elements and return as a json object with the properties: TransactionType (indicates if money was sent, paid or received. Indicate as unknown if not one of these. If it is a ), TransactionDate (convert this to dotnet datetime format), Amount (as a decimal value), Source (indicate who sent to, paid to or received from) from this message:" + message);

        //    foreach (Azure.AI.OpenAI.Choice choice in response.Value.Choices)
        //    {
        //        Console.WriteLine(choice.Text);
        //        responses.Add(choice.Text);
        //    }

        //    var ans = response.Value.Choices[0].Text;
        //    //Reeplace special characters in response
        //    ans = ans.Replace("\n", "");

        //    var transaction = JsonConvert.DeserializeObject<MadeniTransacation>(ans);

        //    return transaction;
        //}

        // Create a method to query the chatgpt 4 model using the completions api
        private async Task<MadeniTransacation> QueryChatGpt4(string message, string apiKey)
        {
            GptRequest gptMessage = new GptRequest
            {
                Model = "gpt-3.5-turbo",
                Messages = new List<GptMessage> { new GptMessage { Role = "user",Content = message } },
                Temperature =  0.1
            };
            // Creeate a http client to query https://api.openai.com/v1/chat/completions and post the message
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);
            var response = await client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", gptMessage);
            var result = await response.Content.ReadAsStringAsync();

            GptResponse gptResponse = JsonConvert.DeserializeObject<GptResponse>(result);

            var ans = gptResponse.choices[0].message.content;
            //Reeplace special characters in response
            ans = ans.Replace("\n", "");

            var transaction = JsonConvert.DeserializeObject<MadeniTransacation>(ans);

            return transaction;
        }
    }

}
