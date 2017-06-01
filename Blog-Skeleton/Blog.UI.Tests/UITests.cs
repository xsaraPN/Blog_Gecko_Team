using Blog.UI.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests
{
    [TestFixture]
    public class UITests
    {
        IWebDriver driver = BrowserHost.Instance.Application.Browser;

        [Test]
        public void CheckSiteLoad()
        {
            var site = new Page(this.driver);

            site.NavigateTo();

            site.AssertSiteLogo("SOFTUNI BLOG");

        }
        [Test]
        public void CheckLoadRegistrationPage()
        {
            var regPage = new Page(driver);
            regPage.NavigateTo();

            regPage.CheckRegistrationPage();

            regPage.AssertPageIsOpen("Register");
        }

        [Test]
        public void CheckLoadLoginPage()
        {

            var loginPage = new Page(driver);

            loginPage.NavigateTo();
            loginPage.ClickLoginButton();

            loginPage.AssertPageIsOpen("Log in");


        }
    }
}