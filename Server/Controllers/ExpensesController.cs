using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Madeni.Server.Data;
using Madeni.Server.Models;
using Madeni.Shared.Dtos;
using Madeni.Server.Services;

namespace Madeni.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        // GET: api/Expenses
        [HttpGet]
        public ActionResult<IEnumerable<ExpenseDto>> GetExpense(string userId)
        {
            var ExpenseDtos = _expenseService.GetExpenses(userId);
            return Ok(ExpenseDtos);
        }

        // GET: api/Expenses/5
        [HttpGet("{id}")]
        public ActionResult<Expense> GetExpense(int id)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Expenses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpense(int id, Expense expense)
        {
            throw new NotImplementedException();
        }

        // POST: api/Expenses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Expense> PostExpense(ExpenseDto expenseDto)
        {

            return Ok(_expenseService.AddExpense(expenseDto));
;        }

        // DELETE: api/Expenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            throw new NotImplementedException();
        }

        private bool ExpenseExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
