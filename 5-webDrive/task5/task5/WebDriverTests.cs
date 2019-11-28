using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace task5
{
    [TestFixture]
    public class WebDriverTests
    {
        public IWebDriver webDriver;
        [SetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            webDriver.Navigate().GoToUrl("https://market.yandex.by/");
        }

        [TearDown]
        public void QuitDriver()
        {
            webDriver.Quit();
        }

        [Test]
        public void SearchResultIsExists()
        {
            #region TestData
            string phoneName = "huawei p10 plus";
            string phoneElementPath = ".//div[@class='n-snippet-cell2__title']/a[@class='link n-link_theme_blue link_type_cpc i-bem link_js_inited']";
            string searchInputId = "header-search";
            string searchButtonClassName = "button2_js_inited";
            var testResult = false;
            #endregion

            var searchInput = webDriver.FindElement(By.Id(searchInputId));
            searchInput.SendKeys(phoneName);

            var searchButton = webDriver.FindElement(By.ClassName(searchButtonClassName));
            searchButton.Click();

            var resultList = webDriver.FindElements(By.XPath(phoneElementPath));
            foreach(var element in resultList)
            {
                var elemntTitle = element.GetAttribute("title").ToLower();
                if(elemntTitle.Contains(phoneName))
                {
                    testResult = true;
                }
            }
            Assert.IsTrue(testResult);
        }

        [Test]
        public void AddToFaivoriteWork()
        {
            #region TestData
            string phoneName = "huawei p10 plus";
            string searchInputId = "header-search";
            string searchButtonClassName = "button2_js_inited";
            string addToFavoriteElementPath = ".//a[@class='n-product-toolbar__item link link_theme_minor wishlist-control wishlist-control_type_toggle pseudo-checkbox hint b-zone b-spy-events i-bem sign_js_inited pseudo-checkbox_js_inited hint_js_inited wishlist-control_js_inited metrika_js_inited link_js_inited _popup2-destructor _popup2-destructor_js_inited b-zone_js_inited b-spy-events_js_inited']";
            string favoritesElementPath = ".//a[@class='link header2-menu__item header2-menu__item_type_wishlist blackfriday-tooltip-popup-opener i-bem link_js_inited']";
            string elementInFavoritesPath = ".//a[@class='n-snippet-card snippet-card clearfix i-bem b-zone n-wish selectable-item selectable-item_js_inited n-wish_js_inited n-snippet-card_js_inited']";
            var testResult = false;
            #endregion

            var searchInput = webDriver.FindElement(By.Id(searchInputId));
            searchInput.SendKeys(phoneName);

            var searchButton = webDriver.FindElement(By.ClassName(searchButtonClassName));
            searchButton.Click();

            var firstFoundElement = webDriver.FindElement(By.XPath(addToFavoriteElementPath));
            firstFoundElement.Click();

            var favoritesButton = webDriver.FindElement(By.XPath(favoritesElementPath));
            favoritesButton.Click();

            testResult = webDriver.FindElements(By.XPath(elementInFavoritesPath)).Count > 0;
            Assert.IsTrue(testResult);
        }
    }
}