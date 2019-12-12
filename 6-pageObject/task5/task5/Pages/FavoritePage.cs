using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace task5.Pages
{
    public class FavoritePage
    {
        public FavoritePage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'n-snippet-card']")]
        private List<IWebElement> snippetCards;

        public List<string> snippetCardTitles { get; private set; }

        public FavoritePage createSnippedCardTitlesList()
        {
            foreach(var card in snippetCards)
            {
                snippetCardTitles.Add(card.GetAttribute("title").ToLower());
            }

            return this;
        }
    }
}
