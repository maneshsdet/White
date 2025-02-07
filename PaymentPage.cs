using CommonComponents;
using KeyManagementATDDTests.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace KeyManagementATDDTests.Pages
{
    public class PaymentPage : TestVariables
    {
        public PaymentPage(IWebDriver driver) => _driver = driver;
        private IWebElement btnCC_Debit => _driver.FindElement(By.XPath("//a[contains(text(), 'Credit / Debit Card')]"));
        private IWebElement btnContinue => _driver.FindElement(By.PartialLinkText("CONTINUE"));
        private IWebElement btnPlaceOrder => _driver.FindElement(By.PartialLinkText("PLACE ORDER"));
        private IWebElement txtOrderNumber => _driver.FindElement(By.XPath("//a[@class='ordernumber-link']"));

        private IWebElement txtCCName => _driver.FindElement(By.Id("ccname"));
        private IWebElement txtCCNumber => _driver.FindElement(By.Id("ccnumber"));
        private IWebElement txtCVV => _driver.FindElement(By.Id("ccsecuritycode"));
        private IWebElement chkSaveCC => _driver.FindElement(By.Id("savecreditcard"));
        private SelectElement lstExpYear => new SelectElement(_driver.FindElement(By.Id("expyear")));
        //Action methods on Page Elements
        private void ClickPlaceOrder()
        {
            btnPlaceOrder.Click();
        }
        private void ClickContinue()
        {
            btnContinue.Click();
        }
        private void ClickSaveCC()
        {
            chkSaveCC.Click();
        }
        private void EnterCCName(string ccname)
        {
            txtCCName.SendKeys(ccname);
        }
        private void SelectExpYear(int option)
        {
            lstExpYear.SelectByIndex(option);
        }
        public void CCInfoPlaceOrder()
        {
            Wait.WaitForLoad(_driver, By.Id("ccname"));
            FName = txtCCName.GetAttribute("value");
            WebElementHelper.FieldClearThanEnterText(txtCCName, FName.Split(" ")[0]);
            WebElementHelper.FieldClearThanEnterText(txtCCNumber, Properties["CCNumber"]);
            SelectExpYear(2);
            WebElementHelper.FieldClearThanEnterText(txtCVV, rand.Next(101, 999).ToString());
            if (chkSaveCC.Selected)
                ClickSaveCC();
            Wait.WaitForLoad(_driver, By.PartialLinkText("CONTINUE"));
            ClickContinue();
            Wait.WaitForLoad(_driver, By.PartialLinkText("PLACE ORDER"));
            ClickPlaceOrder();
            Wait.WaitForLoad(_driver, By.XPath("//a[@class='ordernumber-link']"));
            Assert.IsNotNull(txtOrderNumber.Text);
        }
    }
}
