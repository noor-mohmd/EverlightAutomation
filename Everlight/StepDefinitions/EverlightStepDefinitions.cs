using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using Automation.PageObjects;

namespace Automation.StepDefinitions
{
    [Binding]
    public sealed class EverlightStepDefinitions
    {
        public IWebDriver driver { get; set; }

        public static string _currentDateTime;

        //public static string strProjectDir = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
        public static string strProjectDir = Environment.CurrentDirectory;

        public static string strTestResultsPath = Path.Combine(strProjectDir, "Results");

        public OrderData? OrderDataTable;
        public OrderAPIData? OrderAPITable;
        AddOrderAPI addOrder = new AddOrderAPI();

        public static void CustomSpecflowScenarioStart(string strScenarioTitle)
        {
            _currentDateTime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            Directory.CreateDirectory(Path.Combine(strTestResultsPath, strScenarioTitle.Replace(" ", "") + "_" + _currentDateTime));
            Utilities.CurrentTestCaseResultPath = Path.Combine(strTestResultsPath, strScenarioTitle.Replace(" ", "") + "_" + _currentDateTime);
        }

        public void InitializeDriver(string Browser)
        {
            driver = _InitializeDriver(driver, Browser);

        }

        [Given("the user is on home page")]
        public void GivenTheUserIsOnHomePage()
        {
            CustomSpecflowScenarioStart(ScenarioContext.Current.ScenarioInfo.Title);
            InitializeDriver("chrome");
            driver.Navigate().GoToUrl("https://localhost:44449/");

        }

        [When("the user adds a new order with following data")]
        public void WhenTheUserAddsANewOrderWithData(Table table)
        {
            var orderData = table.CreateInstance<OrderData>();

            this.OrderDataTable = orderData;
            AddOrder addOrder = new AddOrder(driver);
            addOrder.AddNewOrder(orderData);

        }

        [Then("the order should be added with accession number '(.*)'")]
        public void ThenTheOrderShouldBeAdded(string strAccessionNumber)
        {
            SearchOrder searchOrder = new SearchOrder(driver);
            searchOrder.SearchForNewOrder(strAccessionNumber, OrderDataTable);
        }

        [Then(@"delete the order with accession number '(.*)'")]
        public void ThenDeleteTheOrder(string strAccessionNumber)
        {
            SearchOrder searchOrder = new SearchOrder(driver);
            searchOrder.DeleteNewOrder(strAccessionNumber);
        }

        [Then(@"the order should be listed in ascending order of study datetime '(.*)', '(.*)'")]
        public void ThenTheOrderShouldBeListedInAscendingOrderOfStudyDatetime(string DateTime1, string DateTime2)
        {
            SearchOrder searchOrder = new SearchOrder(driver);
            searchOrder.VerifyOrdersListing(DateTime1, DateTime2);
        }

        [When(@"the user tries to add a new order with following data")]
        public void WhenTheUserTriesToAddANewOrderWithFollowingData(Table table)
        {
            var orderData = table.CreateInstance<OrderData>();

            AddOrder addOrder = new AddOrder(driver);
            addOrder.TryAddNewOrder(orderData);
        }

        [Then(@"the order should not be added with error '(.*)'")]
        public void ThenTheOrderShouldNotBeAddedWithError(string errorMsg)
        {
            AddOrder addOrder = new AddOrder(driver);
            addOrder.VerifyErrorDisplayed(errorMsg);
        }

        // API tests
        [Given("the user adds a new order using API with following data")]
        public void WhenTheUserAddsANewOrderUsingAPIWithData(Table table)
        {
            var orderAPIData = table.CreateInstance<OrderAPIData>();
            this.OrderAPITable = orderAPIData;
            addOrder.AddNewOrder(orderAPIData);
        }

        [Then(@"the order should be added with status code '([^']*)'")]
        public void ThenTheOrderShouldBeAddedWithStatusCode(int statusCode)
        {
            addOrder.CheckStatusCode(statusCode);
        }

        [Then(@"verify the order exists using API")]
        public void ThenVerifyTheOrderExistsUsingAPI()
        {
            addOrder.VerifyOrderExists(OrderAPITable);
        }

        [Then(@"delete the order using API")]
        public void ThenDeleteTheOrderUsingAPI()
        {
            addOrder.DeleteOrder();
        }

        [Then(@"the order should not be added with API error '(.*)'")]
        public void ThenTheOrderShouldNotBeAddedWithAPIError(string errorCode)
        {
            addOrder.VerifyErrorCode(errorCode);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }

        public IWebDriver _InitializeDriver(IWebDriver driver, string Browser)
        {
            string strDriverPath = Path.Combine(strProjectDir, "Drivers");

            switch (Browser.ToLower())
            {
                case "chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.Proxy = null;
                    options.AddArguments("disable-infobars");
                    options.AddArgument("--disable-extensions");
                    options.AddArgument("--start-maximized");
                    options.AddAdditionalOption("useAutomationExtension", false);
                    options.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
                    options.AddArgument("--ignore-certificate-errors");
                    driver = new ChromeDriver(strDriverPath, options);
                    break;

                case "internet explorer":
                case "ie":
                    var ieOptions = new InternetExplorerOptions();
                    ieOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    ieOptions.RequireWindowFocus = true;
                    ieOptions.EnsureCleanSession = true;
                    ieOptions.EnablePersistentHover = false;
                    ieOptions.IgnoreZoomLevel = true;
                    driver = new InternetExplorerDriver(strDriverPath, ieOptions);
                    break;

                default:
                    driver = new ChromeDriver(new ChromeOptions { Proxy = null });
                    break;
            }

            driver.Manage().Window.Maximize();

            return driver;
        }
    }
}
