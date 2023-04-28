namespace Madeni.Shared.Dtos
{
    public class InvestmentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Guid GoalId { get; set; }
        public string UserId { get; set; }
        public string? GoalName { get; set; }
    }
}