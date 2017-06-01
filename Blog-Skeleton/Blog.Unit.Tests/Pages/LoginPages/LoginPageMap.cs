using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Unit.Tests.Models;

namespace Blog.Unit.Tests.Pages.LoginPages
{
    public partial class LoginPage
    {
        public IWebElement LoginButtonMenu
        {
            get
            {
                return this.Driver.FindElement(By.Id("loginLink"));
            }
        }
        public IWebElement EmailField
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"Email\"]"));
            }
        }
        public IWebElement PasswordField
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"Password\"]"));
            }
        }
        public IWebElement LogInSubmit
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input"));
            }
        }
        public IWebElement EmailError
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/div/span/span"));
            }
        }                                               
        public IWebElement PasswordError
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[2]/div/span/span"));
            }
        }
        public IWebElement InvalidLoginError
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }

    }
}
