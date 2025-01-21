using AE.Net.Mail;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


namespace CommonComponents
{
    public static class EmailVerfication
    {
        static ImapClient IC;
        public static string VerificationCode(string EmailAddress, string Password)
        {
            for (int i = 0; i < 25; i++)
            {
                try
                {
                    Wait.DefaultWait(5);
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    IC = new ImapClient("imap.gmail.com", EmailAddress, Password, AuthMethods.Login, 993, true);
                    IC.SelectMailbox("INBOX");
                    var Email = IC.GetMessage(IC.GetMessageCount() - 1);
                    try
                    {
                        if (!string.IsNullOrEmpty(Email.Body.Split("letter-spacing:3px;\">")[1].Split("</span>")[0]))
                            return Email.Body.Split("letter-spacing:3px;\">")[1].Split("</span>")[0];
                    }
                    catch (Exception)
                    {
                        if (!string.IsNullOrEmpty(Email.Body.Split("letter-spacing:3px;font-weight:700;\">")[1].Split("</span>")[0]))
                            return Email.Body.Split("letter-spacing:3px;font-weight:700;\">")[1].Split("</span>")[0];
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Keep trying");
                }
                i++;
            }
            return "No Code or Email";
        }
        public static void DeleteInbox()
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                IC = new ImapClient("imap.gmail.com", Constants.Properties["emailid"], Constants.Properties["password"], AuthMethods.Login, 993, true);
                IC.SelectMailbox("INBOX");
                int i = 0;
                while (i < IC.GetMessageCount())
                {
                    try
                    {
                        var email1 = IC.GetMessage(IC.GetMessageCount() - 1);
                        IC.DeleteMessage(email1);
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("No Messages");
                    }
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public static bool EmailBody(List<string> paramters)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                IC = new ImapClient("imap.gmail.com", Constants.Properties["emailid"], Constants.Properties["password"], AuthMethods.Login, 993, true);
                IC.SelectMailbox("INBOX");
                var Email = IC.GetMessage(IC.GetMessageCount() - 1);
                return paramters.All(Email.Body.Contains);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }
        }
        //public static bool EmailBody(List<string> paramters)
        //{
        //    MailMessage Email = new MailMessage();
        //    try
        //    {
        //        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        //        IC = new ImapClient("imap.gmail.com", "servesafetestautomation@gmail.com", "Password@233", AuthMethods.Login, 993, true);
        //        IC = new ImapClient("imap.gmail.com", Constants.Properties["emailid"], Constants.Properties["password"], AuthMethods.Login, 993, true);
        //        IC.SelectMailbox("INBOX");
        //        for (int i = 0; i < IC.GetMessageCount(); i++)
        //        {
        //            Email = IC.GetMessage(i);
        //            Console.WriteLine(Email.Subject);
        //            Console.WriteLine(paramters.FirstOrDefault());
        //            if (Email.Subject.Equals(paramters.FirstOrDefault()))
        //                break;
        //            i++;
        //        }
        //        return paramters.Skip(1).All(Email.Body.Contains);
        //    }
        //    catch (Exception e)
        //    {

        //        Console.WriteLine(e.Message);
        //        return false;
        //    }
        //}

        public static bool EmailSubject(List<string> paramters)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                //IC = new ImapClient("imap.gmail.com", "servesafetestautomation@gmail.com", "Password@233", AuthMethods.Login, 993, true);
                IC = new ImapClient("imap.gmail.com", Constants.Properties["emailid"], Constants.Properties["password"], AuthMethods.Login, 993, true);
                IC.SelectMailbox("INBOX");
                var Email = IC.GetMessage(IC.GetMessageCount() - 1);
                return paramters.All(Email.Subject.Contains);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static string EnterVerificationCode(IWebDriver _driver, string Password, string EmailSuccess)
        {
            try
            {
                Wait.DefaultWait(20);
                //VerfCode.SendKeys(EmailVerfication.VerificationCode("servesuccessautomation@gmail.com", "Password123$"));
                _driver.FindElement(By.Id("Passcode")).SendKeys(VerificationCode(Constants.Properties["emailid"], Constants.Properties["password"]));
                _driver.FindElement(By.Id("submitBtn")).Click();
                Wait.DefaultWait(5);
                try
                {
                    if (WebElementHelper.IsDisplayed(_driver.FindElement(By.Id("NewPassword"))))
                    {
                        Password = PasswordGenerator.RandomPassword(8);
                        Console.WriteLine(Password);
                        _driver.FindElement(By.Id("NewPassword")).SendKeys(Password);
                        _driver.FindElement(By.Id("ConfirmPassword")).SendKeys(Password);
                        _driver.FindElement(By.Id("submitBtn")).Click();
                        Wait.DefaultWait(5);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("New Account Creation");
                }
                EmailSuccess = _driver.FindElement(By.XPath("//div[contains(@class,'text-center my-4')]")).Text;
                return EmailSuccess;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assertions.FailCase(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().Name, _driver);
                return null;
            }

        }
    }
}
