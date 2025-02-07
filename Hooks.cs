using BoDi;
using CommonComponents;
using KeyManagementATDDTests.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Diagnostics;
using System.Security.Principal;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace KeyManagementATDDTests.Hooks
{
    [Binding]
    public class Hooks : TestVariables
    {
        public readonly IObjectContainer _container;
        public static TestContext? TestContext { get; set; }

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            try
            {

                Properties = LoadProperties.GetProperties(TestContext.Parameters["config"]);
                var RootDirectory = Directory.CreateDirectory(@"\\nraqaauto1\Automation\Reports\BTX\" + Environment.MachineName + "_" + WindowsIdentity.GetCurrent().Name.Split('\\')[1]).CreateSubdirectory(DateTime.Now.ToString("yyyy-MM-dd"));
                ReportsDir = RootDirectory.CreateSubdirectory(DateTime.Now.ToString("HH-mm-ss")).ToString();
                Browsers.KillProcess("chromedriver");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            try
            {
                using Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo()
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = string.Format(@"/C livingdoc test-assembly {0}.dll -t TestExecution.json & LivingDoc.html", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name)

                };
                process.StartInfo = startInfo;
                process.Start();
                string attachment = ReportsDir + @"\KM_" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".html";
                File.Move(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppDomain.CurrentDomain.RelativeSearchPath ?? "", "LivingDoc.html"), attachment);
                OutlookEmail.SendEmailViaOutlook(Properties["sFromAddress"], Properties["sToAddress"], Properties["sCc"], Properties["sSubject"], Properties["sBody"], attachment, Properties["sBcc"]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [BeforeScenario("@CreateAccount")]
        public void BeforeScenarioWithTag()
        {
            var timestamp = DateTimeStamp.getTimeStamp("yyyyMMddHHmmss");
            Emailid = Properties["emailid"].Split('@')[0] + "+" + timestamp + "@gmail.com";
            Students.Add(Emailid);
            FName = "Fst_" + timestamp;
            LstName = "Lst_" + timestamp;
            Password = Properties["EIPassword"];
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
            _driver = Browsers.Browser("Chrome");
            _driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs(_driver);
            _driver.Url = Properties["url"];
        }
        [AfterScenario]
        public void AfterScenario()
        {
            var _driver = _container.Resolve<IWebDriver>();
            if (_driver != null)
                _driver.Quit();
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            var _driver = _container.Resolve<IWebDriver>();
            //When scenario fails
            if (scenarioContext.TestError != null)
            {
                var filename = $"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png";
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                screenshot.SaveAsFile(filename);
                specFlowOutputHelper.AddAttachment(filename);
            }
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
        }
    }
}