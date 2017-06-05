using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages
{
    public partial class Page : BasePage
    {
        public Page(IWebDriver driver)
            : base(driver)
        {
        }

        public void NavigateTo()
        {//changed port
            this.Driver.Navigate().GoToUrl(@"http://localhost:60638/Article/List");
        }
        public void CheckRegistrationPage()
        {
            RegisterButton.Click();

        }
        public void ClickLoginButton()
        {
            LoginPageButton.Click();
        }

    }
}
