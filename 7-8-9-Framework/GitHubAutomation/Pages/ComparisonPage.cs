using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Models;
using System.Collections.Generic;

namespace GitHubAutomation.Pages
{
    class ComparisonPage
    {
        private IWebDriver driver;

        public ComparisonPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        private IList<IWebElement> getSnippetCards()
        {
            return driver.FindElements(By.ClassName("n-compare-cell-draggable"));
        }

        private IList<IWebElement> getComparisonParameters()
        {
            return driver.FindElements(By.ClassName("n-compare-row-name"));
        }

        private IWebElement getTitle(Phone phone)
        {
            var snippetCards = getSnippetCards();
            foreach (var snippetCard in snippetCards)
            {
                var cardTitle = snippetCard.FindElement(By.ClassName("n-compare-head__name"));
                if (cardTitle.Text.ToLower().Contains(phone.Name.ToLower()))
                {
                    return snippetCard;
                }
            }
            return null;
        }

        public bool IsAddedToComparison(Phone phone)
        {
            return getTitle(phone) != null;
        }

        public bool HasComparisonParameter(Phone phone)
        {
            var comparisonParameters = getComparisonParameters();
            foreach (var parameter in comparisonParameters)
            {
                if(parameter.Text.ToLower().Contains(phone.ComparisonParameter.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
