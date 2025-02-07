using CommonComponents;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeyManagementATDDTests.Pages
{

    public class CheckoutPage
    {
        private IWebDriver _driver;
        public CheckoutPage(IWebDriver driver) => _driver = driver;

        private IWebElement txtBillingFName => _driver.FindElement(By.Name("billing_first_name"));
        private IWebElement txtBillingLName => _driver.FindElement(By.Name("billing_last_name"));
        private IWebElement txtBillingAddress1 => _driver.FindElement(By.Name("billing_address_1"));
        private IWebElement txtBillingAddress2 => _driver.FindElement(By.Name("billing_address_2"));
        private IWebElement txtBillingCity => _driver.FindElement(By.Name("billing_city"));
        private IWebElement txtBillingCountry => _driver.FindElement(By.Id("select2-billing_country-container"));
        private IWebElement btnBillingState => _driver.FindElement(By.Id("select2-billing_state-container"));
        private IWebElement txtBillingZip => _driver.FindElement(By.Name("billing_postcode"));
        private IWebElement txtBillingPhone => _driver.FindElement(By.Name("billing_phone"));
        private IWebElement btnTerms => _driver.FindElement(By.Id("terms"));
        private IWebElement btnPlaceOrder => _driver.FindElement(By.Id("place_order"));
        private IWebElement lstSelectCountry(string country)
        {
            return _driver.FindElement(By.XPath("//ul[@id='select2-billing_country-results']/li[.='" + country + "']"));
        }
        private IWebElement lstSelectState(string state)
        {
            return _driver.FindElement(By.XPath("//ul[@id='select2-billing_state-results']/li[.='" + state + "']"));
        }

        public void CheckOut()
        {
            try
            {
                Wait.ExplicitWait(_driver, txtBillingFName);
                WebElementHelper.FieldClearThanEnterText(txtBillingFName, "NRAFST_" + DateTimeStamp.getTimeStamp("yyyyMMddHHmmss"));
                WebElementHelper.FieldClearThanEnterText(txtBillingLName, "NRALST_" + DateTimeStamp.getTimeStamp("yyyyMMddHHmmss"));
                txtBillingCountry.Click();
                lstSelectCountry("United States (US)").Click();
                var RandState = SharedData.RandomState();
                WebElementHelper.FieldClearThanEnterText(txtBillingAddress1, SharedData.GetAddress()[RandState].Item1);
                WebElementHelper.FieldClearThanEnterText(txtBillingAddress2, SharedData.GetAddress()[RandState].Item2);
                WebElementHelper.FieldClearThanEnterText(txtBillingCity, SharedData.GetAddress()[RandState].Item3);
                btnBillingState.Click();
                lstSelectState(RandState).Click();
                WebElementHelper.FieldClearThanEnterText(txtBillingZip, SharedData.GetAddress()[RandState].Item4.ToString());
                WebElementHelper.FieldClearThanEnterText(txtBillingPhone, PhoneNumberGenerator.PhoneNumber());
                //JavaScript.JsEnter(_driver, CardNumber, SharedData.CC());
                //JavaScript.JsEnter(_driver, CardNumber, "4111 1111 1111 1111");
                //JavaScript.JsEnter(_driver, CardExpiry, DateTime.Now.AddDays(Constants.rand.Next(101, 365)).ToString("MM / yy"));
                //CardCode.SendKeys(Constants.rand.Next(101, 999).ToString());
                Wait.DefaultWait(5);
                btnTerms.Click();
                btnPlaceOrder.Click();
                //Wait.WaitForElementDispalyed(_driver, _driver.FindElement(By.XPath("//p[@class='woocommerce-notice woocommerce-notice--success woocommerce-thankyou-order-received']")), 20);
                Wait.DefaultWait(180);
            }
            catch (Exception)
            {
                Console.WriteLine("Checkout Error");
            }
        }
    }
}
