using MailKit.Security;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Helpers
{
  public class SmtpSettingsModel
  {
    public string EmailFrom { get; set; } = "stories@outlook.cz";

    [Required]
    public string SmtpServer { get; set; }

    [Required]
    public int SmtpPort { get; set; }

    public SecureSocketOptions SecureSocketOptions { get; set; }
    public bool UseAuthentication { get; set; } = true;
    public string SmtpUser { get; set; }
    public string SmtpPassword { get; set; }
  }
}