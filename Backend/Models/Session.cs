using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
  public class Session
  {
    public int Id { get; set; }

    [Column(TypeName = "varchar(64)")]
    public string ConnectionId { get; set; }

    public string? UserId { get; set; }

    public DateTime Connected { get; set; }
    public DateTime Disconnected { get; set; }
    public bool IsActive { get; set; }
    public UserModel User { get; set; }
  }
}