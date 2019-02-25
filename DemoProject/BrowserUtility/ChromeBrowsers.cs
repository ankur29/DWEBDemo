using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace DemoProject.BrowserUtility
{
    class ChromeBrowsers : TestRunner, Browsers
    {
        public IWebDriver initiateBrowser()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"E:\Drivers", "chromedriver.exe");
            return new ChromeDriver(service);
        }
    }
}
