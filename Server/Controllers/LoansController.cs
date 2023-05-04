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
using Madeni.Server.Services;

namespace Madeni.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _loanService;


        public LoansController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        // GET: api/Loans
        [HttpGet]
        public ActionResult<IEnumerable<LoanDto>> GetLoans(string userId)
        {
          if (userId == null)
          {
              return NotFound();
          }
            var loanDtos = _loanService.GetItems(userId);
            return Ok(loanDtos);
        }

        // GET: api/Loans/5
        [HttpGet("{id}")]
        public ActionResult<LoanDto> GetLoan(int id)
        {
            var loan = _loanService.GetItem(id);
            return Ok(loan);
        }

        // PUT: api/Loans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutLoan(int id, Loan loan)
        {
            throw new NotImplementedException();
        }

        // POST: api/Loans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<LoanDto> PostLoan(LoanDto loanDto)
        {
              if (loanDto == null)
              {
                  return Problem("Entity set 'ApplicationDbContext.Loans'  is null.");
              }

            var result = _loanService.AddItem(loanDto);
            return CreatedAtAction("GetLoan", new { id = result.Id }, loanDto);
        }

        // DELETE: api/Loans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            throw new NotImplementedException();
        }

        private bool LoanExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
