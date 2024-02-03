using MailKit.Security;

namespace Backend.Models.Dto
{
    public class SmtpSettingsDto
    {
        public string SmtpServer { get; set; }

        public string EmailFrom { get; set; } = "stories@outlook.cz";

        public int SmtpPort { get; set; } = 25;

        public string SecureSocketOptions { get; set; } = "auto";
        public bool UseAuthentication { get; set; } = true;
        public string? SmtpUser { get; set; }
        public string? SmtpPassword { get; set; }
        public string? TestMail { get; set; }
    }
}
