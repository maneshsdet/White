using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommonComponents
{
    public static class Browsers
    {
        public static IWebDriver Browser(string BrowserType)
        {
            try
            {
                switch (BrowserType)
                {
                    case "Chrome":
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("--allow-insecure-localhost");
                        options.AddArgument("--ignore-ssl-errors=yes");
                        options.AddArgument("--ignore-certificate-errors");
                        options.AddUserProfilePreference("download.default_directory", @"\\nraqaauto1\Automation\PDFDownloads");
                        options.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
                        options.AddUserProfilePreference("download.prompt_for_download", false);
                        //options.AddArgument("--incognito");
                        return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
                    case "Edge":
                        EdgeOptions Edoptions = new EdgeOptions();
                        //Edoptions.UseInPrivateBrowsing = true;
                        return new EdgeDriver(Edoptions);
                    case "Firefox":
                        FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
                        service.Host = "::1";
                        var firefoxOptions = new FirefoxOptions();
                        firefoxOptions.AcceptInsecureCertificates = true;
                        return new FirefoxDriver(firefoxOptions);
                    case "Safari":
                        return new SafariDriver();

                    default:
                        throw new Exception();

                }
            }
            catch (Exception)
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--allow-insecure-localhost");
                options.AddArgument("--ignore-ssl-errors=yes");
                options.AddArgument("--ignore-certificate-errors");
                options.AddArgument("--incognito");
                return new ChromeDriver(options);
            }
        }

        public static void KillProcess(string processname)
        {
            try
            {
                switch (processname)
                {
                    case "chromedriver":
                        var chromeDriverProcesses = Process.GetProcesses().Where(pr => pr.ProcessName == "chromedriver");
                        foreach (var process in chromeDriverProcesses)
                        {
                            process.Kill();
                        }
                        break;
                    case "Edge":
                        EdgeOptions Edoptions = new EdgeOptions();
                        break;

                    case "Firefox":
                        FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
                        service.Host = "::1";
                        break;
                    default:
                        throw new Exception();

                }
            }
            catch (Exception)
            {
                Console.WriteLine("No Process is open");
            }
        }

    }
}
