using System.Net;
using System.Net.Mail;

namespace CommonComponents
{
    public static class WindowsMail
    {
        public static void Email(
          string sServerUser,
          string sServerPswd,
          string sBody,
          string sSubject,
          string sFromAddress,
          string sToAddress,
          string path)
        {
            string userName = sServerUser;
            string password = sServerPswd;
            MailMessage message = new MailMessage(sFromAddress, sToAddress);
            message.Subject = sSubject;
            message.Body = sBody;
            Attachment attachment = new Attachment(path);
            message.Attachments.Add(attachment);
            new SmtpClient()
            {
                Host = "x.x.x.x",
                Port = 25,
                Credentials = new NetworkCredential(userName, password)
            }.Send(message);
        }
    }
}
