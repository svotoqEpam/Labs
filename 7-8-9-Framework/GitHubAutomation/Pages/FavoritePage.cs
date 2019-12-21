using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Models;
using System.Collections.Generic;

namespace GitHubAutomation.Pages
{
    class FavoritePage
    {
        private IWebDriver driver;

        public FavoritePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        private IWebElement getTitle(Phone phone)
        {
            var snippetCards = driver.FindElements(By.ClassName("n-snippet-card"));
            foreach (var snippetCard in snippetCards)
            {
                var cardTitle = snippetCard.FindElement(By.ClassName("snippet-card__header-link"));
                if (cardTitle.GetProperty("title").ToLower().Contains(phone.Name.ToLower()))
                {
                    return snippetCard;
                }
            }
            return null;
        }

        public bool IsAddedToFavorite(Phone phone)
        {
            return getTitle(phone) != null;
        }
    }
}
