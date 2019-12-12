using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using task5.Pages;

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
        public void IsSearchResult()
        {
            #region TestData
            string phoneName = "huawei p10 plus";
            bool testResult = false;
            #endregion

            HeaderPageFragment headerPageFragment = new HeaderPageFragment(webDriver);
            headerPageFragment.serachObject(phoneName);

            SearchResultPage searchResultPage = new SearchResultPage(webDriver);
            searchResultPage.createSnippedCardTitlesList();
            foreach(var title in searchResultPage.snippetCardTitles)
            {
                if(title.Contains(phoneName.ToLower()))
                {
                    testResult = true;
                    break;
                }
            }
            Assert.IsTrue(testResult);
        }

        [Test]
        public void IsAddToFaivoriteWork()
        {
            #region TestData
            string phoneName = "huawei p10 plus";
            bool testResult = false;
            #endregion

            HeaderPageFragment headerPageFragment = new HeaderPageFragment(webDriver);
            headerPageFragment.serachObject(phoneName);

            SearchResultPage searchResultPage = new SearchResultPage(webDriver);
            searchResultPage.addToFavorite(0);

            headerPageFragment.navToFavourites();

            FavoritePage favoritePage = new FavoritePage(webDriver);
            favoritePage.createSnippedCardTitlesList();

            foreach (var title in favoritePage.snippetCardTitles)
            {
                if (title.Contains(phoneName.ToLower()))
                {
                    testResult = true;
                    break;
                }
            }

            Assert.IsTrue(testResult);
        }
    }
}