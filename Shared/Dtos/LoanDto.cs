using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeni.Shared.Dtos
{
    public class LoanDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime? StartSate { get; set; }
        public DateTime? ProspectiveDate { get; set; }
    }
}
