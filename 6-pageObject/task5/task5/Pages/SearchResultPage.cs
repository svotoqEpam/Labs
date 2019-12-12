using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace task5
{
    public class SearchResultPage
    {
        public SearchResultPage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'n-snippet-card2 i-bem']")]
        private List<IWebElement> snippetCards;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'n-snippet-card2 i-bem']//a[@class = 'wishlist-control']")]
        private List<IWebElement> addToFavoriteButtons;

        public List<string> snippetCardTitles { get; private set; }

        public IWebElement favoriteElement { get; private set; }
        
        public SearchResultPage addToFavorite(int number)
        {
            addToFavoriteButtons[number].Click();
            favoriteElement = snippetCards[number];

            return this;
        }

        public SearchResultPage createSnippedCardTitlesList()
        {
            foreach (var card in snippetCards)
            {
                snippetCardTitles.Add(getTitle(card));
            }

            return this;
        }

        public string getTitle(IWebElement element)
        {
            return element.GetAttribute("title").ToLower();
        }
    }
}
