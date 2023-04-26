namespace Madeni.Shared.Dtos
{
    public class InvestmentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid GoalId { get; set; }
       
    }
}