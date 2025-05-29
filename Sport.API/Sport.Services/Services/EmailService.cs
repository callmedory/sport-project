using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sport.Models;
using Sport.Services.Interfaces; 
using Sport.Models.Exceptions;
using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Sport.Services.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly ILogger _logger; 

        public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }

        public async Task EmailVerification(string email, string verificationToken) 
        {
            try
            {
                var link = _emailSettings.EmailUrl + verificationToken; 
                var content = $"To complete registration you need to verificate email.To do this click the link below:\n{link}";
                await CreateMessage(email.ToLower(), content, "Email Verification"); 
                _logger.LogInformation("Email with link for email verification has been send on email {email}", email.ToLower());
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }
        }

        public async Task RestorePassword(string email, string verificationToken)
        {
            try
            {
                var link = _emailSettings.PasswordUrl + verificationToken;
                var content = $"To restore password click the link below: \n{link}";
                await CreateMessage(email.ToLower(), content, "Restore Password");
                _logger.LogInformation("Email with link for restoring password has been send on email {email}", email.ToLower());
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }
        }

        public async Task CreateMessage(string email, string content, string subject)
        {
            try
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName),
                    Subject = subject,
                    Body = content,
                    IsBodyHtml = false
                };
                mailMessage.To.Add(new MailAddress(email));

                using (var smtpClient = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort))
                {
                    smtpClient.Credentials = new NetworkCredential(_emailSettings.SmtpUsername, _emailSettings.SmtpPassword);
                    smtpClient.EnableSsl = _emailSettings.EnableSsl;

                    await smtpClient.SendMailAsync(mailMessage);
                }
                _logger.LogInformation("Successfully sent email to {Email} with subject {Subject}", email, subject);
            }
            catch (SmtpException ex)
            {
                _logger.LogError(ex, "SMTP error sending email to {Email} with subject {Subject}. Server: {SmtpServer}, Port: {SmtpPort}, SSL: {EnableSsl}, Username: {SmtpUsername}",
                    email, subject, _emailSettings.SmtpServer, _emailSettings.SmtpPort, _emailSettings.EnableSsl, _emailSettings.SmtpUsername);
                throw new CustomException($"SMTP error sending email: {ex.Message}. Check SMTP server settings and credentials.");
            }
            catch (Exception ex)
            {
                throw new CustomException($"General error sending email: {ex.Message}");
            }
        }

        public async Task ArticleIsPublished(string email, string articleName)
        {
            try
            {
                var content = $"Congratulations! Your article \"{articleName}\" was published.";
                await CreateMessage(email.ToLower(), content, "Article is Published");
                _logger.LogInformation("Email about successfull publish of article has been send on email {email}", email.ToLower());
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }
        }
    }
}