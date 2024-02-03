using MailKit.Security;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
  public class ApplicationSetup
  {
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = "Stories";
    public string ApplicationUrl { get; set; } = "https://localhost:7008";
    public bool TranslateName { get; set; } = true;

    public string? OwnerId { get; set; }

    // email settings
    [Required]
    public string SmtpServer { get; set; }

    public string EmailFrom { get; set; } = "stories@outlook.cz";

    public int SmtpPort { get; set; } = 25;

    public SecureSocketOptions SecureSocketOptions { get; set; } = SecureSocketOptions.Auto;
    public bool UseAuthentication { get; set; } = true;
    public string? SmtpUser { get; set; }
    public string? SmtpPassword { get; set; }
    public UserModel? Owner { get; set; }
  }
}