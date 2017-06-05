using Blog.Unit.Tests.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Unit.Tests.Pages.RegistrationPages
{
    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver)
           : base(driver)
        {
            AccessExcelData.fileName = "RegistrationData.xlsx";
        }

        //   public string URL
        //   {
        //       get
        //       {
        //           return base.url;
        //       }
        //   }
        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl("http://localhost:60638/Article/List");
            Registration.Click();
        }

        public void FillRegistrationForm(RegistrationUser user)
        {
            Type(Email, user.Email);
            Type(FullName, user.FullName);
            Type(Password, user.Password);
            Type(ConfirmPassword, user.ConfirmPassword);

            RegisterButton.Click();
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
