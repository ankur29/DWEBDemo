using DemoProject.BrowserUtility;
using DemoProject.ObjectRepository;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;

namespace DemoProject.BusinessUitilities
{
    class UserRegistration: TestRunner
    {
   

        public ExtentTest createUser(ExtentReports report)
        {
            ExtentTest registration = report.StartTest("SignUp");
            try
            {
                driver.FindElement(By.XPath(RegistrationPage.createAccount)).Click();
                driver.FindElement(By.XPath(RegistrationPage.firstName)).SendKeys("TestFirstName");
                driver.FindElement(By.XPath(RegistrationPage.lastName)).SendKeys("TestLastName");
                registration.Log(LogStatus.Pass, "Sign UP Test Case");
            }
            catch (Exception e)
            {
                registration.Log(LogStatus.Fail, "Sign UP Test Case",e);
            }
            return registration;


        }
    }
}
