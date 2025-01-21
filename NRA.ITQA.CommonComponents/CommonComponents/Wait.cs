using iText.Layout.Splitting;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Threading;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace CommonComponents
{
    public static class Wait
    {
        //public static bool WaitForElementDispalyed(this IWebDriver driver,IWebElement webElement, int timeoutInSeconds) => timeoutInSeconds > 0 ? new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(drv => webElement.Displayed) : new WebDriverWait(driver, TimeSpan.FromSeconds(30.0)).Until(drv => webElement.Displayed);
        public static bool WaitForElementDispalyed(this IWebDriver driver, IWebElement webElement, int timeoutInSeconds)
        {
            DefaultWait(2);
            return timeoutInSeconds > 0 ? new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(drv => webElement.Displayed) : new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(drv => webElement.Displayed);
        }

        public static bool WaitForElementEnabled(this IWebDriver driver, IWebElement webElement, int timeoutInSeconds)
        {
            DefaultWait(2);
            return timeoutInSeconds > 0 ? new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(drv => webElement.Enabled) : new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(drv => webElement.Enabled);
        }
        public static bool WaitForElementClickable(this IWebDriver driver, IWebElement webElement, int timeoutInSeconds)
        {
            DefaultWait(2);
            return timeoutInSeconds > 0 ? new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(drv => webElement.Displayed && webElement.Enabled) : new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(drv => webElement.Displayed && webElement.Enabled);
        }
        public static bool WaitForElementAttribute(this IWebDriver driver, IWebElement webElement, int timeoutInSeconds, string attribute, string value)
        {
            return timeoutInSeconds > 0 ? new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(drv => webElement.GetAttribute(attribute).Equals(value)) : new WebDriverWait(driver, TimeSpan.FromSeconds(30.0)).Until(drv => webElement.GetAttribute(attribute).Equals(value));
        }
        //public static IWebElement WaitForElementClickable(IWebDriver driver, IWebElement element, int timeoutInSeconds = 90)
        //{
        //    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        //    return wait.Until(ExpectedConditions.ElementToBeClickable(element));
        //}
        public static bool WaitForElementAttributeContains(this IWebDriver driver, IWebElement webElement, int timeoutInSeconds, string attribute, string value)
        {
            return timeoutInSeconds > 0 ? new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(drv => webElement.GetAttribute(attribute).Contains(value)) : new WebDriverWait(driver, TimeSpan.FromSeconds(30.0)).Until(drv => webElement.GetAttribute(attribute).Contains(value));
        }

        public static void DefaultWait(int timeoutInSeconds) => Thread.Sleep(TimeSpan.FromSeconds(timeoutInSeconds));

        public static IAlert WaitGetAlert(this IWebDriver driver, int waitTimeInSeconds = 5)
        {
            IAlert alert = null;

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeInSeconds));

            try
            {
                alert = wait.Until(d =>
                {
                    try
                    {
                        // Attempt to switch to an alert
                        return driver.SwitchTo().Alert();
                    }
                    catch (NoAlertPresentException)
                    {
                        // Alert not present yet
                        return null;
                    }
                });
            }
            catch (WebDriverTimeoutException) { alert = null; }

            return alert;
        }

        public static void ExplicitWait(IWebDriver _driver, IWebElement webElement)
        {
            // WaitForLoad(_driver);
            for (int k = 0; k < 20; k++)
            {
                try
                {
                    if (WaitForElementDispalyed(_driver, webElement, 20))
                        break;
                    else if (WaitForElementClickable(_driver, webElement, 20))
                        break;
                    else if (WaitForElementEnabled(_driver, webElement, 20))
                        break;
                }
                catch (Exception)
                {
                    DefaultWait(5);
                }
            }
        }

        public static void WaitForLoad(IWebDriver driver, By locator, int timeoutSec = 45)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutSec));
                try
                {
                    wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                }
                catch (Exception)
                {
                    wait.Until(ExpectedConditions.ElementIsVisible(locator));
                }

            }
            catch (Exception)
            {
                Wait.DefaultWait(5);
            }
        }

        public static void WaitForElementInvisible(IWebDriver driver, By locator, int timeoutSec = 45)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutSec));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
            }
            catch (Exception)
            {
                Wait.DefaultWait(5);
            }
        }
    }
}
