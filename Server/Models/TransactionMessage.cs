namespace Madeni.Server.Models
{
    public class TransactionMessage
    {
        public int TransactionMessageId { get; set; }
        public string Text { get; set; }
        public DateTime DateReceived { get; set; }
    }
}
