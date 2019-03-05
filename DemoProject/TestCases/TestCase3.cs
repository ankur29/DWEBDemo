using DemoProject.BrowserUtility;
using DemoProject.BusinessUitilities;
using DemoProject.Library;
using DemoProject.ReportUtility;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
<<<<<<< HEAD
using System.Collections;
=======
>>>>>>> f2a704b2f931c4c5802049b428fdafd79854bfc1
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
<<<<<<< HEAD
        ReadTestData readTestData = new ReadTestData();
        Dictionary<string, string> testDataMap;
        public ArrayList keys;

        [SetUp]
        public void setupConfigurations()
        {
            Console.WriteLine("Setup Test Configurations");
            testDataMap=readTestData.readExcelData();
            keys = readTestData.keyCount;
            Console.WriteLine("readTestData.keyCount="+readTestData.keyCount[0]);
        }
=======
        
>>>>>>> f2a704b2f931c4c5802049b428fdafd79854bfc1
        [Test]
        //providing browser details
        [TestCaseSource(typeof(ManageDriver), "parallelBrowsers")]
        //Test cases steps
        public void runTest2(String browserName)
        {
<<<<<<< HEAD
            for (int i = 0; i < testDataMap.Count / 5; i++)
            {
                String appUrl = "https://accounts.google.com/signin";      
            driver = manageDriver.parallelRun(browserName);
            systemHealthCheck = EnvironmentHealthCheck.checkUrlStatus(appUrl, report);
            userRegistration = new UserRegistration(driver);
            new TestRunner(driver).openApplication(appUrl, 6);
            Console.WriteLine("testDataMap.Count=" + testDataMap.Count);
            
                Console.WriteLine("1");
                test = report.StartTest(testDataMap["TestCaseName_"+ keys[i]], "Account Creation Steps");
                test.AssignCategory(browserName);
                Console.WriteLine("Assigned");
                string firstName = testDataMap["FirstName_" + keys[i]];
                string lastName = testDataMap["LastName_" + keys[i]];


                registration = userRegistration.createUser(report,firstName,lastName);
                test.AppendChild(systemHealthCheck).AppendChild(registration);
                report.EndTest(test);
                report.Flush();
            }
=======
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
>>>>>>> f2a704b2f931c4c5802049b428fdafd79854bfc1
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
