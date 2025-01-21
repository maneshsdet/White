using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection;
using System.Security.Principal;

namespace CommonComponents
{
    public static class SSShoppingCartPage
    {


        public static string OrderNumber { get; set; }

        public static string ServSafePurchase(IWebDriver _driver)
        {

            try
            {
                string currentURL = _driver.Url;

                // WebElementHelper.FieldClearThanEnterText(ShippingTo, AccountInfo["FirstName"] + " " + AccountInfo["LastName"]);

                //WebElementHelper.FieldClearThanEnterText(ShippingCompany, "NRA");
                //WebElementHelper.FieldClearThanEnterText(NRARegressionPage.ShoppingCartPage.getShippingAddressOne(), CheckOutValue("shippingFax"));

                if (currentURL.Contains("servsafeinternational.com/access/ssi/Order/Checkout"))
                {
                    Wait.WaitForElementClickable(_driver, _driver.FindElement(By.Id("btnDisableLeft")), 20);
                    _driver.FindElement(By.Id("btnDisableLeft")).Click();
                    Wait.DefaultWait(5);
                }
                else if (currentURL.Contains("restaurant.org/access/FRMCA/Order/Checkout"))
                {
                    Wait.WaitForElementClickable(_driver, _driver.FindElement(By.Id("btnDisableLeft")), 20);
                    _driver.FindElement(By.Id("btnDisableLeft")).Click();
                    Wait.DefaultWait(5);
                }
                else
                {
                    Wait.WaitForElementClickable(_driver, _driver.FindElement(By.Id("btnDisableLeft")), 20);
                    try
                    {
                        _driver.FindElement(By.Id("btnDisableLeft")).Click();
                    }
                    catch (Exception)
                    {
                        JavaScript.JsClick(_driver, _driver.FindElement(By.Id("btnDisableLeft")));
                    }
                    Wait.DefaultWait(5);
                }


                try
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (_driver.FindElement(By.Id("keepMine")).Displayed)
                        {
                            _driver.FindElement(By.Id("keepMine")).Click();
                            break;
                        }
                        else
                        {
                            Wait.DefaultWait(2);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("no address validation pop");
                }

                Wait.DefaultWait(3);

                int purchaseOrder = new SelectElement(_driver.FindElement(By.Id("PaymentMethodDropDownList"))).Options.Count;

                if (purchaseOrder > 4)
                {
                    new SelectElement(_driver.FindElement(By.Id("PaymentMethodDropDownList"))).SelectByText("PO (Purchase Order)");
                    _driver.FindElement(By.Id("CompanyId")).SendKeys("5782");
                    _driver.FindElement(By.Id("PONumber")).SendKeys("5782");
                    Wait.DefaultWait(5);
                    string totalCreditCell = _driver.FindElement(By.Id("totalCreditCell")).Text;
                    Wait.DefaultWait(5);
                    string remainingCreditCell = _driver.FindElement(By.Id("remainingCreditCell")).Text;

                    Console.WriteLine("total credit cell: " + totalCreditCell + " remaining credit card: " + remainingCreditCell);
                }
                else
                {

                    //shop.getPaymentMethod().SelectByIndex(1);
                    WebElementHelper.FieldClearThanEnterText(_driver.FindElement(By.Id("CreditCardNumber")), Constants.Properties["CCNumber"]);
                    WebElementHelper.FieldClearThanEnterText(_driver.FindElement(By.Id("CreditCardCVV")), Constants.rand.Next(101, 999).ToString());
                    new SelectElement(_driver.FindElement(By.Id("CreditCardExpirationYear"))).SelectByIndex(2);
                    Wait.DefaultWait(2);
                    //NRARegressionPage.ShoppingCartPage.getNameOnCard().SendKeys(CheckOutValue("nameOnCard"));
                    //NRARegressionPage.ShoppingCartPage.getBillingCompany().SendKeys(CheckOutValue("billingCompnay"));
                    //NRARegressionPage.ShoppingCartPage.getBillingCountry().SelectByText(CheckOutValue("billingCountry"));
                    //NRARegressionPage.ShoppingCartPage.getBillingAddressOne().SendKeys(CheckOutValue("billingAddress1"));
                    //NRARegressionPage.ShoppingCartPage.getBillingCity().SendKeys(CheckOutValue("billingCity"));
                    //// shop.getBillingState().SelectByText(ServsafeManagerMyCartValue("billingState"));
                    //NRARegressionPage.ShoppingCartPage.getBillingZipCode().SendKeys(CheckOutValue("billingZipCode"));

                    //ForceWait(5, "sate field is being pain in.....");

                    ////IWebElement element = _driver.FindElement(By.Id("Cart_Billing_StateProvince"));

                    ////Actions action = new Actions(_driver);
                    ////action.MoveToElement(element).Click();
                    ////action.SendKeys(CheckOutValue("billingState"));
                    ////action.SendKeys(Keys.Return).Build().Perform();

                    //NRARegressionPage.ShoppingCartPage.getBillingState().SelectByText(CheckOutValue("billingState"));
                }
                JavaScript.JsClick(_driver, _driver.FindElement(By.Id("r2")));
                Wait.DefaultWait(2);
                JavaScript.JsClick(_driver, _driver.FindElement(By.Id("btnConfirmBilling")));
                Wait.DefaultWait(2);
                _driver.FindElement(By.Id("AdditionalEmailAddress")).SendKeys(WindowsIdentity.GetCurrent().Name.Split('\\')[1] + "@restaurant.org");

                //ForceWait(5, "check everything");

                WebElementHelper.FieldClearThanEnterText(_driver.FindElement(By.Id("Cart_CouponCode")), Constants.Properties["CouponCode"]);
                _driver.FindElement(By.Id("btnCouponAdd")).Click();

                Wait.DefaultWait(3);

                string CheckoutURL = _driver.Url;
                try
                {
                    if (_driver.FindElement(By.Id("ddlShipMethod")).Displayed)
                    {
                        if ((CheckoutURL != "https://www.servsafe.com/access/SS/Order/Checkout#all-review") && (CheckoutURL != "https://textbooks.restaurant.org/access/FRMCA/Order/Checkout#all-review")
                            && (CheckoutURL != "https://www.servsafeinternational.com/access/ssi/Order/Checkout"))
                        {
                            // Console.WriteLine(" SS PROD URL dected. shipment product will not purchased. exit will exit out.");
                            //new SelectElement(By.XPath(".//*[@id='ddlShipMethod']")).SelectByIndex(1);
                            //ForceWait(3, "wait for the shipping price to get updated");
                        }
                        else
                        {
                            // Assert.Fail("ALERT! ALERT! PROD URL detected. Shipment products will be not purchased. ");
                            //Console.WriteLine(" ");
                        }
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("No Shipping Method Exists");
                }

                Wait.DefaultWait(3);

                _driver.FindElement(By.XPath(".//*[@id='btnCheckOut']")).Click();
                Wait.DefaultWait(5);
                try
                {
                    JavaScript.JsClick(_driver, _driver.FindElement(By.XPath("//button[contains(.,'×')]")));
                    Wait.DefaultWait(2);
                }
                catch (Exception)
                {
                    Console.WriteLine("No Pop Up");
                }
                if (_driver.Url.Contains("servsafe.com/access/SS/Order/CheckOut"))
                {
                    Wait.DefaultWait(5);
                    OrderNumber = _driver.FindElement(By.XPath("//div[contains(@class,'alert alert-success alert-dismissible')]/p/span")).Text;
                }
                else if (_driver.Url.Contains("textbooks.restaurant.org/access/FRMCA/Order/CheckOut"))
                {
                    Wait.DefaultWait(5);
                    OrderNumber = _driver.FindElement(By.XPath(".//*[@id='ProStartFunctional']/div/div/div/div[2]/span")).Text;
                }
                else if (_driver.Url.Contains("servsafeinternational.com/access/ssi/Order/CheckOut"))
                {
                    Wait.DefaultWait(5);
                    OrderNumber = _driver.FindElement(By.XPath(".//*[@id='content']/div/div[2]/span")).Text;
                }

                FileOperations.WriteToFile("ProdOrderID.txt", "order placed successfully: " + OrderNumber);
                return OrderNumber;
            }
            catch (Exception e)
            {
                Assertions.FailCase(MethodBase.GetCurrentMethod().Name, e.Message, _driver);
                return null;
            }
        }
    }
}
