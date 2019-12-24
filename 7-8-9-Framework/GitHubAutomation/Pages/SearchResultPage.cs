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

        [FindsBy(How = How.ClassName, Using = "n-snippet-card2")]
        private IList<IWebElement> snippetCards;

        const string snippetCardTitleClassName = "n-link_theme_blue";

        const string cardToFavoriteClassName = "wishlist-control";
        
        const string cardToComparisonClassName = "n-user-lists_type_compare";

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
            foreach (var snippetCard in snippetCards)
            {
                var cardTitle = snippetCard.FindElement(By.ClassName(snippetCardTitleClassName));
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
            var toFavorite = card.FindElement(By.ClassName(cardToFavoriteClassName));
            toFavorite.Click();

            return this;
        }

        public SearchResultPage AddToComparison(Phone phone)
        {
            normalizeView();

            var card = getCard(phone);
            var toComparison = card.FindElement(By.ClassName(cardToComparisonClassName));
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

            return snippetCards != null;
        }
   
        public ProductPage OpenPhonePage(Phone phone)
        {
            normalizeView();

            var card = getCard(phone);
            var url = card.FindElement(By.ClassName(snippetCardTitleClassName)).GetAttribute("href");
            driver.Navigate().GoToUrl(url);

            return new ProductPage(driver);
        }
    }
}
