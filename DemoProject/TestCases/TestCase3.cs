﻿using DemoProject.BrowserUtility;
using DemoProject.BusinessUitilities;
using DemoProject.Library;
using DemoProject.ReportUtility;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections;
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
        [Test]
        //providing browser details
        [TestCaseSource(typeof(ManageDriver), "parallelBrowsers")]
        //Test cases steps
        public void runTest2(String browserName)
        {
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
