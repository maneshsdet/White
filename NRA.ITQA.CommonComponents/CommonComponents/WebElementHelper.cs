using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CommonComponents
{
    public static class WebElementHelper
    {
        public static bool IsDisplayed(IWebElement webElement)
        {
            try
            {
                _ = webElement.Displayed;
                return true;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine();
            }
            return false;
        }

        public static bool IsElementPresent(IWebElement webElement)
        {
            try
            {
                _ = webElement;
                return true;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine();
            }

            return false;
        }

        public static void FieldClearThanEnterText(IWebElement webElement, string text)
        {
            webElement.Clear();
            webElement.SendKeys(text);

        }

        public static IList<IWebElement> WebTable(IWebDriver driver, IWebElement tableElement)
        {
            IList<IWebElement> rows = tableElement.FindElements(By.TagName("tr"));
            return rows;
        }

        public static void SelectDropdownByPartialText(SelectElement selectElement, string partialText)
        {
            IList<IWebElement> optionList = selectElement.Options;
            foreach (var option in optionList)
            {
                if (option.Text.Contains(partialText))
                {
                    selectElement.SelectByText(option.Text);
                    break;
                }
            }
        }

        public static void AlertAccept(IWebDriver _driver)
        {
            try
            {
                _driver.SwitchTo().Alert().Accept();
                Wait.DefaultWait(3);
            }
            catch (Exception)
            {
                Console.WriteLine("No Alert");
            }
        }

        public static void CloseModelPopup(IWebDriver _driver)
        {
            try
            {
                Wait.WaitForElementClickable(_driver, _driver.FindElement(By.XPath("//*[@id='ProductAlert2']/div[@class='foundry_modal reveal-modal']/span[@class='close-modal']")), 20);
                _driver.FindElement(By.XPath("//*[@id='ProductAlert2']/div[@class='foundry_modal reveal-modal']/span[@class='close-modal']")).Click();
            }
            catch (Exception)
            {
                Console.WriteLine("No Close Modal");
            }
        }

        public static string ToTitleCase(string title)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title.ToLower());
        }

        public static void StonlyWidget(IWebDriver _driver)
        {
            try
            {
                Actions action = new Actions(_driver);
                action.MoveToElement(_driver.FindElement(By.XPath("//div[@aria-label='Close Stonly widget']"))).Perform();
                Wait.WaitForElementDispalyed(_driver, _driver.FindElement(By.XPath("//div[@aria-label='Close Stonly widget']")), 30);
                _driver.FindElement(By.XPath("//div[@aria-label='Close Stonly widget']")).Click();
            }
            catch (Exception)
            {
                Console.WriteLine("No Stonley Widget");
            }
        }

        public static List<string> ListItems(string item, string deliminator)
        {
            var list = new List<string>();
            if (item.Split(deliminator).Length > 1)
            {
                for (int i = 0; i <= item.Split(deliminator).Length - 1; i++)
                {
                    list.Add(item.Split(deliminator)[i]);
                }
            }
            else
            {
                list.Add(item);
            }

            return list;
        }
    }
}

