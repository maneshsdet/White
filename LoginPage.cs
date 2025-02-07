using CommonComponents;
using KeyManagementATDDTests.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Reflection;

namespace KeyManagementATDDTests.Pages
{

    public class LoginPage : TestVariables
    {

        public LoginPage(IWebDriver driver) => _driver = driver;
        HomePage homePage = new HomePage(_driver);
        public IWebElement btnCreateAccount => _driver.FindElement(By.PartialLinkText("CREATE ACCOUNT"));
        //locator for UserID
        public IWebElement txtUserId => _driver.FindElement(By.Id("username"));
        // locator for Login Button
        public IWebElement btnLogin => _driver.FindElement(By.LinkText("LOG IN"));
        //locator for password
        public IWebElement txtProfilePassword => _driver.FindElement(By.Id("password"));
        //locator for Logout
        public IWebElement lnkLogout => _driver.FindElement(By.PartialLinkText("Log Out"));
        public IWebElement lnkConfirmLogout => _driver.FindElement(By.LinkText("log out"));
        public IWebElement btnSignIn => _driver.FindElement(By.XPath("//span[contains(text(), 'Log In / Create Account')]"));


        //Action methods for Page Elements
        private void EnterUserName(string userName)
        {
            txtUserId.SendKeys(userName);
        }
        private void EnterPassword(string password)
        {
            txtProfilePassword.SendKeys(password);
        }
        private void ClickLogIn()
        {
            btnLogin.Click();
        }
        private void ConfirmLogut()
        {
            lnkConfirmLogout.Click();
        }
        private void ClickCreateAccount()
        {
            btnCreateAccount.Click();
        }
        private void ClickLogOut()
        {
            lnkLogout.Click();
        }



        public void LogintoApp(string emailid, string password)
        {
            EnterUserName(emailid);
            EnterPassword(password);
            ClickLogIn();
            Wait.WaitForLoad(_driver, By.LinkText("Manage Products"));
        }

        public void CreateAccount()
        {
            Wait.WaitForLoad(_driver, By.PartialLinkText("CREATE ACCOUNT"));
            ClickCreateAccount();
        }

        public void LogoutApp()
        {
            if (_driver.WindowHandles.Count > 1)
            {
                _driver.SwitchTo().Window(_driver.WindowHandles[1]).Close();
                _driver.SwitchTo().Window(_driver.WindowHandles[0]);
            }
            Wait.WaitForLoad(_driver, By.PartialLinkText("Log Out"));
            ClickLogOut();
            try
            {
                if (lnkConfirmLogout.Displayed)
                    ConfirmLogut();
            }
            catch (System.Exception)
            {
                Console.WriteLine("No Confirm logout");
            }
            _driver.Manage().Cookies.DeleteAllCookies();
            Wait.WaitForLoad(_driver, By.XPath("//span[contains(text(), 'Log In / Create Account')]"));

        }

        public void LogoutLogin(string username, bool quit, string pass)
        {
            LogoutApp();
            if (quit)
            {
                _driver.Quit();
                //OpenURL();
                Wait.DefaultWait(3);
            }
            Wait.DefaultWait(3);
            LogintoApp(username, pass);
        }


    }
}
