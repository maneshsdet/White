using CommonComponents;
using KeyManagementATDDTests.Support;
using OpenQA.Selenium;

namespace KeyManagementATDDTests.Pages
{
    public class ShoppingCartPage : TestVariables
    {
        public ShoppingCartPage(IWebDriver driver) => _driver = driver;
        private IWebElement btnProceedToCheckout => _driver.FindElement(By.Id("btn-proceed-checkout"));
        private IWebElement btnContinue => _driver.FindElement(By.XPath("//button[@class='order-wizard-step-button-continue']"));
        private IWebElement btnShipMethod(int i)
        {
            return _driver.FindElements(By.XPath("//span[@class='order-wizard-shipmethod-module-option-name']"))[i];
        }
        //Action methods on Page Elements
        private void ClickProceedCheckout()
        {
            btnProceedToCheckout.Click();
        }
        private void ClickShippingMethod(int i)
        {
            btnShipMethod(i).Click();
        }
        private void ClickContinue()
        {
            btnContinue.Click();
        }
        public void ProccedToCheckout()
        {
            Wait.WaitForLoad(_driver, By.Id("btn-proceed-checkout"));
            ClickProceedCheckout();
        }

    }
}
