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
        
        [FindsBy(How = How.ClassName, Using = "n-compare-cell-draggable")]
        private IList<IWebElement> snippetCards;

        [FindsBy(How = How.ClassName, Using = "n-compare-row-name")]
        private IList<IWebElement> comparisonParameters;

        private const string snippetCardTitleClassName = "n-compare-head__name";
        
        public ComparisonPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        private IWebElement getTitle(Phone phone)
        {
            foreach (var snippetCard in snippetCards)
            {
                var cardTitle = snippetCard.FindElement(By.ClassName(snippetCardTitleClassName));
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
