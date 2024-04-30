using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;


namespace Clarity_Crate.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger _logger;




        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var messageToSend = new MimeMessage();
                messageToSend.From.Add(new MailboxAddress("Tatenda Nyamuda", "ptnrlab@gmail.com"));
                messageToSend.To.Add(new MailboxAddress("Mrs. Chanandler Bong", "ptnmath@gmail.com"));
                messageToSend.Subject = subject;

                messageToSend.Body = new TextPart("plain")
                {
                    Text = message
                };
                /*
                messageToSend.Body = new TextPart("plain")
                {
                    Text = "Hey there my friend"
                };*/

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate("ptnrlab@gmail.com", "vghw owdn uncx lnoq");

                    client.Send(messageToSend);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
