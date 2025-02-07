using CommonComponents;
using KeyManagementATDDTests.Support;
using OpenQA.Selenium;

namespace KeyManagementATDDTests.Pages
{
    public class MyAccountPage : TestVariables
    {
        public MyAccountPage(IWebDriver driver) => _driver = driver;
        //locator for CreateAccount
        public IWebElement lnkManageProducts => _driver.FindElement(By.Id("id_manage_products"));
        public IWebElement btnHome => _driver.FindElement(By.XPath("//a[contains(@href,'ahlei.servsafebrands.com')]"));

        //Action methods on Page Elements
        private void ClickManageProducts()
        {
            JavaScript.JsClick(_driver, lnkManageProducts);
        }
        private void ClickHome()
        {
            btnHome.Click();
        }
        public void ManageProducts()
        {
            Wait.WaitForLoad(_driver, By.Id("id_manage_products"));
            ClickManageProducts();
        }
        public void Home()
        {
            Wait.WaitForLoad(_driver, By.PartialLinkText("Home"));
            ClickHome();
        }

    }
}
