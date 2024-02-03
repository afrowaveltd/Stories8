namespace Backend.Models
{
  public class ActiveConnection
  {
    public int Id { get; set; }
    public string ConnectionId { get; set; } = string.Empty;
    public string? UserId { get; set; }
    public DateTime ConnectedAt { get; set; } = DateTime.UtcNow;
    public UserModel? User { get; set; }
  }
}