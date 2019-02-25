using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace DemoProject.BrowserUtility
{
    class InternetExplorer : TestRunner, Browsers
    {
        public IWebDriver initiateBrowser()
        {
            InternetExplorerDriverService service = InternetExplorerDriverService.CreateDefaultService(@"E:\Drivers", "geckodriver.exe");
            return new InternetExplorerDriver(service);
        }
    }

}
