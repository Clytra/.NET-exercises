using ReportService.Extensions;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace ReportService.Models
{
    public class Email
    {
        private SmtpClient _smtp;
        private MailMessage _mail;

        private string _hostSmtp;
        private bool _enableSsl;
        private int _port;
        private string _senderEmail;
        private string _senderEmailPassword;
        private string _senderName;

        public Email(EmaiParams emaiParams)
        {
            _hostSmtp = emaiParams.HostSmtp;
            _enableSsl = emaiParams.EnableSsl;
            _port = emaiParams.Port;
            _senderEmail = emaiParams.SenderEmail;
            _senderEmailPassword = emaiParams.SenderEmailPassword;
            _senderName = emaiParams.SenderName;
        }

        public void Send(string subject, string body, string to)
        {
            _mail = new MailMessage();
            _mail.From = new MailAddress(_senderEmail, _senderName);
            _mail.To.Add(new MailAddress(to));
            _mail.IsBodyHtml = true;
            _mail.Subject = subject;
            _mail.BodyEncoding = Encoding.UTF8;
            _mail.SubjectEncoding = Encoding.UTF8;

            _mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(body.StripHTML(),
                null, MediaTypeNames.Text.Plain));
        }
    }
}
