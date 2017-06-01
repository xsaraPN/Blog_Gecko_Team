using Blog.UI.Tests.Pages;
using Blog.UI.Tests.Pages.ArticlesDashboard;
using Blog.UI.Tests.Pages.CreateArticle;
using Blog.UI.Tests.Pages.Login;
using Blog.UI.Tests.Pages.RegisterUser;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blog.UI.Tests
{
    [TestFixture]
    public class UITests
    {
		IWebDriver driver = BrowserHost.Instance.Application.Browser;
        		
        [Test]
        public void CheckSiteLoad()
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(300));
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(BrowserHost.RootUrl);

            var logo = wait.Until(w => w.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a")));

            Assert.AreEqual("SOFTUNI BLOG", logo.Text);
        }

        [Test]
        public void FindArticleInDashboard()
        {            
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(60));
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(BrowserHost.RootUrl);
            Login loginuser=new Login(this.driver);
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("qwerty", "browser");
            ArticlesDashboard dash = new ArticlesDashboard(this.driver);
            dash.AssertNewArticle("qwerty");
        }

        [Test]
        public void AvailableScrollBarDashboard()
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(60));
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(BrowserHost.RootUrl);
            /*
            RegisterUser newUser = new RegisterUser(this.driver);
            newUser.RegisterUserNavigateTo();
            newUser.RegisterationOfUser("nikolova.petq@gmail.com", "Petya Nikolova", "P@ssw@rd");
            newUser.AssertNewUser("nikolova.petq@gmail.com");
            */
            Login loginuser = new Login(this.driver);
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");
            CreateArticle newArticle = new CreateArticle(driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("qwertyQWERTYqwertyQWERTYqwertyQWERTYqwertyQWERTY", "browserBROWSERbrowserBROWSERbrowserBROWSERbrowserBROWSERbrowserBROWSERbrowserBROWSERbrowserBROWSERbrowserBROWSERbrowserBROWSERbrowserBROWSER");
            ArticlesDashboard dash = new ArticlesDashboard(this.driver);
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            dash.AssertNewArticle("qwertyQWERTYqwertyQWERTYqwertyQWERTYqwertyQWERTY");
            ScrollableControl ctl = new ScrollableControl();
            ScrollBars scroll = dash.GetVisibleScrollbars(ctl);

            if (scroll.Equals(ScrollBars.None))
            {
                dash.log.Info("No scroll bars are shown.");
                Assert.Fail();
            }
            else if (scroll.Equals(ScrollBars.Both))
            {
                dash.log.Info("Both horizontal and vertical scroll bars are shown.");
                Assert.Pass();
            }
            else if (scroll.Equals(ScrollBars.Horizontal))
            {
                dash.log.Info("Only horizontal scroll bars are shown.");
                Assert.Fail();
            }
            else if (scroll.Equals(ScrollBars.Vertical))
            {
                dash.log.Info("Only vertical scroll bars are shown.");
                Assert.Fail();
            }
        }
			
/*
        [Test]
        public void CheckSiteLoad()
        {
            var site = new Page(this.driver);

            site.NavigateTo();

            site.AssertSiteLogo("SOFTUNI BLOG");

        }
		*/
		
        [Test]
        public void CheckLoadRegistrationPage()
        {
            var regPage = new Page(this.driver);
            regPage.NavigateTo();

            regPage.CheckRegistrationPage();

            regPage.AssertPageIsOpen("Register");
        }

        [Test]
        public void CheckLoadLoginPage()
        {

            var loginPage = new Page(this.driver);

            loginPage.NavigateTo();
            loginPage.ClickLoginButton();

            loginPage.AssertPageIsOpen("Log in");
        }		
    }
}
