using MailKit.Net.Smtp;
using MimeKit;


namespace Clarity_Crate.Services
{
    public class EmailSender
    {


        public async Task SendEmailAsync(string email, string subject)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Tatenda Nyamuda", "ptnrlab@gmail.com"));
                message.To.Add(new MailboxAddress("Mrs. Chanandler Bong", email));
                message.Subject = subject;

                message.Body = new TextPart("plain")
                {
                    Text = "Hey there my friend"
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate("ptnrlab@gmail.com", "vghw owdn uncx lnoq");

                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
