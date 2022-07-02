using Madeni.Server.Data;
using Madeni.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Madeni.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public DashboardController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        // GET: api/<DashboardController>
        [HttpGet]
        public DashboardDto? Get()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(userId == null)
            {
                return new DashboardDto();
            }
            var dashboardDto = new DashboardDto
            {
                IncomeTotal = _context.Incomes.Where(i => i.UserId == userId).Sum(i => i.Amount),
                ExpenseTotal = _context.Expenses.Where(i => i.UserId == userId).Sum(i => i.Amount),
                LoanTotal = _context.Loans.Where(i => i.UserId == userId).Sum(i => i.Amount),
                RepaymentsTotal = _context.Repayments.Where(i => i.UserId == userId).Sum(i => i.Amount),
                DefaultConnection = _configuration.GetConnectionString("DefaultConnection")
            };
            dashboardDto.Balance = (dashboardDto.IncomeTotal - dashboardDto.ExpenseTotal);


            return dashboardDto;
        }
    }
}
