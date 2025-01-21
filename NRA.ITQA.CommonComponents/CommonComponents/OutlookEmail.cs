using System;
using System.Net.Mail;

namespace CommonComponents
{
    public static class OutlookEmail
    {
        public static bool SendEmailViaOutlook(string sFromAddress, string sToAddress, string sCc, string sSubject, string sBody, string arrAttachments, string sBcc)
        {
            {
                bool bRes = true;
                try
                {
                    //SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
                    //client.Port = 587;
                    SmtpClient client = new SmtpClient("hybrid.restaurant.org");
                    client.Port = 25;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    System.Net.NetworkCredential credentials =
                        new System.Net.NetworkCredential("", "");
                    client.EnableSsl = false;
                    client.Credentials = credentials;
                    MailMessage message = new MailMessage(sFromAddress, sToAddress);
                    message.Subject = sSubject;
                    message.IsBodyHtml = true;
                    message.Body = sBody;
                    // Add a carbon copy recipient.
                    MailAddress copy = new MailAddress(sCc);
                    message.CC.Add(copy);
                    MailAddress Bcopy = new MailAddress(sBcc);
                    message.Bcc.Add(Bcopy);
                    message.Attachments.Add(new Attachment(arrAttachments));
                    client.Send(message);
                    Console.WriteLine("Email Sent Successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: Failed to send mail: " + ex.Message);
                }
                return bRes;
            }
        }

    }
}

