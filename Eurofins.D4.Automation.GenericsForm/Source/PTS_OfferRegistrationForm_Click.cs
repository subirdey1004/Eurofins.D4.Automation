using D4.TestAutomation.Helper.Source;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Eurofins.D4.Automation.GenericsForm.Source
{
    class PTS_OfferRegistrationForm_Click
    {
        public static IWebDriver driver;
        GenericFormHelper repo = new GenericFormHelper();
        ObjectMethod objElement = new ObjectMethod();
        ActionMethod actionObj = new ActionMethod();
        
        [Test]
        public void OpenPTOffer()
        {
            driver = objElement.GettingDriver();
            driver.SwitchTo().Frame(driver.FindElement(By.XPath(objElement.HeaderFrame)));
            IWebElement headerMore = driver.FindElement(By.XPath("//div[@id='moduleSelector']//span[@class='moduleNameArrow']"));
            for (int i = 0; i < 3; i++)
            {
                headerMore.Click();
                Thread.Sleep(2000);
            }
            driver.SwitchTo().ParentFrame();
            driver.SwitchTo().Frame(driver.FindElement(By.XPath(objElement.HeaderDropDownList)));
            IWebElement elmGenericForm = driver.FindElement(By.XPath("//table[@id='tblPopupContext']//tr[3]//td[2]//div//span"));
            actionObj.ClickTable(elmGenericForm);
            driver.SwitchTo().ParentFrame();
            driver.SwitchTo().Frame(driver.FindElement(By.XPath(objElement.ContentFrame)));
            IWebElement tableRow = repo.GetTableHeader("Global Proficiency Testing/Admin Proficiency Testing/Register a PT Offer", "D4GenericListOverview1_overviewTable", driver);
            actionObj.ClickTable(tableRow);
            driver.SwitchTo().ParentFrame();
            repo.SelectsDropDownInTheForm(driver, "PT Provider Name", "Regression");
            repo.EnterTextValueInTheForm(driver, "Parameter", "TestingTheScript");
            repo.EnterTextAreaValueInTheForm(driver, "Matrix", "TestingTheScript");
            repo.ClickButton(driver,"Submit");
            objElement.QuitBrowser();
        }
    }
}
