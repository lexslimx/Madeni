using Azure;
using Azure.AI.OpenAI;
using Madeni.Server.Models;
using Madeni.Server.Services;
using Madeni.Shared.Dtos;
using Madeni.Shared.Models;
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
        private readonly IExpenseService expenseService;
        private readonly IIncomeService incomeService;
        public OpenAiController(IExpenseService expenseService, IIncomeService incomeService)
        {
            this.expenseService = expenseService;
            this.incomeService = incomeService;
        }
        // GET: api/<OpenAiController>
        [HttpPost]
        public async Task<MadeniTransacation> Post([FromBody]MobileTransaction mobileTransaction)
        {
            var result = await ProcessMessage(mobileTransaction.Message, mobileTransaction.ApiKey);

            if(result.TransactionType == "sent")
            { 
                // Add transacation to user
                ExpenseDto expense = new ExpenseDto
                {
                    Amount = Decimal.Parse(result.Amount),
                    Date = DateTime.TryParse(result.TransactionDate, out DateTime date) ? date : DateTime.Now,
                    UserId = mobileTransaction.UserId,
                    Name = result.Source,
                };
                this.expenseService.AddExpense(expense);
            }
            else
            {
                // Add income to user
                IncomeDto income = new IncomeDto
                {
                    Amount = Decimal.Parse(result.Amount),
                    Date = DateTime.TryParse(result.TransactionDate, out DateTime date) ? date : DateTime.Now,
                    UserId = mobileTransaction.UserId,
                    Name = result.Source,
                };
                this.incomeService.AddIncome(income);
            }
 
            return result;
        }

        // Create method to process the message
        private async Task<MadeniTransacation> ProcessMessage(string message, string apiKey)
        {           
            var responses = new List<string>();

            OpenAIClient client = new OpenAIClient(apiKey);

            Response<Completions> response = await client.GetCompletionsAsync(
                "text-davinci-003", // assumes a matching model deployment or model name
                "Get the key elements and return as a json object with the properties: TransactionType (indicates if money was sent or received), TransactionDate (convert this to dotnet datetime format), Amount, Source from this message:" + message);

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
