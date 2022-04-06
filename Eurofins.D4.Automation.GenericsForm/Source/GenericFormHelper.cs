using D4.TestAutomation.Helper.Source;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurofins.D4.Automation.GenericsForm.Source
{
    class GenericFormHelper
    {
        ObjectMethod objElement = new ObjectMethod();
        public IWebElement GetTableHeader(string path, string TableID, IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(2);
            string[] hierarchygPath = path.Split('/');
            IWebElement elmRowName = null;
            ReadOnlyCollection<IWebElement> listOFTopRows, listOFSubRows, listOFRows;
            listOFTopRows = driver.FindElements(By.XPath("//table[@id='" + TableID + "']//tr[contains(@class,'TopHead')]"));
            listOFSubRows = driver.FindElements(By.XPath("//table[@id='" + TableID + "']//tr[contains(@class,'SubHead')]"));
            listOFRows = driver.FindElements(By.XPath("//table[@id='" + TableID + "']//tr[@class='gfiGHead']"));
            for (int j = 0; j < hierarchygPath.Length; j++)
            {
                if (j == 0)
                {
                    for (int i = 1; i < listOFTopRows.Count; i++)
                    {
                        elmRowName = driver.FindElement(By.XPath("//table[@id='" + TableID + "']//tr[contains(@class,'TopHead')][" + i + "]//td[3]"));
                        string rowName = elmRowName.Text;
                        if (rowName.Contains(hierarchygPath[j]))
                        {
                            string isExpanded = listOFTopRows[i - 1].GetAttribute("isopen");
                            if (isExpanded.Equals("0"))
                                elmRowName.FindElement(By.XPath("following-sibling::*")).Click();
                        }
                    }
                }
                else if (j == 1)
                {
                    for (int i = 1; i < listOFSubRows.Count; i++)
                    {
                        elmRowName = driver.FindElement(By.XPath("//table[@id='" + TableID + "']//tr[contains(@class,'SubHead')][" + i + "]//td[4]"));
                        string rowName = elmRowName.Text;
                        if (rowName.Contains(hierarchygPath[j]))
                        {
                            string isExpanded = listOFSubRows[i - 1].GetAttribute("isopen");
                            if (isExpanded.Equals("0"))
                                elmRowName.FindElement(By.XPath("following-sibling::*")).Click();
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < listOFRows.Count; i++)
                    {
                        elmRowName = driver.FindElement(By.XPath("//table[@id='" + TableID + "']//tr[@class='gfiGHead'][" + i + "]//td[@class='GroupHeaderRight']"));
                        string rowName = elmRowName.Text;
                        if (rowName.Contains(hierarchygPath[j]))
                        {
                            break;
                        }
                    }
                }
            }
            return elmRowName;
        }

        public string[] FieldsNameInTheForm(IWebDriver driver)
        {
            driver.SwitchTo().Frame(driver.FindElement(By.XPath(objElement.ContentFrame)));
            IWebElement elmForm = driver.FindElement(By.XPath(objElement.CenterPanel));
            ReadOnlyCollection<IWebElement> elmFields = elmForm.FindElements(By.XPath("//div//label"));
            string[] fieldsName = null;
            for (int i = 0; i < elmFields.Count; i++)
            {
                fieldsName[i] = elmFields[i].Text;
            }
            return fieldsName;
        }
        public void SelectsDropDownInTheForm(IWebDriver driver, string ParameterName, string DropDownValue)
        {
            driver.SwitchTo().Frame(driver.FindElement(By.XPath(objElement.ContentFrame)));
            IWebElement elmForm = driver.FindElement(By.XPath(objElement.CenterPanel));
            IWebElement elmField = elmForm.FindElement(By.XPath("//div//label[contains(text(),'" + ParameterName + "')]/.."));
            //IWebElement parent = elmField.FindElement(By.XPath("./.."));
            SelectElement oSelect = new SelectElement(elmField.FindElement(By.XPath("//select")));
            oSelect.SelectByText(DropDownValue);
            driver.SwitchTo().ParentFrame();
        }
        public void EnterTextValueInTheForm(IWebDriver driver, string ParameterName, string TextBoxValue)
        {
            driver.SwitchTo().Frame(driver.FindElement(By.XPath(objElement.ContentFrame)));
            IWebElement elmForm = driver.FindElement(By.XPath(objElement.CenterPanel));
            IWebElement elmField = elmForm.FindElement(By.XPath("//div//label[contains(text(),'" + ParameterName + "')]/..//input[@type='text']"));
            //IWebElement parent = elmField.FindElement(By.XPath("./.."));
            //IWebElement oSelect = elmField.FindElement(By.XPath("//input[@type='text']"));
            elmField.SendKeys(TextBoxValue);
            driver.SwitchTo().ParentFrame();
        }
        public void EnterTextAreaValueInTheForm(IWebDriver driver, string ParameterName, string TextBoxValue)
        {
            driver.SwitchTo().Frame(driver.FindElement(By.XPath(objElement.ContentFrame)));
            IWebElement elmForm = driver.FindElement(By.XPath(objElement.CenterPanel));
            IWebElement elmField = elmForm.FindElement(By.XPath("//div//label[contains(text(),'" + ParameterName + "')]/..//textarea"));
            //IWebElement parent = elmField.FindElement(By.XPath("./.."));
            //IWebElement oSelect = elmField.FindElement(By.XPath("//input[@type='text']"));
            elmField.SendKeys(TextBoxValue);
            driver.SwitchTo().ParentFrame();
        }
        public void ClickButton(IWebDriver driver, string ButtonName)
        {
            driver.SwitchTo().Frame(driver.FindElement(By.XPath(objElement.ContentFrame)));
            IWebElement elmForm = driver.FindElement(By.XPath(objElement.CenterPanel));
            IWebElement elmField = elmForm.FindElement(By.XPath("//input[@value='" + ButtonName + "']"));
            //IWebElement parent = elmField.FindElement(By.XPath("./.."));
            //IWebElement oSelect = elmField.FindElement(By.XPath("//input[@type='text']"));
            elmField.Click();
            driver.SwitchTo().ParentFrame();
        }
        public Boolean SelectRecord(IWebDriver driver,string ID)
        {
            driver.SwitchTo().Frame(driver.FindElement(By.XPath(objElement.ContentFrame)));
            IWebElement elmForm = driver.FindElement(By.XPath(objElement.CenterPanel));
            IWebElement elmField = elmForm.FindElement(By.XPath("//table//b//font[contains(text(),'Nonconformity')]"));
            if (elmField != null)
                return true;
            else
                return false;
            
            driver.SwitchTo().ParentFrame();
        }
    }
}
