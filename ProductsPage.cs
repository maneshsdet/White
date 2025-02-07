using CommonComponents;
using KeyManagementATDDTests.Support;
using OpenQA.Selenium;

namespace KeyManagementATDDTests.Pages
{
    public class ProductsPage : TestVariables
    {
        public ProductsPage(IWebDriver driver) => _driver = driver;
        //locator for Browse Products

        //locator for search

        private IWebElement txtQuantity => _driver.FindElement(By.Id("quantity"));
        // private IWebElement Cart => _driver.FindElement(By.XPath("//span[contains(text(), 'Cart (')]"));
        private IWebElement btnSiteSearch => _driver.FindElement(By.XPath("//span[contains(text(), 'Search')]"));
        //locator for entering product
        private IWebElement txtCartEnterProduct => _driver.FindElement(By.Id("site-search-editable-div"));
        private IWebElement txtEnterProduct => _driver.FindElement(By.Id("searchtext"));
        //Locater for search product
        //private IWebElement ProductSearch => _driver.FindElement(By.XPath("//button[@class='site-search-btn-submit']"));
        private IWebElement btnProductSearch => _driver.FindElement(By.ClassName("header-search-submit"));
        //private IWebElement CartProductSearch => _driver.FindElement(By.Id("site-search-editable-div"));
        private IWebElement btnCartProductSearch => _driver.FindElement(By.ClassName("nra-search-button"));
        //ClickProduct
        private IWebElement lnkProduct => _driver.FindElement(By.PartialLinkText("VIEW PRODUCT"));
        //Locator for Add to cart
        private IWebElement btnAddToCart => _driver.FindElement(By.XPath("//button[@class='cart-add-to-cart-button-button']"));
        private IWebElement txtCouponCode => _driver.FindElement(By.Name("promocode"));
        //locator for Apply Coupon
        private IWebElement btnApplyCoupon => _driver.FindElement(By.XPath("//button[@class='cart-promocode-form-summary-button-apply-promocode']"));

        private IWebElement btnCheckout => _driver.FindElement(By.PartialLinkText("CHECKOUT"));


        //Action methods on Page Elements
        private void ClickViewProduct()
        {
            lnkProduct.Click();
        }
        private void EnterQty(string qty)
        {
            txtQuantity.SendKeys(qty);
        }
        private void AddToCart()
        {
            btnAddToCart.Click();
        }
        private void ClickCheckout()
        {
            btnCheckout.Click();
        }
        public void EIProduct(List<string> productslist, int quantity)
        {

            ProductAdd(productslist, quantity);

        }
        public void ProductAdd(List<string> productslist, int quantity)
        {

            Wait.WaitForLoad(_driver, By.PartialLinkText("VIEW PRODUCT"));
            ClickViewProduct();
            Wait.WaitForLoad(_driver, By.Id("quantity"));
            WebElementHelper.FieldClearThanEnterText(txtQuantity, quantity.ToString());
            txtQuantity.SendKeys(Keys.Tab);
            AddToCart();
            Wait.WaitForLoad(_driver, By.PartialLinkText("CHECKOUT")); //stale element exception
            ClickCheckout();

        }
    }
}


