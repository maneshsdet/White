using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using static CommonComponents.Constants;
namespace CommonComponents
{
    public static class Assertions
    {
        public static void Equals<T>(T expected, T actual, string testcaseSteps, string main, string child, IWebDriver driver)
        {
            try
            {
                Assert.AreEqual<T>(expected, actual);
                test.Pass(testcaseSteps, null);
            }
            catch (AssertFailedException ex)
            {
                FailStep<T>(testcaseSteps, main, driver);
                Errors.Add(main + "#" + child);
            }
        }
        public static void True<T>(bool expected, string testcaseSteps, string main, string child, IWebDriver driver)
        {
            try
            {
                Assert.IsTrue(expected);
                test.Pass(testcaseSteps, null);
            }
            catch (AssertFailedException ex)
            {
                FailStep<T>(testcaseSteps, main, driver);
                Errors.Add(main + "#" + child);
            }
        }
        public static void NotNull<T>(T text, string testcaseSteps, string main, string child, IWebDriver driver)
        {
            try
            {
                Assert.IsNotNull(text);
                test.Pass(testcaseSteps, null);
            }
            catch (AssertFailedException ex)
            {
                FailStep<T>(testcaseSteps, main, driver);
                Errors.Add(main + "#" + child);
            }
        }


        public static void Validate<T>(T expected, T actual, string testcaseSteps, string main, string child, IWebDriver driver)
        {
            try
            {
                MediaEntityBuilder entityModelProvider = ErrorScreenshot.CaptureScreenshotAndReturnModel(driver, main);
                Assert.AreEqual<T>(expected, actual);
                test.Pass(testcaseSteps, entityModelProvider.Build());
            }
            catch (AssertFailedException ex)
            {
                FailStep<T>(testcaseSteps, main, driver);
                Errors.Add(main + "#" + child);
            }
        }

        public static void Contains(
          string actualvalue,
          string containsvalue,
          string testcaseSteps,
          string mainlink,
          string childlink,
          IWebDriver driver)
        {
            try
            {
                MediaEntityBuilder entityModelProvider = ErrorScreenshot.CaptureScreenshotAndReturnModel(driver, mainlink);
                Assert.IsTrue(actualvalue.Contains(containsvalue));
                test.Pass(testcaseSteps, entityModelProvider.Build());
            }
            catch (AssertFailedException ex)
            {
                FailStep<string>(testcaseSteps, mainlink, driver);
            }
        }

        public static void Contains(
          string actualvalue,
          string containsvalue)
        {
            try
            {
                Assert.IsTrue(actualvalue.Contains(containsvalue));
            }
            catch (AssertFailedException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void Compare(DateTime expected, DateTime actual, string testcaseSteps, string main, string child, IWebDriver driver)
        {
            try
            {
                if (DateTime.Compare(expected, actual) != 0)
                    ;

            }
            catch (AssertFailedException ex)
            {
                FailStep<DateTime>(testcaseSteps, main, driver);
            }
        }



        //public static void FailStep<T>(
        //  T expected,
        //  T actual,
        //  string testcaseSteps,
        //  string mainlink,
        //  string childlink,
        //  IWebDriver driver)
        //{
        //    MediaEntityModelProvider entityModelProvider = ErrorScreenshot.CaptureScreenshotAndReturnModel(driver, mainlink);
        //    test.Fail(testcaseSteps, entityModelProvider);
        //    ++Failure;
        //}

        public static void FailStep<T>(
       string testcaseSteps,
       string mainlink,
       IWebDriver driver)
        {
            MediaEntityBuilder entityModelProvider = ErrorScreenshot.CaptureScreenshotAndReturnModel(driver, mainlink);
            test.Fail(testcaseSteps, entityModelProvider.Build());
            ++Failure;
        }

        public static void FailCase(string method, string mainlink, IWebDriver driver)
        {
            MediaEntityBuilder entityModelProvider = ErrorScreenshot.CaptureScreenshotAndReturnModel(driver, mainlink);
            test.Fail(method, entityModelProvider.Build());
        }
    }
}
