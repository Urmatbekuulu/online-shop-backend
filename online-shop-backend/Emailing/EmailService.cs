using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace online_shop_backend.Emailing
{
    public class EmailService
    {
        public readonly IEmailSender _emailSender;

        public EmailService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public Task SendVerificationEmailAsync(string email, string verificationToken, string host)
        {
            string message;
            if (!string.IsNullOrEmpty(host))
            {
                var verifyUrl = $"{host}/api/verify-email?token={verificationToken}";
                message = $@"<p>Please <a href='{verifyUrl}'>click here</a> to verify your email address.</p>";
            }
            else
            {
                message = $@"<p>Please use the below token to verify your email address with the 
                             <code>/api/verify-email</code> api route:</p>
                             <p><code>{verificationToken}</code></p>";
            }

            return _emailSender.SendEmailAsync(
                to: email,
                subject: "Students Social Network - Verify Email",
                body: $@"<h4>Verify Email</h4>
                         <p>Thanks for registering!</p>
                         {message}");
        }

        public Task SendResetPassword(string email,string callbackUrl)
        {
            return _emailSender.SendEmailAsync(
                to:email,
                subject:"Reset Password",
                body:$"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>."
            );
        }
        
        
    }
}