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
    public class LoansController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Loans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanDto>>> GetLoans(string userId)
        {
          if (_context.Loans == null)
          {
              return NotFound();
          }           
            var loanDtos = new List<LoanDto>();
            foreach(var loan in await _context.Loans.Where(e=>e.UserId == userId).ToListAsync())
            {
                var loanDto = new LoanDto
                {
                    Id = loan.Id,
                    Name = loan.Name,
                    Amount = loan.Amount,
                    ProspectiveDate = loan.ProspectiveDate,
                    StartDate = loan.StartDate                   
                };
                loanDtos.Add(loanDto);
            }
            return loanDtos;
        }

        // GET: api/Loans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanDto>> GetLoan(int id)
        {
          if (_context.Loans == null)
          {
              return NotFound();
          }
            var loan = await _context.Loans.FindAsync(id);

            if (loan == null)
            {
                return NotFound();
            }

            var loanDto = new LoanDto
            {
                Id = loan.Id,
                Name = loan.Name,
                Amount = loan.Amount,
                ProspectiveDate = loan.ProspectiveDate,
                StartDate = loan.StartDate,
                UserId = loan.UserId
            };

            return loanDto;
        }

        // PUT: api/Loans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoan(int id, Loan loan)
        {
            if (id != loan.Id)
            {
                return BadRequest();
            }

            _context.Entry(loan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanExists(id))
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

        // POST: api/Loans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoanDto>> PostLoan(LoanDto loanDto)
        {
          if (_context.Loans == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Loans'  is null.");
          }            
            var loan = new Loan
            {
                Id = loanDto.Id,
                Name = loanDto.Name,
                Amount = loanDto.Amount,
                ProspectiveDate = loanDto.ProspectiveDate,
                StartDate = loanDto.StartDate,
               UserId = loanDto.UserId
            };

            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoan", new { id = loan.Id }, loanDto);
        }

        // DELETE: api/Loans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            if (_context.Loans == null)
            {
                return NotFound();
            }
            var loan = await _context.Loans.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }

            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoanExists(int id)
        {
            return (_context.Loans?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
