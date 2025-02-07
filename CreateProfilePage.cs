using CommonComponents;
using KeyManagementATDDTests.Pages;
using KeyManagementATDDTests.Support;
using NetSuite.Main.pom.nra.pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace KeyManagementATDDTests.Pages
{
    public class CreateProfilePage : TestVariables
    {
        public CreateProfilePage(IWebDriver driver) => _driver = driver;
        HomePage homePage;
        //locator for CreateAccount
        public IWebElement lnkCreateAccount => _driver.FindElement(By.PartialLinkText("CREATE ACCOUNT"));
        //locator for EmailId
        public IWebElement txtEmailAddress => _driver.FindElement(By.Id("emailToCheck"));
        //locatr for Submit
        public IWebElement btnSubmit => _driver.FindElement(By.Id("doCheckUniquenessButton"));
        //Locator for Firstname
        public IWebElement txtFname => _driver.FindElement(By.Id("givenName"));
        //Locator for Lastname
        public IWebElement txtLname => _driver.FindElement(By.Id("sn"));
        //Locator for EmailType
        public IWebElement lstEmailType => _driver.FindElement(By.Id("emailType"));
        public IWebElement txtConfirmEmail => _driver.FindElement(By.Id("mail-confirm"));
        //Locator for AddressType
        public IWebElement lstAddressType => _driver.FindElement(By.Id("addressType"));
        //Locator for Address1
        public IWebElement txtAddress1 => _driver.FindElement(By.Id("address1"));
        //Locator for Address2
        public IWebElement txtAddress2 => _driver.FindElement(By.Id("address2"));
        //Locator for City
        public IWebElement lstCity => _driver.FindElement(By.Id("city"));
        //Locator for Country
        public IWebElement lstCountry => _driver.FindElement(By.Id("country"));
        //Locator for State
        public IWebElement lstState => _driver.FindElement(By.Name("state")); //ID as Country
        //locator for Zip
        public IWebElement txtZipcode => _driver.FindElement(By.Id("zipCode"));
        //Locator for MobileCOuntry
        public IWebElement lstMobileCountry => _driver.FindElement(By.Id("mobileCountry"));
        //Locator for PhoneNumber
        public IWebElement txtPhoneNumber => _driver.FindElement(By.Id("phoneNumber"));
        //Locator for JobRole
        public IWebElement lstJobRole => _driver.FindElement(By.Id("jobRole"));
        //Locator for JobRoleOther
        public IWebElement txtJobRoleOther => _driver.FindElement(By.Id("jobRoleOther"));
        public IWebElement txtProfilePassword => _driver.FindElement(By.Id("password"));
        //Locator for ConfirmPassword
        public IWebElement txtConfirmPassword => _driver.FindElement(By.Id("confirmPassword"));
        //Locator for Verification Code
        public IWebElement txtVerfCode => _driver.FindElement(By.Id("Passcode"));
        //Locator for Continue
        public IWebElement btnContinue => _driver.FindElement(By.Id("submitBtn"));
        //Locator for ResendVerficationEmail
        public IWebElement lnkResend => _driver.FindElement(By.LinkText("Resend verification email"));
        //Locator for Go To My Account
        public IWebElement btnGoToAccount => _driver.FindElement(By.XPath("//button[contains(.,'Go to My Account')]"));
        //locator for SigninDropdown
        public IWebElement ddnSinginDropdown => _driver.FindElement(By.Id("signindropdown"));
        //locator for Edit Profile
        public IWebElement lnkUpdateProifle => _driver.FindElement(By.CssSelector("a[href*='/Functional-Pages/Dashboard-(My-Account)/Update-Profile']"));
        //locator for Edit Profile
        public IWebElement lnkEProfile => _driver.FindElement(By.LinkText("EDIT PROFILE"));
        //locator for SyncTracking
        public IWebElement txtSyncTracking => _driver.FindElement(By.Id("nraSyncTracking"));

        //locator for Use Address
        public IWebElement btnUseAddress => _driver.FindElements(By.Id("useThis"))[1];
        //locator for Keep Address
        public IWebElement btnKeepAddress => _driver.FindElements(By.Id("keepMine"))[1];
        // locator for NewPassword
        public IWebElement txtNewPswd => _driver.FindElement(By.Id("NewPassword"));
        // locator for NewPassword
        public IWebElement txtConfirmNewPswd => _driver.FindElement(By.Id("ConfirmPassword"));
        // locator for 
        public IWebElement mdlSuggestedAddress => _driver.FindElement(By.Id("suggestedAddressModal"));
        public IWebElement mdlSuggestedAddressError => _driver.FindElement(By.Id("suggestedAddressErrorModal"));
        public IWebElement CaptchaDisplay => _driver.FindElement(By.CssSelector("iframe[title='recaptcha challenge expires in two minutes']"));
        // Locator for School
        public IWebElement txtSchoolName => _driver.FindElement(By.Id("schoolName"));
        public IWebElement txtSchoolCountry => _driver.FindElement(By.Id("schoolCountry"));
        public IWebElement txtSchoolState => _driver.FindElement(By.Id("schoolState"));

        public MyAccountPage CreateNewAccount()
        {
            try
            {
                Students.Add(Emailid);
                Wait.WaitForLoad(_driver, By.Id("emailToCheck"));
                txtEmailAddress.SendKeys(Emailid);
                btnSubmit.Click();
                Wait.WaitForLoad(_driver, By.Id("givenName"));
                FirstNames.Add(FName);
                txtFname.SendKeys(FName);
                txtLname.SendKeys(LstName);
                txtConfirmEmail.SendKeys(Emailid);
                lstEmailType.SendKeys(SharedData.EmailType());
                lstAddressType.SendKeys(SharedData.AddressType());
                var RandState = SharedData.RandomState();
                txtAddress1.SendKeys(SharedData.GetAddress()[RandState].Item1.ToUpper());
                txtAddress2.SendKeys(SharedData.GetAddress()[RandState].Item2.ToUpper());
                lstCity.SendKeys(SharedData.GetAddress()[RandState].Item3.ToUpper());
                lstCountry.SendKeys("UNITED STATES");
                lstState.SendKeys(RandState);
                txtZipcode.SendKeys(SharedData.GetAddress()[RandState].Item4.ToString());
                lstMobileCountry.SendKeys("United States (+1)");
                txtPhoneNumber.SendKeys(PhoneNumberGenerator.PhoneNumber());
                var role = SharedData.JobRole();
                lstJobRole.SendKeys(role);
                try
                {
                    if (role.Equals("Other"))
                        txtJobRoleOther.SendKeys("Master");
                }
                catch (Exception)
                {
                    if (role.Equals("Student"))
                    {
                        txtSchoolName.SendKeys("Harper College");
                        txtSchoolCountry.SendKeys("United States");
                        txtSchoolState.SendKeys("Illinois");
                    }
                }
                txtProfilePassword.SendKeys(Password);
                txtConfirmPassword.SendKeys(Password);
                lnkCreateAccount.Click();
                Wait.DefaultWait(5);
                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        if (mdlSuggestedAddress.GetAttribute("style").Equals("display: inline-block;"))
                            btnUseAddress.Click();
                        else
                            btnKeepAddress.Click();
                    }
                    catch (Exception)
                    {
                        Wait.DefaultWait(2);
                        i++;
                    }
                }
                AccountInfo.Add(Emailid, new Tuple<string, string>(FName, LstName));
                EnterVerificationCode();
                Wait.WaitForLoad(_driver, By.XPath("//button[contains(.,'Go to My Account')]"));
                btnGoToAccount.Click();
                Wait.WaitForLoad(_driver, By.LinkText("Manage Products"));
                return new MyAccountPage(_driver);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public string EnterVerificationCode()
        {
            try
            {
                Wait.DefaultWait(20);
                //VerfCode.SendKeys(EmailVerfication.VerificationCode("servesuccessautomation@gmail.com", "Password123$"));
                txtVerfCode.SendKeys(EmailVerfication.VerificationCode(Constants.Properties["emailid"], Constants.Properties["password"]));
                btnContinue.Click();
                Wait.DefaultWait(5);
                try
                {
                    if (WebElementHelper.IsDisplayed(txtNewPswd))
                    {
                        Password = PasswordGenerator.RandomPassword(8);
                        Console.WriteLine(Password);
                        txtNewPswd.SendKeys(Password);
                        txtConfirmNewPswd.SendKeys(Password);
                        btnContinue.Click();
                        Wait.DefaultWait(5);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("New Account Creation");
                }
                EmailSuccess = _driver.FindElement(By.XPath("//div[contains(@class,'text-center my-4')]")).Text;
                return EmailSuccess;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
        public string Syncing(string synccode)
        {
            int i = 0;
            try
            {
                Wait.ExplicitWait(_driver, _driver.FindElement(By.LinkText("EDIT PROFILE")));
                JavaScript.JsClick(_driver, _driver.FindElement(By.LinkText("EDIT PROFILE")));
                Wait.DefaultWait(3);
                _driver.SwitchTo().Window(_driver.WindowHandles[1]);
                while (i < 10)
                {
                    Wait.DefaultWait(2);
                    var syncode = txtSyncTracking.GetAttribute("value");
                    if (syncode.Equals(synccode) || syncode.Equals("'00000010'B"))
                        return syncode;
                    i++;

                }
                return txtSyncTracking.GetAttribute("value");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return txtSyncTracking.GetAttribute("value");
            }
        }


    }
}
