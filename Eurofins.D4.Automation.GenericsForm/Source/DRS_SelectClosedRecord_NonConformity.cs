using D4.TestAutomation.Helper.Source;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Eurofins.D4.Automation.GenericsForm.Source
{
    class DRS_SelectClosedRecord_NonConformity
    {
        public static IWebDriver driver;
        GenericFormHelper repo = new GenericFormHelper();
        ObjectMethod objElement = new ObjectMethod();
        ActionMethod actionObj = new ActionMethod();
        string DeviationID = "Nonconformity";
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
            IWebElement tableRow = repo.GetTableHeader("Deviation Recording System/Manage Deviation/Nonconformity", "D4GenericListOverview1_overviewTable", driver);
            actionObj.ClickTable(tableRow);
            driver.SwitchTo().ParentFrame();
            repo.SelectRecord(driver, DeviationID);
            objElement.QuitBrowser();
        }
    }
}
