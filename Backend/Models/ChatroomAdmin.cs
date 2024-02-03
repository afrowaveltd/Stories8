namespace Backend.Models
{
  public class ChatroomAdmin
  {
    public int Id { get; set; }

    public string UserId { get; set; }

    public int RoomId { get; set; }

    public string AdminHash { get; set; }

    public UserModel User { get; set; }
    public Chatroom Chatroom { get; set; }
  }
}