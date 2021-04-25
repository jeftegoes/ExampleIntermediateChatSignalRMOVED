namespace ExampleIntermediateChatSignalR.Models
{
    public class ChatMessage
    {
        public User Sender { get; set; }
        public string Message { get; set; }
        public long Destination { get; set; }
    }
}