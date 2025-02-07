using CommonComponents;
using KeyManagementATDDTests.Pages;
using KeyManagementATDDTests.Support;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace KeyManagementATDDTests.StepDefinitions
{
    [Binding]
    public class PBI24609 : TestVariables
    {
        //private IWebDriver _driver;
        public PBI24609(IWebDriver driver) => _driver = driver;
        public static List<string> EIProducts = WebElementHelper.ListItems(Properties["Products1"], ",");
        HomePage homePage = new HomePage(_driver);
        LoginPage loginPage = new LoginPage(_driver);
        MyAccountPage myAccountPage = new MyAccountPage(_driver);
        ProductsPage productsPage = new ProductsPage(_driver);
        ShoppingCartPage shoppingCartPage = new ShoppingCartPage(_driver);
        PaymentPage paymentPage = new PaymentPage(_driver);
        [Given(@"a product has been purchased")]
        public void GivenAProductHasBeenPurchased()
        {
            homePage.Login_CreateAccount();
            loginPage.LogintoApp(Properties["Student"], Properties["StudentPassword"]);
            myAccountPage.Home();
            homePage.SearchProducts(EIProducts);
        }

        [When(@"the key is assigned")]
        public void WhenTheKeyIsAssigned()
        {
            productsPage.EIProduct(EIProducts, 1);
            shoppingCartPage.ProccedToCheckout();
            paymentPage.CCInfoPlaceOrder();
        }

        [Then(@"I can see my product in the Crowd Wisdom dashboard")]
        public void ThenICanSeeMyProductInTheCrowdWisdomDashboard()
        {
            Console.WriteLine("Purchased2");
        }

    }
}
