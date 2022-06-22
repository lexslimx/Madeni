namespace Madeni.Server.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime? StartSate { get; set; }
        public DateTime? ProspectiveDate { get; set; }
    }
}
