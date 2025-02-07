using CommonComponents;
using KeyManagementATDDTests.Pages;
using KeyManagementATDDTests.Support;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetSuite.Main.pom.nra.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Pj.Library;
using Selenium.Essentials;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace KeyManagmentBDDTests.StepDefinitions
{
    [Binding]
    public class PBI24351 : TestVariables
    {
        public PBI24351(IWebDriver driver) => _driver = driver;
        HomePage homePage = new HomePage(_driver);
        LoginPage loginPage = new LoginPage(_driver);
        MyAccountPage myAccountPage = new MyAccountPage(_driver);
        ManageProductsPage manageProductsPage = new ManageProductsPage(_driver);
        [Given(@"I'm a logged in student/trainer/proctor/instructor")]
        public void GivenImALoggedInStudentTrainerProctorInstructor()
        {

            homePage.Login_CreateAccount();
            loginPage.LogintoApp(Properties["Student"], Properties["StudentPassword"]);

        }

        [Given(@"I'm on the Manage Products page")]
        public void GivenImOnTheManageProductsPage()
        {
            myAccountPage.ManageProducts();
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
        }

        [Given(@"I have previously purchased/transferred non-inventory products/kits that contain non-inventory products")]
        public void GivenIHavePreviouslyPurchasedTransferredNon_InventoryProductsKitsThatContainNon_InventoryProducts()
        {
            Console.WriteLine("Test2");
        }

        [Given(@"I have products with all keys that are expired or redeemed")]
        public void GivenIHaveProductsWithAllKeysThatAreExpiredOrRedeemed()
        {
            Console.WriteLine("Test2");
        }

        [When(@"I check the Display archived or expired products checkbox")]
        public void WhenICheckTheDisplayArchivedOrExpiredProductsCheckbox()
        {
            Wait.WaitForLoad(_driver, By.Id("display-archive-overview"));
            manageProductsPage.btnArchive_ExpiredProdcuts.Click();
            Wait.DefaultWait(10);
        }

        [Then(@"The products with only keys in Expired or Redeemed status will display, in addition to the active products that are displayed")]
        public void ThenTheProductsWithOnlyKeysInExpiredOrRedeemedStatusWillDisplayInAdditionToTheActiveProductsThatAreDisplayed()
        {
            Assert.AreEqual(int.Parse(Properties["AssignedCount"]) + int.Parse(Properties["ReedemedCount"]), manageProductsPage.AssignedState.Count);
        }

        [When(@"I uncheck the Display archived or expired products checkbox")]
        public void WhenIUncheckTheDisplayArchivedOrExpiredProductsCheckbox()
        {
            Wait.WaitForLoad(_driver, By.Id("display-archive-overview"));
            Assert.IsFalse(manageProductsPage.btnArchive_ExpiredProdcuts.Selected);
        }

        [Then(@"the products with only Expired or Redeemed keys are not displayed and the active products will remain displayed")]
        public void ThenTheProductsWithOnlyExpiredOrRedeemedKeysAreNotDisplayedAndTheActiveProductsWillRemainDisplayed()
        {
            Assert.AreEqual(int.Parse(Properties["AssignedCount"]), manageProductsPage.AssignedState.Count);
        }

        [Given(@"I'm logged in (.*)")]
        public void GivenImALoggedInNraregression_AnnaGmail_Com(string user)
        {
            HomePage homePage = new HomePage(_driver);
            loginPage.LogintoApp(Properties["" + user + ""], Properties["StudentPassword"]);
        }

    }
}

