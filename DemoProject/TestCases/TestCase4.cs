using DemoProject.BrowserUtility;
using DemoProject.BusinessUitilities;
using DemoProject.Library;
using DemoProject.ObjectRepository;
using DemoProject.ReportUtility;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
=======
>>>>>>> bde76d6760db2abd3f7041cd5ac1f8736f442dcb

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
<<<<<<< HEAD
        ReadTestData readTestData = new ReadTestData();
        Dictionary<string, string> testDataMap;
        public ArrayList keys;

        [SetUp]
        public void setupConfigurations()
        {
            Console.WriteLine("Setup Test Configurations");
            testDataMap = readTestData.readExcelData();
            keys = readTestData.keyCount;
            Console.WriteLine("readTestData.keyCount=" + readTestData.keyCount[0]);
        }

=======
       
>>>>>>> bde76d6760db2abd3f7041cd5ac1f8736f442dcb
        [Test]
        //providing browser details
        [TestCaseSource(typeof(ManageDriver), "parallelBrowsers")]
        public void runTest1(String browserName) 
        {
<<<<<<< HEAD
            for (int i = 0; i < testDataMap.Count / 5; i++)
            {
                //try
                //{
                    String appUrl = "https://accounts.google.com/signin";
                    
                    systemHealthCheck = EnvironmentHealthCheck.checkUrlStatus(appUrl, report);
                    driver = manageDriver.parallelRun(browserName);
                    userRegistration = new UserRegistration(driver);
                    new TestRunner(driver).openApplication(appUrl, 6);
                //    registration = userRegistration.createUser(report,firstName,LastName);
                test = report.StartTest(testDataMap["TestCaseName_" + keys[i]], "Account Creation Steps");
                test.AssignCategory(browserName);
                Console.WriteLine("Assigned");
                string firstName = testDataMap["FirstName_" + keys[i]];
                string lastName = testDataMap["LastName_" + keys[i]];


                registration = userRegistration.createUser(report, firstName, lastName);
                test.AppendChild(systemHealthCheck).AppendChild(registration);
                report.EndTest(test);
                report.Flush();
                driver.Close();
            }
            //}
            //catch (Exception e)
            //{
            //    test.Log(LogStatus.Fail, e);
            //    report.EndTest(test);
            //    report.Flush();
            //}
=======
            try
            {
                String appUrl = "https://accounts.google.com/signin";
                test = report.StartTest("Create Account", "Account Creation Steps");
                test.AssignCategory(browserName);
                systemHealthCheck = EnvironmentHealthCheck.checkUrlStatus(appUrl, report);
                driver = manageDriver.parallelRun(browserName);
                userRegistration = new UserRegistration(driver);
                new TestRunner(driver).openApplication(appUrl, 6);            
<<<<<<< HEAD
            //    registration = userRegistration.createUser(report,firstName,LastName);
=======
                registration = userRegistration.createUser(report);
>>>>>>> f2a704b2f931c4c5802049b428fdafd79854bfc1
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
>>>>>>> bde76d6760db2abd3f7041cd5ac1f8736f442dcb
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
