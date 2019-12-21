using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Models;

namespace GitHubAutomation.Pages
{
    class ProductPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "title_size_28")]
        private IWebElement productTitle;

        [FindsBy(How = How.ClassName, Using = "n-product-tabs__item_name_spec")]
        private IWebElement specTabButton;
        
        public ProductPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public bool IsProductNameExist(Phone phone)
        {

            var title = productTitle.Text;
            return title.ToLower().Contains(phone.Name.ToLower());
        }

        public SpecTab GoToSpecTab()
        {
            specTabButton.Click();

            return new SpecTab(driver);
        }
    }
}
