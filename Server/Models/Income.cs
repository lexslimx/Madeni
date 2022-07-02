using Madeni.Server.Models.Enums;

namespace Madeni.Server.Models
{
    public class Income
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public IncomeFrequency Frequency { get; set; }
        public IncomeType Type { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
