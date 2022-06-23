using System.ComponentModel.DataAnnotations.Schema;

namespace Madeni.Server.Models
{
    public class Repayment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public virtual Loan Loan { get; set; }
        [ForeignKey("Loan")]
        public int LoanId { get; set; }
    }
}
