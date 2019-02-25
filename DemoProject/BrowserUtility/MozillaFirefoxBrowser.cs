using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DemoProject.BrowserUtility
{
    class MozillaFirefoxBrowser : TestRunner, Browsers
    {
        public IWebDriver initiateBrowser()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"E:\Drivers", "geckodriver.exe");
            return new FirefoxDriver(service);
        }
    }
}
