using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Models;
using System.Collections.Generic;

namespace GitHubAutomation.Pages
{
    class LoginPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "passp-field-login")]
        private IWebElement loginField;

        [FindsBy(How = How.Id, Using = "passp-field-passwd")]
        private IWebElement passwordField;
        
        [FindsBy(How = How.ClassName, Using = "button2_type_submit")]
        private IWebElement submitButton;

        [FindsBy(How = How.ClassName, Using = "passp-form-field__error")]
        private IWebElement errorMessage;

        public LoginPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }
        private void WaitForAjax()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0"));
        }

        public bool IsWrongPassword(User user)
        {
            loginField.SendKeys(user.Name);
            submitButton.Click();
            WaitForAjax();

            passwordField.SendKeys(user.Password);
            submitButton.Click();

            return errorMessage.Text.ToLower() == user.WrongPasswordMessage.ToLower();
        }
    }
}
