using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeni.Shared.Dtos
{
    public class GoalDto
    {
        public GoalDto()
        {
            Investments = new List<InvestmentDto>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime TargetDate { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public IEnumerable<InvestmentDto> Investments { get; set; }
    }
}
