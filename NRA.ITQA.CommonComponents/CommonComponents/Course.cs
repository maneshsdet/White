using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CommonComponents
{
    public static class Course
    {
        private static IList<IWebElement> Rows;
        private static IList<IWebElement> Columns;
        public static void LaunchCourse(IWebDriver _driver, string course, string course_type)
        {

            try
            {
                Wait.WaitForElementClickable(_driver, _driver.FindElement(By.LinkText(course_type)), 20);
                _driver.FindElement(By.LinkText(course_type)).Click();
                Wait.WaitForElementClickable(_driver, _driver.FindElement(By.LinkText("Take Online Course")), 20);
                _driver.FindElement(By.LinkText("Take Online Course")).Click();
                Wait.WaitForElementDispalyed(_driver, _driver.FindElement(By.XPath("//*[contains(@id,'ctl00_ctl00_BaseMainContentPlaceHolder_MainContentPlaceHolder_grdStudentCourses')]/tbody")), 20);
                Rows = WebElementHelper.WebTable(_driver, _driver.FindElement(By.XPath("//*[contains(@id,'ctl00_ctl00_BaseMainContentPlaceHolder_MainContentPlaceHolder_grdStudentCourses')]/tbody")));
                bool breakLoops = false;
                for (int i = 0; i < Rows.Count; i++)
                {
                    Columns = Rows[i + 1].FindElements(By.TagName("td"));
                    for (int j = 0; j < Columns.Count; j++)
                    {
                        if (Columns[j].Text.Contains(course) && Columns[j + 1].Text.Equals("Not Started"))
                        {
                            JavaScript.JsClick(_driver, Columns[j + 3].FindElement(By.PartialLinkText("LAUNCH")));
                            Wait.DefaultWait(2);
                            breakLoops = true;
                            break;
                        }

                    }

                    if (breakLoops)
                        break;
                }
            }
            catch (Exception e)
            {
                Assertions.FailCase(MethodBase.GetCurrentMethod().Name, e.Message, _driver);
            }

        }

        public static void TakeExam(IWebDriver _driver, string ExamType)
        {
            try
            {
                Wait.WaitForElementClickable(_driver, _driver.FindElement(By.LinkText(ExamType)), 20);
                _driver.FindElement(By.LinkText(ExamType)).Click();
                Wait.WaitForElementClickable(_driver, _driver.FindElement(By.LinkText("Take Online Exam")), 20);
                _driver.FindElement(By.LinkText("Take Online Exam")).Click();
                Wait.DefaultWait(5);
            }
            catch (Exception e)
            {
                Assertions.FailCase(MethodBase.GetCurrentMethod().Name, e.Message, _driver);
            }
        }

    }
}
