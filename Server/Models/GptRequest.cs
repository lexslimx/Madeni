namespace Madeni.Server.Models
{
    public class GptRequest
    {
        public string Model { get; set; }
        public List<GptMessage> Messages { get; set; }
        public double Temperature { get; set; }
    }

    public class GptMessage
    {
        public string Content { get; set; }
        public string Role { get; set; }
    }
}
