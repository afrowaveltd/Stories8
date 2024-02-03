using Backend.Data;
using Backend.Models;
using Backend.Models.Helpers;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using MimeKit;
using ToolsLibrary;

namespace Backend.Services
{
    public class EmailService : IEmailService
    {
        private readonly ApplicationDbContext _context;
        private ILogger<EmailService> _logger;
        private IStringLocalizer<EmailService> t;

        public EmailService(ApplicationDbContext context, ILogger<EmailService> logger, IStringLocalizer<EmailService> t)
        {
            _context = context;
            _logger = logger;
            this.t = t;
        }

        public async Task<ApiResponse<object>> TestSettings(SmtpSettingsModel settings, string email)
        {
            SmtpTestResult result = new();
            EmailLog emaillog = new();
            EmailRecepient recepient = new();
            SmtpTest connectionTest = new SmtpTest();
            SmtpTest authenticationTest = new SmtpTest();
            SmtpTest sendMailTest = new SmtpTest();
            
            


            emaillog.Subject = "Test SMTP";
            await _context.EmailLogs.AddAsync(emaillog);
            await _context.SaveChangesAsync();
            recepient.EmailLogId = emaillog.Id;

            _logger.LogInformation("Testing SMTP settings", new SmtpSettingsModel
            {
                SmtpServer = settings.SmtpServer,
                SmtpPort = settings.SmtpPort,
                SmtpUser = settings.SmtpUser,
                SmtpPassword = "********",
                UseAuthentication = settings.UseAuthentication,
                SecureSocketOptions = settings.SecureSocketOptions,
            });



            MimeMessage message = new();
            message.From.Add(new MailboxAddress("", "stories@outlook.cz"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Testing SMTP settings";
            message.Body = new TextPart("html")
            { Text = "Testing SMTP settings" };
            
            
            connectionTest.TestName = t["Connection"];
            using SmtpClient client = new();
            try
            {
                await client.ConnectAsync(settings.SmtpServer, settings.SmtpPort, settings.SecureSocketOptions);
                connectionTest.Result = SmtpTestStatus.Pass;
                result.smtpTestResults.Add(connectionTest);
            }
            catch (Exception ex)
            {
                recepient.Sent = false;
                recepient.Error = ex.Message;
                recepient.SentAt = DateTime.UtcNow;
                await _context.EmailRecepients.AddAsync(recepient);
                await _context.SaveChangesAsync();
                connectionTest.Result = SmtpTestStatus.Fail;
                connectionTest.ErrorMessage = ex.Message;
                result.smtpTestResults.Add(connectionTest);
                result.smtpTestResults.Add(authenticationTest);
                result.smtpTestResults.Add(sendMailTest);

                return new ApiResponse<object>
                {
                    Data = result
                };
            }

            
            authenticationTest.TestName = t["AuthenticationTest"];

            try
            {
                await client.AuthenticateAsync(settings.SmtpUser, settings.SmtpPassword);
                authenticationTest.Result = SmtpTestStatus.Pass;
                result.smtpTestResults.Add(authenticationTest);

            }
            catch (Exception ex)
            {
                recepient.Sent = false;
                recepient.Error = ex.Message;
                recepient.SentAt = DateTime.UtcNow;
                await _context.EmailRecepients.AddAsync(recepient);
                await _context.SaveChangesAsync();
                authenticationTest.Result = SmtpTestStatus.Fail;
                authenticationTest.ErrorMessage = ex.Message;
                result.smtpTestResults.Add(authenticationTest);
                result.smtpTestResults.Add(sendMailTest);

                return new ApiResponse<Object>()
                {
                    Data = result
                };
            }

            
            sendMailTest.TestName = t["SendSmtpMessage"];
            try
            {

                await client.SendAsync(message);
                await client.DisconnectAsync(true);
                recepient.Sent = true;
                recepient.SentAt = DateTime.UtcNow;
                sendMailTest.Result = SmtpTestStatus.Pass;
                result.smtpTestResults.Add(sendMailTest);
            }
            catch (Exception ex)
            {
                recepient.Sent = false;
                recepient.Error = ex.Message;
                recepient.SentAt = DateTime.UtcNow;

                sendMailTest.Result = SmtpTestStatus.Fail;
                sendMailTest.ErrorMessage = ex.Message;
                result.smtpTestResults.Add(sendMailTest);
                return new ApiResponse<Object>() { Data = result };
            }


            await _context.EmailRecepients.AddAsync(recepient);
            await _context.SaveChangesAsync();
            ApiResponse<object> returnResponse = new();
            {
                returnResponse.Data = result;

            };
            return returnResponse;
        }

        public async Task<ApiResponse<string>> SendEmailAsync(string email, string subject, string body)
        {
            ApiResponse<string> response = new();
            EmailLog emaillog = new();
            EmailRecepient recepient = new();
            emaillog.Subject = subject;
            await _context.EmailLogs.AddAsync(emaillog);
            await _context.SaveChangesAsync();
            recepient.EmailLogId = emaillog.Id;

            ApplicationSetup settings = await _context.ApplicationSetups.FirstOrDefaultAsync();
            if (settings == null)
            {
                recepient.Error = "Email settings were not found";
                recepient.Sent = false;
                await _context.EmailRecepients.AddAsync(recepient);
                await _context.SaveChangesAsync();
                return new ApiResponse<string>() { Data = "Smtp settings not found", Error = true };
            }

            MimeMessage message = new();
            message.From.Add(new MailboxAddress("", settings.EmailFrom));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = subject;
            message.Body = new TextPart("html")
            { Text = body };
            using SmtpClient client = new SmtpClient();
            try
            {
                await client.ConnectAsync(settings.SmtpServer, settings.SmtpPort, settings.SecureSocketOptions);
            }
            catch (Exception ex)
            {
                recepient.Sent = false;
                recepient.Error = ex.Message;
                await _context.EmailRecepients.AddAsync(recepient);
                await _context.SaveChangesAsync();
                response.Data = ex.Message;
                response.Error = true;
                return response;
            }
            try
            {
                await client.AuthenticateAsync(settings.SmtpUser, settings.SmtpPassword);
            }
            catch (Exception ex)
            {
                recepient.Sent = false;
                recepient.Error = ex.Message;
                await _context.EmailRecepients.AddAsync(recepient);
                await _context.SaveChangesAsync();
                response.Data = ex.Message;
                response.Error = true;
                return response;
            }
            try
            {
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                recepient.Sent = false;
                recepient.Error = ex.Message;
                await _context.EmailRecepients.AddAsync(recepient);
                await _context.SaveChangesAsync();
                response.Data = ex.Message;
                response.Error = true;
                return response;
            }
            recepient.Sent = true;
            recepient.SentAt = DateTime.UtcNow;
            await _context.EmailRecepients.AddAsync(recepient);
            await _context.SaveChangesAsync();
            return new ApiResponse<string>()
            {
                Data = "Email sent successfuly"
            };
        }

        public async Task<ApiResponse<string>> SendCodeAsync(string callbackUrl, string email)
        {
            ApiResponse<string> result = new();
            string subj = t["Activation of the account"];
            result = await SendEmailAsync(email, subj, GenerateActivationEmail(callbackUrl));
            return result;
        }

        public async Task<ApiResponse<string>> SendResetPasswordCodeAsync(string callbackUrl, string email)
        {
            ApiResponse<string> result = new();
            string subj = t["Reset the password"];
            result = await SendEmailAsync(email, subj, GeneratePasswordResetEmail(callbackUrl));
            return result;
        }

        private string GenerateActivationEmail(string callbackUrl)
        {
            string emailBody = $"<h5 style=\"text-align: center\">{t["Hello"]}, </h5>" +
              $"<div> {t["Please"]}<a href=\"{callbackUrl}\"> {t["Click here"]}</a> {t["to confirm your account"]}";

            return emailBody;
        }

        private string GeneratePasswordResetEmail(string callbackUrl)
        {
            string emailBody = $"<h5 style=\"text-align: center\">{t["Hello"]}, </h5>" +
              $"<div> {t["Please"]}<a href=\"{callbackUrl}\"> {t["Click here"]}</a> {t["to reset your password"]}";

            return emailBody;
        }

    }

}
