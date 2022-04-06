using D4.TestAutomation.Helper.Source;
using Eurofins.D4.Automation.GenericsForm.Source;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eurofins.D4.Automation.GenericsForm.Source
{
    class PTS_FieldsValidation_PTOffer
    {
        //LaunchD4Site obj = new LaunchD4Site();
        GenericFormHelper repo = new GenericFormHelper();
        ObjectMethod objElement = new ObjectMethod();
        public static IWebDriver driver;
        string[] fieldsName = { "PT Type", "PT ID","PT Provider Name","PT Provider Code","PT Logger","Estimated Date","BU","SBU","Accreditation","Matrix","Family Matrix","Parameter" };
        [Test]
        public void PTOfferFieldValidation()
        {
            driver = objElement.GettingDriver();
            string[] elmFields = repo.FieldsNameInTheForm(driver);
            for (int i = 0; i < fieldsName.Length; i++)
            {
                Assert.Contains(fieldsName[i], elmFields);
            }
        }
    }
}
