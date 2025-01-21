using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace CommonComponents
{
    public static class JavaScript
    {
        public static void JsClick(IWebDriver _driver, IWebElement element)
        {
            Actions actions = new Actions(_driver);
            (_driver as IJavaScriptExecutor).ExecuteScript("arguments[0].click()", new object[1]
            {
         element
            });
        }

        public static void JsEnter(IWebDriver _driver, IWebElement element, string value)
        {
            (_driver as IJavaScriptExecutor).ExecuteScript("arguments[1].value = arguments[0]; ", value, element);
        }
    }
}
