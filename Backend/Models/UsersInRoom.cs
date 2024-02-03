namespace Backend.Models
{
  public class UsersInRoom
  {
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string UserId { get; set; }
    public bool IsAdmin { get; set; } = false;
    public DateTime JoiningTime { get; set; }
    public DateTime LeavingTime { get; set; }
    public UserModel User { get; set; }
    public Chatroom Chatroom { get; set; }
  }
}