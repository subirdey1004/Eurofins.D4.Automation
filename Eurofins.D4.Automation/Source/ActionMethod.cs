using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace D4.TestAutomation.Helper.Source
{
    public class ActionMethod
    {
        public void ClickTable(IWebElement pathElement)
        {
            pathElement.Click();
        }

    }
}
