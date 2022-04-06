using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace D4.TestAutomation.Helper.Source
{
    public class ObjectMethod
    {
        LaunchD4Site launchObj = new LaunchD4Site();
        public string HeaderFrame
        {
            get
            {
                return "//iframe[@id='ifHeaderTitle']";
            }
        }

        public string HeaderDropDownList
        {
            get
            {
                return "//iframe[@class='stD4DocPopupIframe']";
            }
        }
        public string ContentFrame
        {
            get
            {
                return "//iframe[@id='ifContentFrame']";
            }
        }
        public IWebDriver GettingDriver()
        {
            launchObj.LaunchBrowser("Chrome");
            return LaunchD4Site.driver;
        }

        public void QuitBrowser()
        {
            launchObj.CloseBroser();
        }
        public string CenterPanel
        {
            get
            {
                return "//div[@id='MainPanel']//div[@id='Panel_Center']//div[@id='D4GenericForm1']";
            }
        }
    }
}
