using CommonComponents;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRAAutomation.Main.pom.nra.pages
{
    public static class Certificate
    {

        //public IWebElement View_Print_Certificate => _driver.FindElement(By.LinkText("VIEW / PRINT CERTIFICATES"));
        //public IWebElement Certificates => _driver.FindElement(By.Id("Certificates-link"));
        //public IWebElement CertificateTable => _driver.FindElement(By.Id("ctl00_ctl00_BaseMainContentPlaceHolder_MainContentPlaceHolder_DataGrid1"));
        //public IWebElement View_Download_Certificate => _driver.FindElement(By.LinkText(" View or Print Certificate"));
        //public IWebElement Download => _driver.FindElement(By.Id("download"));
        private static IList<IWebElement> Rows;
        private static IList<IWebElement> Columns;


        public static void CertificatesSetUp(IWebDriver _driver)
        {
            Wait.WaitForElementClickable(_driver, _driver.FindElement(By.Id("Certificates-link")), 20);
            Actions action = new Actions(_driver);
            action.MoveToElement(_driver.FindElement(By.Id("Certificates-link"))).Perform();
            Wait.WaitForElementClickable(_driver, _driver.FindElement(By.LinkText("VIEW / PRINT CERTIFICATES")), 20);
            _driver.FindElement(By.LinkText("VIEW / PRINT CERTIFICATES")).Click();

        }

        public static void SSICertificatesSetUp(IWebDriver _driver)
        {
            Wait.WaitForElementClickable(_driver, _driver.FindElement(By.PartialLinkText("Home")), 20);
            _driver.FindElement(By.PartialLinkText("Home")).Click();
            Wait.WaitForElementClickable(_driver, _driver.FindElement(By.PartialLinkText("Print Certificate")), 20);
            _driver.FindElement(By.PartialLinkText("Print Certificate")).Click();

        }

        public static void MFCertificatesSetUp(IWebDriver _driver)
        {
            try
            {
                Wait.WaitForElementClickable(_driver, _driver.FindElement(By.PartialLinkText("Student Resources")), 30);
                _driver.FindElement(By.PartialLinkText("Student Resources")).Click();

            }
            catch (Exception e)
            {
                Assertions.FailCase(MethodBase.GetCurrentMethod().Name, e.Message, _driver);
            }

        }


        public static void View_Print_Certificates(IWebDriver _driver, string certificateID, string certificateType)
        {
            try
            {
                if (_driver.WindowHandles.Count > 1)
                    _driver.SwitchTo().Window(_driver.WindowHandles[1]);
                try
                {
                    Wait.WaitForElementDispalyed(_driver, _driver.FindElement(By.Id("ctl00_ctl00_BaseMainContentPlaceHolder_MainContentPlaceHolder_DataGrid1")), 20);
                    Rows = WebElementHelper.WebTable(_driver, _driver.FindElement(By.Id("ctl00_ctl00_BaseMainContentPlaceHolder_MainContentPlaceHolder_DataGrid1")));
                }
                catch (Exception)
                {
                    try
                    {
                        Wait.WaitForElementDispalyed(_driver, _driver.FindElement(By.Id("ctl00_cphPageContent_GridView1")), 20);
                        Rows = WebElementHelper.WebTable(_driver, _driver.FindElement(By.Id("ctl00_cphPageContent_GridView1")));
                    }
                    catch (Exception)
                    {
                        Wait.WaitForElementDispalyed(_driver, _driver.FindElement(By.Id("MainContentPlaceHolder_grdClasses")), 20);
                        Rows = WebElementHelper.WebTable(_driver, _driver.FindElement(By.Id("MainContentPlaceHolder_grdClasses")));
                    }
                }
                bool breakLoops = false;
                for (int i = 0; i < Rows.Count; i++)
                {
                    Columns = Rows[i + 1].FindElements(By.TagName("td"));
                    for (int j = 0; j < Columns.Count; j++)
                    {
                        if (Columns[j].Text.Contains(certificateID))
                        {
                            for (int k = 0; k < 10; k++)
                            {
                                try
                                {
                                    if (!_driver.Url.Contains("managefirst"))
                                    {
                                        if (Columns[j + 2].FindElement(By.CssSelector("a[href*='#']")).Text.Contains("VIEW OR PRINT CERTIFICATE") || Columns[j + 2].FindElement(By.CssSelector("a[href*='#']")).Text.Contains("View"))
                                            Columns[j + 2].FindElement(By.CssSelector("a[href*='#']")).Click();
                                    }
                                    else
                                    {
                                        for (int p = 0; i < 30; p++)
                                        {
                                            try
                                            {
                                                //Columns[j + 7].FindElement(By.XPath("//a[contains(@id, 'MainContentPlaceHolder_grdClasses_lnkViewCert_0')]")).Click();
                                                Columns[j + 7].FindElement(By.PartialLinkText("Print/View")).Click();
                                                break;
                                            }
                                            catch (Exception)
                                            {
                                                Wait.DefaultWait(5);
                                                _driver.Navigate().Refresh();
                                            }
                                        }
                                    }
                                    breakLoops = true;
                                    break;
                                }
                                catch (Exception)
                                {
                                    Wait.DefaultWait(2);
                                    _driver.Navigate().Refresh();
                                }
                            }
                            if (breakLoops)
                                break;
                        }

                    }

                    if (breakLoops)
                        break;
                }
                Wait.DefaultWait(5);
                if (_driver.WindowHandles.Count > 1)
                    _driver.SwitchTo().Window(_driver.WindowHandles[1]).Close();
                _driver.SwitchTo().Window(_driver.WindowHandles[0]);
                //  Assertions.Contains(_driver.Url, "ss/Exams/certificates/ipcert.aspx?CID=", "Expected URL contains - ss/Exams/certificates/ipcert.aspx?CID= : Actual URL - " + _driver.Url, certificateType, "View Certificate", _driver);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }


}
