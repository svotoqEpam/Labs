using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using GitHubAutomation.Driver;
using GitHubAutomation.Pages;
using GitHubAutomation.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.Extensions;
using System.Runtime.Remoting.Messaging;
using GitHubAutomation.Models;

namespace GitHubAutomation.Tests
{
    [TestFixture]
    public class WebTests : GeneralConfig
    {
        const string ElectronicsCategoryPageUrl = "https://market.yandex.by/catalog--elektronika/54440";
        const string PhoneSpecTabPageUrl = "https://market.yandex.by/product--smartfon-huawei-p10-dual-sim-4-64gb/1720217048/spec?track=tabs";

        [Test]
        public void ChangeView()
        {
            Driver.Manage().Window.Maximize();
            TakeScreenshotWhenTestFailed(() =>
            {
                var phone = CreatePhone.WithPhoneName();
                SearchResultPage page = new MainPage(Driver)
                   .SearchObject(phone);
                Assert.IsTrue(page.IsViewChanged());
            });
        }

        [Test]
        public void IsSearchResult()
        {
            Driver.Manage().Window.Maximize();
            TakeScreenshotWhenTestFailed(() =>
            {
                var phone = CreatePhone.WithPhoneName();
                SearchResultPage page = new MainPage(Driver)
                   .SearchObject(phone);
                Assert.IsTrue(page.HasPhone(phone));
            });
        }

        [Test]
        public void IsAddedToFavorite()
        {
            Driver.Manage().Window.Maximize();
            TakeScreenshotWhenTestFailed(() =>
            {
                var phone = CreatePhone.WithPhoneName();
                FavoritePage page = new MainPage(Driver)
                   .SearchObject(phone)
                   .AddToFavorite(phone)
                   .GoToFavoritePage();
                Assert.IsTrue(page.IsAddedToFavorite(phone));
            });
        }

        [Test]
        public void IsAddedToComparison()
        {
            Driver.Manage().Window.Maximize();
            TakeScreenshotWhenTestFailed(() =>
            {
                var phone = CreatePhone.WithPhoneName();
                ComparisonPage page = new MainPage(Driver)
                   .SearchObject(phone)
                   .AddToComparison(phone)
                   .GoToComparisonPage();
                Assert.IsTrue(page.IsAddedToComparison(phone));
            });
        }

        [Test]
        public void HasComparisonParameter()
        {
            Driver.Manage().Window.Maximize();
            TakeScreenshotWhenTestFailed(() =>
            {
                var phone = CreatePhone.WithPhoneComparisonParameter();
                ComparisonPage page = new MainPage(Driver)
                   .SearchObject(phone)
                   .AddToComparison(phone)
                   .GoToComparisonPage();
                Assert.IsTrue(page.HasComparisonParameter(phone));
            });
        }

        [Test]
        public void CategoryMenu()
        {
            Driver.Manage().Window.Maximize();
            TakeScreenshotWhenTestFailed(() =>
            {
                CategoryPage page = new MainPage(Driver)
                   .GoToElectronicsCategory();
                Assert.AreEqual(ElectronicsCategoryPageUrl, page.GetUrlOfTheCategoryPage());
            });
        }

        [Test]
        public void IsLoginFailed()
        {
            Driver.Manage().Window.Maximize();
            var user = CreateUser.WithLogin();
            TakeScreenshotWhenTestFailed(() =>
            {
                LoginPage page = new MainPage(Driver)
                   .LoginUser();
                Assert.IsTrue(page.IsWrongPassword(user));
            });
        }

        [Test]
        public void OpenPhonePage()
        {
            Driver.Manage().Window.Maximize();
            TakeScreenshotWhenTestFailed(() =>
            {
                var phone = CreatePhone.WithPhoneName();
                ProductPage page = new MainPage(Driver)
                   .SearchObject(phone)
                   .OpenPhonePage(phone);
                Assert.IsTrue(page.IsProductNameExist(phone));
            });
        }

        [Test]
        public void ChangeCurrentRegion()
        {
            Driver.Manage().Window.Maximize();
            TakeScreenshotWhenTestFailed(() =>
            {
                var location = CreateLocation.WithRegion();
                MainPage page = new MainPage(Driver)
                   .ChangeRegion(location);
                Assert.IsTrue(page.IsNewRegion(location));
            });
        }

        [Test]
        public void GoToProductSpecTab()
        {
            Driver.Manage().Window.Maximize();
            TakeScreenshotWhenTestFailed(() =>
            {
                var phone = CreatePhone.WithPhoneName();
                SpecTab page = new MainPage(Driver)
                   .SearchObject(phone)
                   .OpenPhonePage(phone)
                   .GoToSpecTab();
                Assert.AreEqual(PhoneSpecTabPageUrl, page.GetUrlOfTheSpecTab());
            });
        }
    }
}
