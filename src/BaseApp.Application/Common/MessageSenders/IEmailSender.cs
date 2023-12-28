using System.Net.Mail;

namespace BaseApp.Application.Common.MessageSenders
{
    public interface IEmailSender
    {
        void SendEmail(MailMessage message);
    }
}
