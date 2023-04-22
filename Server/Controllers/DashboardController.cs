using Madeni.Server.Data;
using Madeni.Server.Models;
using Madeni.Shared.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                DashboardWidgets = new List<DashboardWidget>()
            };
            dashboardDto.DashboardWidgets.Add(new DashboardWidget
            {
                DisplayOrder = 2,
                WidgetType = Shared.WidgetType.Loans,
                Total = _context.Loans.Where(e => e.UserId == userId).Sum(f => f.Amount),
                Balance = GetLoansBalance(_context.Loans.Where(e => e.UserId == userId).Include(e => e.Repayments)),
                Title = Shared.WidgetType.Loans.ToString()
            });

            dashboardDto.DashboardWidgets.Add(new DashboardWidget
            {
                DisplayOrder = 1,
                WidgetType = Shared.WidgetType.Expenses,
                Total = _context.Expenses.Where(e => e.UserId == userId).Sum(i => i.Amount) + _context.Repayments.Where(e => e.UserId == userId).Sum(i => i.Amount),
                Title = Shared.WidgetType.Expenses.ToString()
            });

            dashboardDto.DashboardWidgets.Add(new DashboardWidget
            {
                DisplayOrder = 0,
                WidgetType = Shared.WidgetType.Incomes,
                Total = _context.Incomes.Where(e => e.UserId == userId).Sum(i => i.Amount),
                Title = Shared.WidgetType.Incomes.ToString(),
                Balance = (_context.Incomes.Where(e => e.UserId == userId).Sum(i => i.Amount)) - (_context.Expenses.Where(e => e.UserId == userId).Sum(i => i.Amount) + _context.Repayments.Where(e => e.UserId == userId).Sum(i => i.Amount))
            });

            dashboardDto.DashboardWidgets.Add(new DashboardWidget
            {
                DisplayOrder = 3,
                WidgetType = Shared.WidgetType.Repayments,
                Total = _context.Repayments.Where(e => e.UserId == userId).Sum(i => i.Amount),
                Title = Shared.WidgetType.Repayments.ToString()
            });

            return dashboardDto;
        }

        private decimal GetLoansBalance(IQueryable<Loan> loans)
        {
            decimal loanBalance = 0;
            foreach (Loan loan in loans)
            {
                var repaidAmount = loan.Repayments.Sum(e => e.Amount);
                loanBalance += loan.Amount - repaidAmount;
            }
            return loanBalance;
        }
    }
}
