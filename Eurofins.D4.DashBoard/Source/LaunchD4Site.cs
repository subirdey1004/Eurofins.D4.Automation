using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;
using System.Collections.Generic;

namespace D4.TestAutomation.Helper.Source
{
    public class LaunchD4Site
    {
        public static IWebDriver driver;
        public IWebDriver LaunchBrowser(string browsername)
        {
            if (browsername.Contains("Chrome"))
            {
                driver = new ChromeDriver(@"c:\Tools\Selenium");
            }
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://qa.d4.eurofins.local/");
            driver.Navigate().Refresh();
            return driver;
        }
        public void CloseBroser()
        {
            driver.Quit();
        }

        
    }
}