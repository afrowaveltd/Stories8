namespace Backend.Models
{
  public class ChatElevated
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public UserModel User { get; set; }
  }
}