using CommonComponents;
using KeyManagementATDDTests.Support;
using OpenQA.Selenium;

namespace KeyManagementATDDTests.Pages
{
    public class HomePage : TestVariables
    {
        // private IWebDriver _driver;
        public HomePage(IWebDriver driver) => _driver = driver;
        public IWebElement btnSignIn => _driver.FindElement(By.XPath("//span[contains(text(), 'Log In / Create Account')]"));
        private IWebElement btnSiteSearch => _driver.FindElement(By.XPath("//span[contains(text(), 'Search')]"));
        private IWebElement txtCartEnterProduct => _driver.FindElement(By.Id("site-search-editable-div"));
        private IWebElement txtEnterProduct => _driver.FindElement(By.Id("searchtext"));
        private IWebElement btnProductSearch => _driver.FindElement(By.ClassName("header-search-submit"));
        private IWebElement btnCartProductSearch => _driver.FindElement(By.ClassName("nra-search-button"));

        private void ClickSiteSearch()
        {
            btnSiteSearch.Click();
        }
        private void CartProductSearch()
        {
            btnCartProductSearch.Click();
        }
        private void ClickProductSearch()
        {
            btnProductSearch.Click();
        }
        private void EnterProduct(string product)
        {
            txtEnterProduct.SendKeys(product);
        }
        public void ClickSignIn()
        {
            btnSignIn.Click();
        }
        public void Login_CreateAccount()
        {
            Wait.WaitForLoad(_driver, By.XPath("//span[contains(text(), 'Log In / Create Account')]"));
            ClickSignIn();
            Wait.WaitForLoad(_driver, By.LinkText("LOG IN"));
        }
        public void SearchProducts(List<string> productslist)
        {
            Wait.WaitForLoad(_driver, By.PartialLinkText("Redeem Voucher"));
            ClickSiteSearch();
            foreach (var item in productslist)
            {
                EnterProduct(SharedData.EIProductsdict()[item].Item2); //Product SKU stored in Common Components Shared Data
                ClickProductSearch();
            }

        }
    }
}
