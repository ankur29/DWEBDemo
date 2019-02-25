﻿using System;
using OpenQA.Selenium;
using NUnit.Framework;

namespace DemoProject.BrowserUtility
{
    
    //Initiate Webdriver instance
    class TestRunner
    {
        public static IWebDriver driver;
   /**
    * 
    * @param appUrl
    * @param implicitWait
    */
        //launch Application
        public void openApplication(String appUrl, int implicitWait)
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWait);
            driver.Navigate().GoToUrl(appUrl);
            
        }



    }
}
