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
    public class RepaymentsController : ControllerBase
    {
        private readonly IRepaymentService _repaymentService;
        public RepaymentsController(IRepaymentService repaymentService)
        {
            _repaymentService = repaymentService;
        }

        // GET: api/Repayments
        [HttpGet]
        public ActionResult<IEnumerable<RepaymentDto>> GetRepayments(int? loanId, string userId)
        {
            var repaymentDtos = _repaymentService.GetRepayments(loanId, userId);            
            return Ok(repaymentDtos);
        }

        // GET: api/Repayments/5
        [HttpGet("{id}")]
        public ActionResult<Repayment> GetRepayment(int id)
        {
            var repayment = _repaymentService.GetRepayment(id);

            return Ok(repayment);
        }

        // PUT: api/Repayments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutRepayment(int id, Repayment repayment)
        {
            throw new NotImplementedException();
        }

        // POST: api/Repayments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<RepaymentDto> PostRepayment(RepaymentDto repaymentDto)
        {
          if (repaymentDto == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Repayments'  is null.");
          }
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);      
            repaymentDto.UserId = userId;

            var repayment = _repaymentService.AddRepayment(repaymentDto);
            return CreatedAtAction("GetRepayment", new { id = repayment.Id }, repaymentDto);
        }

        // DELETE: api/Repayments/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRepayment(int id)
        {
            throw new NotImplementedException();
        }

        private bool RepaymentExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
