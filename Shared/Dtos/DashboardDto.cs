using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeni.Shared.Dtos
{
    public class DashboardDto
    {
        public decimal IncomeTotal { get; set; }
        public decimal ExpenseTotal { get; set; }
        public decimal LoanTotal { get; set; }
        public decimal RepaymentsTotal { get; set; }
        public decimal Balance { get; set; }
        public string? DefaultConnection { get; set; }
        public string? UserId { get; set; }
    }
}


