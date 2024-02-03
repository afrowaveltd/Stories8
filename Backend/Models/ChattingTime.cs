namespace Backend.Models
{
  public class ChattingTime
  {
    public int Id { get; set; }

    public string UserId { get; set; }
    public DateTime StartTime { get; set; }
    public TimeSpan TimeInChatSuma { get; set; }
    public UserModel User { get; set; }
  }
}