﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;
using SeleniumExtras.WaitHelpers;

namespace Automation.PageObjects
{
    public class Utilities
    {
        public IWebDriver driver;
        public static string CurrentTestCaseResultPath;

        public Utilities(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static void ScreenCapture(IWebDriver driver, string fileName)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(CurrentTestCaseResultPath + "\\" + fileName + ".png");
        }

        public static bool CheckWebElementExistsAndVisible(IWebDriver driver, string strIdentifier)
        {
            var dWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement dynamicElement;
            try
            {
                dynamicElement = dWait.Until(ExpectedConditions.ElementExists(By.XPath(strIdentifier)));
                if (dynamicElement.Displayed)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static bool CheckWebElementInvisible(IWebDriver driver, string strIdentifier)
        {
            var dWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            bool dynamicElement;
            try
            {
                dynamicElement = dWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(strIdentifier)));
                return dynamicElement;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
