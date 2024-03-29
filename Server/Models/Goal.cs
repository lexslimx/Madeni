﻿namespace Madeni.Server.Models
{
    public class Goal
    {
        public Goal() {
            Investments = new HashSet<Investment>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime TargetDate { get; set; }
        public string UserId { get; set; } = string.Empty;
        public virtual ICollection<Investment> Investments { get; set; }
    }
}
