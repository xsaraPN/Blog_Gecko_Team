using Blog.Unit.Tests.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Unit.Tests.Pages.LoginPages
{
   public partial class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
            AccessExcelData.fileName = "LogInData.xlsx";
        }

      
        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl("http://localhost:60634/Article/List");
           LoginButtonMenu.Click();
        }

        public void FillLoginForm(LogInUser loginUser)
        {
            Type(EmailField, loginUser.Email);      
            Type(PasswordField, loginUser.Password);        

            LogInSubmit.Click();
        }

        private void Type(IWebElement element, string text)
        {

            element.Click();

            if (!text.Equals("Field-Empty"))
            {
                element.SendKeys(text);

            }
        }

      
      
    }
}
