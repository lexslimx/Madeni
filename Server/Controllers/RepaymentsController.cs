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
    public class RepaymentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RepaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Repayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepaymentDto>>> GetRepayments(int? loanId)
        {
          if (_context.Repayments == null)
          {
              return NotFound();
          }

            var repaymentDtos = new List<RepaymentDto>();
            List<Repayment> repayments = new List<Repayment>();
            if (loanId == null)
            {
                repayments = await _context.Repayments.Where(r => r.LoanId == loanId).Include(r => r.Loan).ToListAsync();
            }
            else
            {
                repayments = await _context.Repayments.Include(r => r.Loan).ToListAsync();
            }

            foreach (var repayment in repayments)
            {
                var repaymentDto = new RepaymentDto
                {
                    Id = repayment.Id,
                    Amount = repayment.Amount,
                    Date = repayment.Date,
                    LoanName = repayment.Loan.Name,
                    LoanId = repayment.LoanId
                };

                repaymentDtos.Add(repaymentDto);
            }
            return repaymentDtos;
        }

        // GET: api/Repayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Repayment>> GetRepayment(int id)
        {
          if (_context.Repayments == null)
          {
              return NotFound();
          }
            var repayment = await _context.Repayments.FindAsync(id);

            if (repayment == null)
            {
                return NotFound();
            }

            return repayment;
        }

        // PUT: api/Repayments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepayment(int id, Repayment repayment)
        {
            if (id != repayment.Id)
            {
                return BadRequest();
            }

            _context.Entry(repayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepaymentExists(id))
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

        // POST: api/Repayments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RepaymentDto>> PostRepayment(RepaymentDto repaymentDto)
        {
          if (_context.Repayments == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Repayments'  is null.");
          }

            var repayment = new Repayment
            {
                Id = repaymentDto.Id,
                Amount = repaymentDto.Amount,
                Date = repaymentDto.Date,
                LoanId = repaymentDto.LoanId
            };
            _context.Repayments.Add(repayment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRepayment", new { id = repayment.Id }, repaymentDto);
        }

        // DELETE: api/Repayments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepayment(int id)
        {
            if (_context.Repayments == null)
            {
                return NotFound();
            }
            var repayment = await _context.Repayments.FindAsync(id);
            if (repayment == null)
            {
                return NotFound();
            }

            _context.Repayments.Remove(repayment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepaymentExists(int id)
        {
            return (_context.Repayments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
