using Service_Request_App.Interfaces;
using Service_Request_App.Model;
using System.Net;
using System.Net.Mail;
namespace Service_Request_App.Services
{
    public class NotificationService : INotificationService
    {
        public async Task SendNotificationAsync(string email, string message,string subject,ServiceRequest request)
        {
            var mailMessage = new MailMessage("no-reply@gmail.com", email, subject, message);
            using (var smtpClient = new SmtpClient("smtp.gmail.com"))
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
            await Task.CompletedTask;

            // *********** Another way of Implementation

            //using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort))
            //{
            //    smtpClient.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
            //    smtpClient.EnableSsl = true; 

            //    var mailMessage = new MailMessage
            //    {
            //        From = new MailAddress(_smtpUsername),
            //        Subject = subject,
            //        Body = body,
            //        IsBodyHtml = true 
            //    };

            //    mailMessage.To.Add(toEmail);

            //    await smtpClient.SendMailAsync(mailMessage);
            //}
        }
    }
}
