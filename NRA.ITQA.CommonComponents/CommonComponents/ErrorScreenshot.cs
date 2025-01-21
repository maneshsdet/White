using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace CommonComponents
{
    public static class ErrorScreenshot
    {
        //public static MediaEntityModelProvider CaptureScreenshotAndReturnModel(
        //  IWebDriver driver,
        //  string name)
        //{
        //    return MediaEntityBuilder.CreateScreenCaptureFromBase64String(((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString, name).Build();
        //}

        public static MediaEntityBuilder CaptureScreenshotAndReturnModel(IWebDriver driver, string name)
        {
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString, name);
        }

        public static MediaEntityModelProvider AddScreenshotAndReturnModel(IWebDriver driver, ScenarioContext scenarioContext)
        {
            MediaEntityBuilder entityModelProvider = ErrorScreenshot.CaptureScreenshotAndReturnModel(driver, scenarioContext.ToString());
            return entityModelProvider.Build();
            // return MediaEntityBuilder.CreateScreenCaptureFromBase64String(((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString, scenarioContext);
        }
    }
}
