using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using NUnit.Framework;
using System.Net;

namespace Automation.PageObjects
{
    class AddOrder
    {
        [FindsBy(How = How.LinkText, Using = "Orders")]
        IWebElement OrdersLink;

        [FindsBy(How = How.XPath, Using = "//button[text()='Create New']")]
        IWebElement CreateNewButton;

        [FindsBy(How = How.Id, Using = "mrn")]
        IWebElement MRN;

        [FindsBy(How = How.Id, Using = "first-name")]
        IWebElement FirstName;

        [FindsBy(How = How.Id, Using = "last-name")]
        IWebElement LastName;

        [FindsBy(How = How.Id, Using = "accession-number")]
        IWebElement AccessionNumber;

        [FindsBy(How = How.Id, Using = "org-code")]
        IWebElement Organisation;

        [FindsBy(How = How.Id, Using = "site-id")]
        IWebElement Site;

        [FindsBy(How = How.Id, Using = "modality")]
        IWebElement Modality;

        [FindsBy(How = How.Id, Using = "study-date-time")]
        IWebElement StudyDateTime;

        [FindsBy(How = How.CssSelector, Using = "button[type=submit]")]
        IWebElement Submit;

        [FindsBy(How = How.XPath, Using = "//button[text()='Cancel']")]
        IWebElement CancelButton;


        public IWebDriver driver;
        public AddOrder(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void AddNewOrder(OrderData orderData)
        {
            OrdersLink.Click();
            Utilities.CheckWebElementExistsAndVisible(driver, "//button[text()='Create New']");
            CreateNewButton.Click();
            Utilities.CheckWebElementExistsAndVisible(driver, "//input[@id='mrn']");
            Utilities.ScreenCapture(driver, "NewOrderScreen");

            MRN.SendKeys(orderData.MRN);
            FirstName.SendKeys(orderData.FirstName);
            LastName.SendKeys(orderData.LastName);
            AccessionNumber.SendKeys(orderData.AccessionNumber);
            // 
            SelectElement lstOrganisation = new SelectElement(Organisation);
            lstOrganisation.SelectByText(orderData.Organisation);
            //
            SelectElement lstSite = new SelectElement(Site);
            lstSite.SelectByText(orderData.SiteId);
            //
            SelectElement lstModality = new SelectElement(Modality);
            lstModality.SelectByText(orderData.Modality);
            //
            string[] DateTimeData = orderData.StudyDateTime.Split(" ");
            StudyDateTime.SendKeys(DateTimeData[0] + Keys.ArrowRight + DateTimeData[1] + Keys.ArrowRight + DateTimeData[2]);

            Utilities.ScreenCapture(driver, "AddedData");
            Submit.Click();

            Utilities.CheckWebElementExistsAndVisible(driver, "//button[text()='Create New']");
            Utilities.ScreenCapture(driver, "OrderAdded");
        }

        public void TryAddNewOrder(OrderData orderData)
        {
            OrdersLink.Click();
            Utilities.CheckWebElementExistsAndVisible(driver, "//button[text()='Create New']");
            CreateNewButton.Click();
            Utilities.CheckWebElementExistsAndVisible(driver, "//input[@id='mrn']");
            Utilities.ScreenCapture(driver, "NewOrderScreen");

            MRN.SendKeys(orderData.MRN);
            FirstName.SendKeys(orderData.FirstName);
            LastName.SendKeys(orderData.LastName);
            AccessionNumber.SendKeys(orderData.AccessionNumber);
            if (!string.IsNullOrEmpty(orderData.Organisation))
            {
                SelectElement lstOrganisation = new SelectElement(Organisation);
                lstOrganisation.SelectByText(orderData.Organisation);
            }
            if (!string.IsNullOrEmpty(orderData.Organisation))
            {
                if (!string.IsNullOrEmpty(orderData.SiteId))
                {
                    SelectElement lstSite = new SelectElement(Site);
                    lstSite.SelectByText(orderData.SiteId);
                }
            }
            if (!string.IsNullOrEmpty(orderData.Modality))
            {
                SelectElement lstModality = new SelectElement(Modality);
                lstModality.SelectByText(orderData.Modality);
            }
            if (!string.IsNullOrEmpty(orderData.StudyDateTime))
            {
                string[] DateTimeData = orderData.StudyDateTime.Split(" ");
                StudyDateTime.SendKeys(DateTimeData[0] + Keys.ArrowRight + DateTimeData[1] + Keys.ArrowRight + DateTimeData[2]);
            }

            Utilities.ScreenCapture(driver, "AddedData");
            Submit.Click();

            Utilities.ScreenCapture(driver, "ErrorMessage");
        }

        public void VerifyErrorDisplayed(string errorMsg)
        {
            string strIdentifier = "//div[contains(@class,'row')]//div[text()=' "
                + errorMsg + " ']";

            bool errorMsgExists = Utilities.CheckWebElementExistsAndVisible(driver, strIdentifier);
            Assert.True(errorMsgExists);
            CancelButton.Click();
        }

    }
}
