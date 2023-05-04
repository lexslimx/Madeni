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
    public class IncomesController : ControllerBase
    {
        private readonly IIncomeService _incomeService;  

        public IncomesController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        // GET: api/Incomes
        [HttpGet]
        public ActionResult<IEnumerable<IncomeDto>> GetIncomes(string userId)
        {
            var incomeDtos = _incomeService.GetIncomes(userId);
            return Ok(incomeDtos);
        }

        // GET: api/Incomes/5
        [HttpGet("{id}")]
        public ActionResult<Income> GetIncome(int id)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Incomes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutIncome(int id, Income income)
        {
            throw new NotImplementedException();        
        }

        // POST: api/Incomes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<IncomeDto> PostIncome(IncomeDto incomeDto)
        {
            if (incomeDto == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Incomes'  is null.");
            }
            _incomeService.AddIncome(incomeDto); 
            return CreatedAtAction("GetIncome", new { id = incomeDto.Id }, incomeDto);
        }

        // DELETE: api/Incomes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteIncome(int id)
        {
            throw new NotImplementedException();
        }

        private bool IncomeExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
