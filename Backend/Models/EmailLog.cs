using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
  public class EmailLog
  {
    [Key]
    public int Id { get; set; }

    public DateTime Created { get; set; } = DateTime.UtcNow;

    public string Subject { get; set; }

    public List<EmailRecepient>? EmailRecepients { get; set; }
  }
}