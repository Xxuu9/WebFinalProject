using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
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
        private string testSearchUrl = "http://localhost:5000/";
        private string testIndexUrl = "http://localhost:5000/BreedList";
        private string testImageUrl = "http://localhost:5000/BreedList/ShowImage?id=158";

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
        [DataRow("terrier", "both", "terrier american")]
        [DataRow("sp", "main_breed", "springer")]
        [DataRow("australian", "sub_breed", "australian")]
        public void VerifySearchResult(string searchValue, string searchType, string expectedResult)
        {
            _driver.Url = testSearchUrl;
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

        [DataTestMethod]
        [DataRow("australian")]
        [DataRow("shepherd")]
        public void VerifyIndexResult(string expectedMainBreed)
        {
            _driver.Url = testIndexUrl;
            var output = _driver.FindElementById("breed_table");
            var answer = output.Text;
            StringAssert.Contains(answer, expectedMainBreed);
        }


        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
