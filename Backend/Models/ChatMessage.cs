namespace Backend.Models
{
  public class ChatMessage
  {
    public int Id { get; set; }
    public int ChatroomId { get; set; }
    public string SenderId { get; set; }
    public string? RecepientId { get; set; }
    public string Message { get; set; }
    public bool IsAdminMessage { get; set; } = false;
    public DateTime Sent { get; set; }
    public Chatroom Chatroom { get; set; }
    public UserModel Sender { get; set; }
    public UserModel Recepient { get; set; }
  }
}