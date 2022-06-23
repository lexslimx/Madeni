using Madeni.Server.Data;
using Madeni.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Madeni.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<DashboardController>
        [HttpGet]
        public DashboardDto Get()
        {
            var dashboardDto = new DashboardDto
            {
                IncomeTotal = _context.Incomes.Sum(i => i.Amount),
                ExpenseTotal = _context.Expenses.Sum(i => i.Amount),
                LoanTotal = _context.Loans.Sum(i => i.Amount),
                RepaymentsTotal = _context.Repayments.Sum(i => i.Amount),
            };

            return dashboardDto;
        }
    }
}
