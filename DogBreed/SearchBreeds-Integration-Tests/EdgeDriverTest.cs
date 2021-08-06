using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SearchBreeds_Integration_Tests
{
    [TestClass]
    public class EdgeDriverTest
    {
        // In order to run the below test(s), 
        // please follow the instructions from http://go.microsoft.com/fwlink/?LinkId=619687
        // to install Microsoft WebDriver.

        private ChromeDriver _driver;
        private string testUrl = "http://localhost:5000/";


        [TestInitialize]
        public void EdgeDriverInitialize()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            var options = new ChromeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            _driver = new ChromeDriver(options);
        }

        [DataTestMethod]
        [DataRow("Dog", "both", "Dog1")]
        [DataRow("2", "main_breed", "Dog2")]
        [DataRow("2", "sub_breed", "subdog2")]
        public void VerifyPageTitle(string searchValue, string searchType, string expectedResult)
        {
            // Replace with your own test logic
            _driver.Url = testUrl;
            var searchValueBox = _driver.FindElementById("search_value");
            var searchTypeBox = _driver.FindElementById(searchType);
            var searchButton = _driver.FindElementById("search");

            searchValueBox.SendKeys(searchValue);
            searchTypeBox.Click();
            searchButton.Click();

            var output = _driver.FindElementById("search_result");
            var answer = output.Text;

            Assert.AreEqual(expectedResult, answer);
        }

        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
