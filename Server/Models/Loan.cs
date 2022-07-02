﻿namespace Madeni.Server.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ProspectiveDate { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
