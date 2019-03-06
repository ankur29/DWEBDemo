using DemoProject.BrowserUtility;
using DemoProject.Library;
using DemoProject.ObjectRepository;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;

namespace DemoProject.BusinessUitilities
{
 public class UserRegistration
    {
        IWebDriver driver;
        PerformAction performAction;
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
>>>>>>> bde76d6760db2abd3f7041cd5ac1f8736f442dcb


        public UserRegistration(IWebDriver _driver)
        {
            driver = _driver;
            performAction = new PerformAction(driver);

        }

        public void signUpUser()
        {
            
            driver.FindElement(By.XPath(RegistrationPage.firstName)).SendKeys("TestFirstName");
            driver.FindElement(By.XPath(RegistrationPage.lastName)).SendKeys("TestLastName");
        }
<<<<<<< HEAD
=======
>>>>>>> f2a704b2f931c4c5802049b428fdafd79854bfc1


        public UserRegistration(IWebDriver _driver)
        {
            driver = _driver;
            performAction = new PerformAction(driver);

        }

        public void signUpUser()
        {
            
            driver.FindElement(By.XPath(RegistrationPage.firstName)).SendKeys("TestFirstName");
            driver.FindElement(By.XPath(RegistrationPage.lastName)).SendKeys("TestLastName");
        }
>>>>>>> bde76d6760db2abd3f7041cd5ac1f8736f442dcb

        public ExtentTest createUser(ExtentReports report,String firstName,String lastName)
        {
            ExtentTest registration = report.StartTest("SignUp");
            try
            {                              
                performAction.clickButton(RegistrationPage.CREATEACCOUNT_SIGNUP_XPATH, "CREATEACCOUNT_SIGNUP_XPATH");
               // driver.FindElement(By.XPath(RegistrationPage.createAccount)).Click();
<<<<<<< HEAD
                driver.FindElement(By.XPath(RegistrationPage.firstName)).SendKeys(firstName);
                driver.FindElement(By.XPath(RegistrationPage.lastName)).SendKeys(lastName);
                registration.Log(LogStatus.Pass, "Sign UP Test Case");     
=======
<<<<<<< HEAD
                driver.FindElement(By.XPath(RegistrationPage.firstName)).SendKeys(firstName);
                driver.FindElement(By.XPath(RegistrationPage.lastName)).SendKeys(lastName);
                registration.Log(LogStatus.Pass, "Sign UP Test Case");     
=======
                driver.FindElement(By.XPath(RegistrationPage.firstName)).SendKeys("TestFirstName");
                driver.FindElement(By.XPath(RegistrationPage.lastName)).SendKeys("TestLastName");
                registration.Log(LogStatus.Pass, "Sign UP Test Case");
              
>>>>>>> f2a704b2f931c4c5802049b428fdafd79854bfc1
>>>>>>> bde76d6760db2abd3f7041cd5ac1f8736f442dcb
            }
            catch (Exception e)
            {
                registration.Log(LogStatus.Fail, "Sign UP Test Case",e);
                var imagePath = new CaptureScreenshot(driver).takeScreenchot("SignUp");
                registration.Log(LogStatus.Info, "Snapshot below: " + registration.AddScreenCapture(imagePath));

            }
            return registration;


        }
    }
}
