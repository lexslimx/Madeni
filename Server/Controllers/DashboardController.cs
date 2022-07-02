using Madeni.Server.Data;
using Madeni.Shared.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardController(ApplicationDbContext context, IConfiguration configuration, IHttpContextAccessor HttpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = HttpContextAccessor;
        }
        // GET: api/<DashboardController>
        [HttpGet]
        public DashboardDto GetAsync(string userId)
        {             
            if (String.IsNullOrEmpty(userId))
            {
                return new DashboardDto();                
            }
            var dashboardDto = new DashboardDto
            {
                IncomeTotal = _context.Incomes.Where(e=>e.UserId==userId).Sum(i => i.Amount),
                ExpenseTotal = _context.Expenses.Where(e => e.UserId == userId).Sum(i => i.Amount),
                LoanTotal = _context.Loans.Where(e => e.UserId == userId).Sum(i => i.Amount),
                RepaymentsTotal = _context.Repayments.Where(e => e.UserId == userId).Sum(i => i.Amount)                
            };
            dashboardDto.Balance = (dashboardDto.IncomeTotal - dashboardDto.ExpenseTotal);
            return dashboardDto;
        }
    }
}
