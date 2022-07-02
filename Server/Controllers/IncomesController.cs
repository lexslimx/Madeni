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
using System.Security.Claims;

namespace Madeni.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IncomesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Incomes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncomeDto>>> GetIncomes(string userId)
        {
            if (_context.Incomes == null)
            {
                return NotFound();
            }
            var incomeDtos = new List<IncomeDto>();
            foreach (var income in await _context.Incomes.Where(e => e.UserId == userId).ToListAsync())
            {
                var incomeDto = new IncomeDto
                {
                    Id = income.Id,
                    Amount = income.Amount,
                    Name = income.Name,
                    Frequency = income.Frequency.ToString(),
                    Type = income.Type.ToString()
                };
                incomeDtos.Add(incomeDto);
            }

            return incomeDtos;
        }

        // GET: api/Incomes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Income>> GetIncome(int id)
        {
            if (_context.Incomes == null)
            {
                return NotFound();
            }
            var income = await _context.Incomes.FindAsync(id);

            if (income == null)
            {
                return NotFound();
            }

            return income;
        }

        // PUT: api/Incomes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncome(int id, Income income)
        {
            if (id != income.Id)
            {
                return BadRequest();
            }

            _context.Entry(income).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncomeExists(id))
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

        // POST: api/Incomes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IncomeDto>> PostIncome(IncomeDto incomeDto)
        {
            if (_context.Incomes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Incomes'  is null.");
            }
            var income = new Income
            {
                Name = incomeDto.Name,
                Amount = incomeDto.Amount,
                Frequency = Models.Enums.IncomeFrequency.Monthly,
                UserId = incomeDto.UserId
            };

            _context.Incomes.Add(income);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncome", new { id = income.Id }, incomeDto);
        }

        // DELETE: api/Incomes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncome(int id)
        {
            if (_context.Incomes == null)
            {
                return NotFound();
            }
            var income = await _context.Incomes.FindAsync(id);
            if (income == null)
            {
                return NotFound();
            }

            _context.Incomes.Remove(income);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncomeExists(int id)
        {
            return (_context.Incomes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
