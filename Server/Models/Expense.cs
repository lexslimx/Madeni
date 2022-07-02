namespace Madeni.Server.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
