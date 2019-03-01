using DemoProject.BrowserUtility;
using DemoProject.BusinessUitilities;
using DemoProject.Library;
using DemoProject.ObjectRepository;
using DemoProject.ReportUtility;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;

namespace DemoProject.TestCases
{
    [TestFixture]
    [Parallelizable]
   public class TestCase4 : ReportGenerator
    {
        //Define Objects
       public IWebDriver driver;
        ManageDriver manageDriver = new ManageDriver();
        UserRegistration userRegistration;
        ExtentTest test, registration,systemHealthCheck;
        ReportGenerator reportGenerator = new ReportGenerator();
       
        [Test]
        //providing browser details
        [TestCaseSource(typeof(ManageDriver), "parallelBrowsers")]
        public void runTest1(String browserName) 
        {
            try
            {
                String appUrl = "https://accounts.google.com/signin";
                test = report.StartTest("Create Account", "Account Creation Steps");
                test.AssignCategory(browserName);
                systemHealthCheck = EnvironmentHealthCheck.checkUrlStatus(appUrl, report);
                driver = manageDriver.parallelRun(browserName);
                userRegistration = new UserRegistration(driver);
                new TestRunner(driver).openApplication(appUrl, 6);            
                registration = userRegistration.createUser(report);
                test.AppendChild(systemHealthCheck).AppendChild(registration);
                report.EndTest(test);
                report.Flush();
            }
            catch (Exception e)
            {
                test.Log(LogStatus.Fail, e);
                report.EndTest(test);
                report.Flush();
            }
        }

        [TearDown]
        public void endTest() // This method will be fired at the end of the test
        {
            try
            {
                driver.Close();
                //report.EndTest(test);
                //report.Flush();
                //report.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception="+e);     
            }
        }
    }
}
