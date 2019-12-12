using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;


namespace task5
{
    public class HeaderPageFragment
    {
        public HeaderPageFragment(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id = 'header-search']")]
        private IWebElement searchInput;

        [FindsBy(How = How.XPath, Using = "//span[@class = 'search2__button']//following::button[0]")]
        private IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = "//a[@class = 'header2-menu__item_type_wishlist']")]
        private IWebElement favoritesButton;

        public HeaderPageFragment serachObject(string name)
        {
            searchInput.SendKeys(name);
            searchButton.Click();

            return this;
        }

        public HeaderPageFragment navToFavourites()
        {
            favoritesButton.Click();

            return this;
        }
    }
}
