using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages
{
    public partial class Page
    {
        public IWebElement RegisterButton
        {
            get
            {
                return this.Driver.FindElement(By.Id("registerLink"));
            }
        }
        public IWebElement PageTitle
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/h2"));
            }
        }
        public IWebElement Logo
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a"));
            }
        }
        public IWebElement LoginPageButton
        {
            get
            {
                return this.Driver.FindElement(By.Id("loginLink"));
            }
        }

    }
}
