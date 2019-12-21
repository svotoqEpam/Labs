using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Models;

namespace GitHubAutomation.Pages
{  
    class MainPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = ".//input[@id = 'header-search']")]
        private IWebElement searchInput;

        [FindsBy(How = How.ClassName, Using = "button2_type_submit")]
        private IWebElement searchButton;

        [FindsBy(How = How.ClassName, Using = "n-w-tab_type_navigation-menu-vertical")]
        private IWebElement electronicsCategory;

        [FindsBy(How = How.ClassName, Using = "n-w-tab_type_navigation-menu-grouping")]
        private IWebElement categoryMenu;

        [FindsBy(How = How.ClassName, Using = "user__login")]
        private IWebElement loginButton;

        [FindsBy(How = How.ClassName, Using = "header2-menu__item_type_region")]
        private IWebElement changeLocationButton;

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        private void WaitForAjax()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0"));
        }

        public SearchResultPage SearchObject(Phone phone)
        {
            searchInput.SendKeys(phone.Name);

            searchButton.Click();

            return new SearchResultPage(driver);
        }

        public CategoryPage GoToElectronicsCategory()
        {
            categoryMenu.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(electronicsCategory));
            electronicsCategory.Click();

            return new CategoryPage(driver);
        }

        public LoginPage LoginUser()
        {
            var url = loginButton.GetAttribute("href");
            driver.Navigate().GoToUrl(url);

            return new LoginPage(driver);
        }

        public MainPage ChangeRegion(Location location)
        {
            changeLocationButton.Click();
            WaitForAjax();

            var input = driver.FindElement(By.ClassName("manotice_type_popup"))
                .FindElement(By.ClassName("input__control"));
            input.SendKeys(location.Region);
            WaitForAjax();
            driver.FindElement(By.ClassName("suggestick-list__item")).Click();
            
            driver.FindElement(By.ClassName("region-select-form__continue-with-new")).Click();

            return this;
        }

        public bool IsNewRegion(Location location)
        {
            var settedRegion = changeLocationButton.FindElement(By.ClassName("header2-menu__text")).Text;
            return settedRegion.ToLower() == location.Region.ToLower();
        }
    }
}
