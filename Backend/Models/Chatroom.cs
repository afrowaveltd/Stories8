using static Backend.Tools.Settings;

namespace Backend.Models
{
  public class Chatroom
  {
    public int Id { get; set; }
    public string? OwnerId { get; set; }
    public bool IsActive { get; set; } = true;
    public RoomType Type { get; set; }
    public DateTime Created { get; set; }

    public UserModel Owner { get; set; }

    public List<ChatBan> ChatBans { get; set; }
    public List<ChatroomAdmin> ChatroomAdmins { get; set; }
    public List<UsersInRoom> UsersInRoom { get; set; }
    public List<ChatMessage> ChatMessages { get; set; }
  }
}