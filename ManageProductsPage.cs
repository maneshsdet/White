using CommonComponents;
using KeyManagementATDDTests.Support;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace KeyManagementATDDTests.Pages
{
    public class ManageProductsPage : TestVariables
    {

        public ManageProductsPage(IWebDriver driver) => _driver = driver;
        public IWebElement btnArchive_ExpiredProdcuts => _driver.FindElement(By.Id("display-archive-overview"));
        public IWebElement txtProductsTotals => _driver.FindElement(By.XPath("//div[@class = 'overview-product-display']"));
        public IWebElement LoadMore(string label)
        {
            return _driver.FindElement(By.XPath("//button[contains(text(),'" + label + "')]"));
        }

        public void ClickLoadMore(string label)
        {
            JavaScript.JsClick(_driver, LoadMore(label));
        }
        public ReadOnlyCollection<IWebElement> AssignedState => _driver.FindElements(By.XPath("//div[contains(@id,'keyoverview-disabledPopup-assign')]"));
    }
}
