using Duende.IdentityServer.EntityFramework.Options;
using Madeni.Server.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Madeni.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Repayment> Repayments { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Investment> Investments { get; set; }
        public DbSet<TransactionMessage> TransactionMessages { get; set; }
    }
}