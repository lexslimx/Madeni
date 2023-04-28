using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeni.Shared.Dtos
{
    public class RepaymentDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string? LoanName { get; set; }
        public int LoanId { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
