using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeni.Shared.Dtos
{
    public class LoanDto
    {
        public LoanDto()
        {
            Repayments = new List<RepaymentDto>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime ProspectiveDate { get; set; } = DateTime.Now;
        public List<RepaymentDto> Repayments { get; set; }
        public string UserId { get; set; }
    }
}
