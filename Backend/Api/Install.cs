using Backend.Data;
using Backend.Models.Dto;
using Backend.Models.Helpers;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Crmf;
using SQLitePCL;
using ToolsLibrary;

namespace Backend.Api
{
    [Route("install")]
    [ApiController]
    public class Install : ControllerBase
    {

        private ApplicationDbContext _context;
        private IEmailService _emailService;
        private IFirstRunService _firstRunService;

        public Install(ApplicationDbContext context, IEmailService emailService, IFirstRunService firstRunService)
        {
            _context = context;
            _emailService = emailService;
            _firstRunService = firstRunService;
        }

        [HttpGet]
        public async Task<ActionResult> OnGetAsync()
        {
            if (await _context.Users.AnyAsync())
            {
                return Ok("Program is already installed, nothing to do here.");
            }

            return Ok("Please install the application");
        }
        [HttpGet]
        [Route("/help")]

        public async Task<ActionResult> GetAsync()
        {
            if (await _context.Users.AnyAsync())
            {
                return Ok("Program is already installed, nothing to do here.");
            }

            return Ok("Help:");
        }

        [HttpPost]
        [Route("/testSmtp")]

        public async Task<ActionResult> OnPostSmtpTestAsync([FromBody] SmtpSettingsDto smtpSettings)
        {
            SmtpSettingsModel appSettings = new();
            

            switch (smtpSettings.SecureSocketOptions) 
            {
                case "none":
                    appSettings.SecureSocketOptions = MailKit.Security.SecureSocketOptions.None;
                    break;
                case "ssl":
                    appSettings.SecureSocketOptions = MailKit.Security.SecureSocketOptions.SslOnConnect;
                    break;
                case "starttls":
                    appSettings.SecureSocketOptions = MailKit.Security.SecureSocketOptions.StartTls;
                    break;
                case "tlswhenavailable":
                    appSettings.SecureSocketOptions = MailKit.Security.SecureSocketOptions.StartTlsWhenAvailable;
                    break;
                default:
                    appSettings.SecureSocketOptions = MailKit.Security.SecureSocketOptions.Auto;
                    break;
            }

            appSettings.SmtpServer = smtpSettings.SmtpServer;
            appSettings.SmtpPort = smtpSettings.SmtpPort;
            appSettings.UseAuthentication = smtpSettings.UseAuthentication;
            appSettings.SmtpUser = smtpSettings.SmtpUser;
            appSettings.SmtpPassword = smtpSettings.SmtpPassword;
            var result = await _emailService.TestSettings(appSettings, smtpSettings.TestMail);
            return Ok(result);
        }

        [HttpPost]
        [Route("/firstSetup")]
        public async Task<ActionResult> OnPostAsync([FromBody] InstallationDto installUser)
        {
            InstallationResultDto installationResult = new();

            // Step 1 Create countries

            InstallationStage stage1 = new InstallationStage();
            stage1.Name = "Create countries table";

            ApiResponse<string> stage1Result = await _firstRunService.CreateCountries();



            return Ok();
        }

    }
}
