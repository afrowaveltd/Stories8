namespace Backend.Models
{
  public class ChatBan
  {
    public int Id { get; set; }

    public string UserId { get; set; }
    public string AdminUserId { get; set; }
    public int ChatroomId { get; set; }
    public bool BanForAllChat { get; set; } = false;
    public DateTime BannedUntil { get; set; }

    public string ReasonForBan { get; set; }

    public UserModel User { get; set; }
    public UserModel AdminUser { get; set; }
    public Chatroom Chatroom { get; set; }
  }
}