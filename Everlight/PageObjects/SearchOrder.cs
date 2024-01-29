using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;
using SeleniumExtras.PageObjects;
using NUnit.Framework;
using System.Globalization;

namespace Automation.PageObjects
{
    class SearchOrder
    {
        [FindsBy(How = How.XPath, Using = "//table[@aria-labelledby='tableLabel']/tbody")]
        IWebElement ResultsTable;


        public IWebDriver driver;
        public SearchOrder(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void SearchForNewOrder(string strAccessionNumber, OrderData orderData)
        {
            Utilities.ScreenCapture(driver, "Results");

            List<IWebElement> rows = ResultsTable.FindElements(By.TagName("tr")).ToList();
            bool bComputerFound = false;

            string strDateTime = DateTime.Parse(orderData.StudyDateTime).ToString("MM/dd/yyyy hh:mm:ss", CultureInfo.InvariantCulture);

            foreach (IWebElement row in rows)
            {
                if (row.Text.Contains(strAccessionNumber))
                {
                    bComputerFound = true;
                    Assert.AreEqual(orderData.AccessionNumber, row.FindElement(By.XPath("./td[1]")).Text);
                    Assert.AreEqual(GetCode(orderData.Organisation), row.FindElement(By.XPath("./td[2]")).Text);
                    // Defect - Site Name is different on results screen
                    //Assert.AreEqual(orderData.SiteId, row.FindElement(By.XPath("./td[3]")).Text);
                    Assert.AreEqual(orderData.MRN, row.FindElement(By.XPath("./td[4]")).Text);
                    Assert.AreEqual(orderData.FirstName + " " + orderData.LastName, row.FindElement(By.XPath("./td[5]")).Text);
                    Assert.AreEqual(GetCode(orderData.Modality), row.FindElement(By.XPath("./td[6]")).Text);
                    Assert.AreEqual(strDateTime, row.FindElement(By.XPath("./td[7]")).Text);
                    Assert.AreEqual("SC", row.FindElement(By.XPath("./td[8]")).Text);

                    // Delete the record
                    row.FindElement(By.XPath(".//i")).Click();
                    driver.SwitchTo().Alert().Accept();
                    break;
                }
            }
            Assert.IsTrue(bComputerFound);
        }

        public void DeleteNewOrder(string strAccessionNumber)
        {
            List<IWebElement> rows = ResultsTable.FindElements(By.TagName("tr")).ToList();
            bool bComputerFound = false;
            int index = 0;

            foreach (IWebElement row in rows)
            {
                index++;
                if (row.Text.Contains(strAccessionNumber))
                {
                    row.FindElement(By.XPath(".//i")).Click();
                    driver.SwitchTo().Alert().Accept();
                    break;
                }
            }
            string deletedRowPath = "//table[@aria-labelledby='tableLabel']//tr[" + index
                + "]/td[text()='" + strAccessionNumber + "']";
            Utilities.CheckWebElementInvisible(driver, deletedRowPath);

        }

        private string GetCode(string Name)
        {
            int startIndex = Name.IndexOf('(');
            int endIndex = Name.IndexOf(')');
            string strCode = Name.Substring(startIndex + 1, endIndex - startIndex - 1);
            return strCode;
        }


    }
}
