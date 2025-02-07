     using CommonComponents;
using KeyManagementATDDTests.Pages;
using KeyManagementATDDTests.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
   
namespace KeyManagmentBDDTests.StepDefinitions
{

    [Binding]
    public class PBI24502 : TestVariables
    {
        public PBI24502(IWebDriver driver) => _driver = driver;
        ManageProductsPage manageProductsPage = new ManageProductsPage(_driver);
        [Given(@"I own non-inventory products/kits that contain non-inventory products")]
        public void GivenIOwnNon_InventoryProductsKitsThatContainNon_InventoryProducts()
        {
            Console.WriteLine("Get Products");
        }

        [When(@"I view the Manage Products page")]
        public void WhenIViewTheManageProductsPage()
        {
            Console.WriteLine("on Manage Products Page");
        }
        [Then(@"I will see a count of my products displayed and a count for my total products, x of y products displayed")]
        public void ThenIWillSeeACountOfMyProductsDisplayedAndACountForMyTotalProductsXOfYProductsDisplayed()
        {
            Wait.WaitForLoad(_driver, By.XPath("//div[@class = 'overview-product-display']"));
            StringAssert.Contains("5 of", manageProductsPage.txtProductsTotals.Text);
            //Assertions.Contains(manageProductsPage.txtProductsTotals.Text, "5 of");
        }

        [Given(@"I have more than ""([^""]*)"" products to display")]
        public void GivenIHaveMoreThanProductsToDisplay(string p0)
        {
            Wait.WaitForLoad(_driver, By.XPath("//div[@class = 'overview-product-display']"));
            int productscount = int.Parse(manageProductsPage.txtProductsTotals.Text.Split("of ")[1].Split(" ")[0]);
            Assert.IsTrue(productscount > int.Parse(p0));
        }


        [Given(@"the ""([^""]*)"" button is visible")]
        public void GivenTheButtonIsVisible(string p0)
        {
            Wait.WaitForLoad(_driver, By.XPath("//button[contains(text(),'" + p0 + "')]"));
            Assert.IsTrue(manageProductsPage.LoadMore(p0).Displayed);
        }

        [When(@"I click the ""([^""]*)"" button")]
        public void WhenIClickTheButton(string p0)
        {
            manageProductsPage.ClickLoadMore(p0);
            //Wait.WaitForLoad(_driver, By.XPath("//button[contains(text(),'" + p0 + "')]"));
            Wait.WaitForElementInvisible(_driver, By.XPath("//div[contains(@class,'loading-spinner')]"));
        }

        [Then(@"the page will use ""([^""]*)"" to display (.*) additional products")]
        public void ThenThePageWillUseToDisplayAdditionalProducts(string p0, int p1)
        {
            Console.WriteLine("Lazy Loading");
        }

        [Then(@"the ""([^""]*)"" count is updated in the ""([^""]*)"" at the top of the page")]
        public void ThenTheCountIsUpdatedInTheAtTheTopOfThePage(string x, string p1)
        {
            int productscount = int.Parse(manageProductsPage.txtProductsTotals.Text.Split(" of")[0]);
            Assert.IsTrue(productscount > 5);
        }

        [Then(@"I can click ""([^""]*)"" until all products are displayed")]
        public void ThenICanClickUntilAllProductsAreDisplayed(string p0)
        {
            double totalcount = int.Parse(manageProductsPage.txtProductsTotals.Text.Split("of ")[1].Split(" ")[0]);
            for (int i = 1; i < Math.Floor(totalcount / 5); i++)
            {

                Assert.IsTrue(manageProductsPage.LoadMore(p0).Displayed);
                manageProductsPage.ClickLoadMore(p0);
                if (i != Math.Floor(totalcount / 5) - 1)
                    Wait.WaitForLoad(_driver, By.XPath("//button[contains(text(),'" + p0 + "')]"));
            }
            Assert.IsTrue(_driver.FindElements(By.XPath("//button[contains(text(),'" + p0 + "')]")).Count == 0);
        }



    }
}

