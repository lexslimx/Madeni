using Madeni.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Madeni.Server.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Expense> Expenses { get; set; }
        DbSet<Goal> Goals { get; set; }
        DbSet<Income> Incomes { get; set; }
        DbSet<Investment> Investments { get; set; }
        DbSet<Loan> Loans { get; set; }
        DbSet<Repayment> Repayments { get; set; }
    }
}