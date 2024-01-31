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

            string strDateTime = DateTime.ParseExact(orderData.StudyDateTime, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture)
                .ToString("dd/MM/yyyy HH:mm:ss");

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
                    break;
                }
            }
            Assert.IsTrue(bComputerFound);
        }

        public void VerifyOrdersListing(string DateTime1, string DateTime2)
        {
            Utilities.ScreenCapture(driver, "OrderOfResults");

            List<IWebElement> rows = ResultsTable.FindElements(By.TagName("tr")).ToList();
            int DateTime1Index = 0;
            int DateTime2Index = 0;
            //string strDateTime1 = DateTime.Parse(DateTime1).ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            //string strDateTime2 = DateTime.Parse(DateTime2).ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime dtDateTime1 = DateTime.ParseExact(DateTime1, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
            string strDateTime1 = dtDateTime1.ToString("dd/MM/yyyy HH:mm:ss");
            DateTime dtDateTime2 = DateTime.ParseExact(DateTime2, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
            string strDateTime2 = dtDateTime2.ToString("dd/MM/yyyy HH:mm:ss");

            foreach (IWebElement row in rows)
            {
                DateTime1Index++;
                if (row.Text.Contains(strDateTime1))
                {
                    break;
                }
            }
            foreach (IWebElement row in rows)
            {
                DateTime2Index++;
                if (row.Text.Contains(strDateTime2))
                {
                    break;
                }
            }
            if (dtDateTime1 <= dtDateTime2)
            {
                Assert.That(DateTime1Index, Is.LessThan(DateTime2Index));
            }
            else
            {
                Assert.That(DateTime2Index, Is.LessThan(DateTime1Index));
            }
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
