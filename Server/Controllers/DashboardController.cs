using AutoMapper;
using ChartJs.Blazor.Common;
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
        private readonly IMapper mapper;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardController(ApplicationDbContext context, IConfiguration configuration, IHttpContextAccessor HttpContextAccessor, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = HttpContextAccessor;
            this.mapper = mapper;
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
                DashboardWidgets = GetWidgetData(userId, null, null),
                ChartData = GetChartData(userId,DateTime.Now.Year),
                UserId = userId
            };

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

        //For each month from 0 - 11, createa widget of each type calculating the balances for that month
        private List<DashboardWidget> GetAnnualChartData(int year){
            int month = 0;
            List<DashboardWidget> annualChartData = new List<DashboardWidget>();
            for(;month < 12; month++){
                

            }
            return annualChartData;
        }        

        private List<DashboardWidget>GetChartData(string userId, int? year)
        {
            var ChartData = new List<DashboardWidget>();
            for(int month = 1; month <= DateTime.Now.Month; month++)
            {
                ChartData.AddRange(GetWidgetData(userId, year, month));
            }

            return ChartData;
        }

        private List<DashboardWidget> GetWidgetData(string userId, int? year, int? month)
        {
            if (year == null) year = DateTime.Now.Year;
            if (month == null) month = DateTime.Now.Month;

            if (String.IsNullOrEmpty(userId))
            {
                return new List<DashboardWidget>();
            }

            var DashboardWidgets = new List<DashboardWidget>
            {
                new DashboardWidget
                {
                    DisplayOrder = 2,
                    WidgetType = Shared.WidgetType.Loans,
                    Total = _context.Loans.Where(e => e.UserId == userId && e.StartDate.Year == year && e.StartDate.Month <= month).Sum(f => f.Amount),
                    Balance = GetLoansBalance(_context.Loans.Where(e => e.UserId == userId && e.StartDate.Year == year && e.StartDate.Month <= month).Include(e => e.Repayments)),
                    Title = Shared.WidgetType.Loans.ToString()
                },

                new DashboardWidget
                {
                    DisplayOrder = 1,
                    WidgetType = Shared.WidgetType.Expenses,
                    Total = _context.Expenses.Where(e => e.UserId == userId && e.Date.Year == year && e.Date.Month == month).Sum(i => i.Amount) + _context.Repayments.Where(e => e.UserId == userId && e.Date.Year == year && e.Date.Month == month).Sum(i => i.Amount),
                    Title = Shared.WidgetType.Expenses.ToString()
                },

                new DashboardWidget
                {
                    DisplayOrder = 0,
                    WidgetType = Shared.WidgetType.Incomes,
                    Total = _context.Incomes.Where(e => e.UserId == userId && e.Date.Year == year && e.Date.Month == month).Sum(i => i.Amount),
                    Title = Shared.WidgetType.Incomes.ToString(),
                    Balance = (_context.Incomes.Where(e => e.UserId == userId && e.Date.Year == year && e.Date.Month <= month).Sum(i => i.Amount)) - (_context.Expenses.Where(e => e.UserId == userId && e.Date.Year == year && e.Date.Month <= month).Sum(i => i.Amount) + _context.Repayments.Where(e => e.UserId == userId && e.Date.Year == year && e.Date.Month <= month).Sum(i => i.Amount))
                },

                new DashboardWidget
                {
                    DisplayOrder = 3,
                    WidgetType = Shared.WidgetType.Repayments,
                    Total = _context.Repayments.Where(e => e.UserId == userId && e.Date.Year == year && e.Date.Month == month).Sum(e=>e.Amount),
                    Title = Shared.WidgetType.Repayments.ToString()
                }
            };

            return DashboardWidgets;
        }
           
    }
}
