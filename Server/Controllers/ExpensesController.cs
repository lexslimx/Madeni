using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Madeni.Server.Data;
using Madeni.Server.Models;
using Madeni.Shared.Dtos;

namespace Madeni.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExpensesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Expenses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetExpense()
        {
            if (_context.Expenses == null)
            {
                return NotFound();
            }

            var ExpenseDtos = new List<ExpenseDto>();
            foreach (var expense in await _context.Expenses.ToListAsync())
            {
                var expenseDto = new ExpenseDto
                {
                    Id = expense.Id,
                    Name = expense.Name,
                    Amount = expense.Amount
                };
                ExpenseDtos.Add(expenseDto);
            }
            return ExpenseDtos;
        }

        // GET: api/Expenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Expense>> GetExpense(int id)
        {
          if (_context.Expenses == null)
          {
              return NotFound();
          }
            var expense = await _context.Expenses.FindAsync(id);

            if (expense == null)
            {
                return NotFound();
            }

            return expense;
        }

        // PUT: api/Expenses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpense(int id, Expense expense)
        {
            if (id != expense.Id)
            {
                return BadRequest();
            }

            _context.Entry(expense).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Expenses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Expense>> PostExpense(ExpenseDto expenseDto)
        {
          if (_context.Expenses == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Expense'  is null.");
          }
            var expense = new Expense
            {                
                Name = expenseDto.Name,
                Amount = expenseDto.Amount
            };
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpense", new { id = expense.Id }, expense);
        }

        // DELETE: api/Expenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            if (_context.Expenses == null)
            {
                return NotFound();
            }
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExpenseExists(int id)
        {
            return (_context.Expenses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
