using MailKit.Security;
using Microsoft.AspNetCore.Components.Forms;

namespace Backend.Models.Dto
{
    public class InstallationProfileDto
    {
        public string ApplicationName { get; set; } = "Stories";
        public string ApplicationUrl { get; set; } = "https://localhost:7066";
        public bool TranslateName { get; set; } = true;
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDate { get; set; } = DateTime.Today.AddYears(-3);
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayedName { get; set; }
        public int CountryId { get; set; }
        public IBrowserFile? Picture { get; set; }
        public string SmtpServer { get; set; }

        public string EmailFrom { get; set; } = "stories@outlook.cz";

        public int SmtpPort { get; set; } = 25;

        public SecureSocketOptions SecureSocketOptions { get; set; } = SecureSocketOptions.Auto;
        public bool UseAuthentication { get; set; } = true;
        public string? SmtpUser { get; set; }
        public string? SmtpPassword { get; set; }
    }
}
