using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeni.Shared.Dtos
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string UserId { get; set; }
    }
}
