using DemoProject.BrowserUtility;
using DemoProject.BusinessUitilities;
using DemoProject.Library;
using DemoProject.ReportUtility;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.TestCases
{
    [TestFixture]
    [Parallelizable]
    class TestCase3 : ReportGenerator
    {
        //Define Objects
        IWebDriver driver;
        ManageDriver manageDriver = new ManageDriver();
        UserRegistration userRegistration;
        ExtentTest test, registration, systemHealthCheck;
        ReportGenerator reportGenerator = new ReportGenerator();
        
        [Test]
        //providing browser details
        [TestCaseSource(typeof(ManageDriver), "parallelBrowsers")]
        //Test cases steps
        public void runTest2(String browserName)
        {
            String appUrl = "https://accounts.google.com/signin";      
            test = report.StartTest("Login Account", "Account Creation Steps");
            driver = manageDriver.parallelRun(browserName);
            test.AssignCategory(browserName);
            systemHealthCheck = EnvironmentHealthCheck.checkUrlStatus(appUrl, report);
            userRegistration = new UserRegistration(driver);
            new TestRunner(driver).openApplication(appUrl, 6);         
            registration = userRegistration.createUser(report);
            test.AppendChild(systemHealthCheck).AppendChild(registration);
            report.EndTest(test);
            report.Flush();
        }        

        [TearDown]
        public void endTest() // This method will be fired at the end of the test
        {
            try
            {
                driver.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception=" + e);
              
            }
        }



    }
}
