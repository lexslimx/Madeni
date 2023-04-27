namespace Madeni.Server.Models
{
    //This could be savings or investment - we willnot calculate interests for now
    public class Investment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid GoalId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public virtual Goal Goal { get; set; }        
    }
}
