using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Models;
using System.Collections.Generic;
using NUnit.Framework;

namespace GitHubAutomation.Pages
{
    class SearchResultPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "header2-menu__item_type_wishlist")]
        private IWebElement favoritesButton;

        [FindsBy(How = How.ClassName, Using = "header2-menu__item_type_compare")]
        private IWebElement comparisonButton;

        [FindsBy(How = How.ClassName, Using = "radio-button__radio_side_right")]
        private IWebElement changeViewButton;

        public SearchResultPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        private void WaitForAjax()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0"));
        }

        private void normalizeView()
        {
            changeViewButton.Click();
            WaitForAjax();
        }

        private IWebElement getCard(Phone phone)
        {
            var snippetCards = driver.FindElements(By.ClassName("n-snippet-card2"));
            foreach (var snippetCard in snippetCards)
            {
                var cardTitle = snippetCard.FindElement(By.ClassName("n-link_theme_blue"));
                if (cardTitle.GetProperty("title").ToLower().Contains(phone.Name.ToLower()))
                {
                    return snippetCard;
                }
            }
            return null;
        }
      

        public bool HasPhone(Phone phone)
        {
            normalizeView();

            return getCard(phone) != null;
        }

        public SearchResultPage AddToFavorite(Phone phone)
        {
            normalizeView();

            var card = getCard(phone);
            var toFavorite = card.FindElement(By.ClassName("wishlist-control"));
            toFavorite.Click();

            return this;
        }

        public SearchResultPage AddToComparison(Phone phone)
        {
            normalizeView();

            var card = getCard(phone);
            var toComparison = card.FindElement(By.ClassName("n-user-lists_type_compare"));
            toComparison.Click();

            return this;
        }

        public ComparisonPage GoToComparisonPage()
        {
            comparisonButton.Click();

            return new ComparisonPage(driver);
        }

        public FavoritePage GoToFavoritePage()
        {
            favoritesButton.Click();

            return new FavoritePage(driver);
        }

        public bool IsViewChanged()
        {
            normalizeView();

            return driver.FindElement(By.ClassName("n-snippet-card2")) != null;
        }
   
        public ProductPage OpenPhonePage(Phone phone)
        {
            normalizeView();

            var card = getCard(phone);
            var url = card.FindElement(By.ClassName("n-link_theme_blue")).GetAttribute("href");
            driver.Navigate().GoToUrl(url);

            return new ProductPage(driver);
        }
    }
}
