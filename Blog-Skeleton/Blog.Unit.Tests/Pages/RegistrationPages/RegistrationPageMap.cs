using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Unit.Tests.Pages.RegistrationPages
{
    public partial class RegistrationPage
    {
        public IWebElement Email
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"Email\"]"));
            }
        }
        public IWebElement FullName
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"FullName\"]"));
            }
        }
        public IWebElement Password
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"Password\"]"));
            }
        }
        public IWebElement ConfirmPassword
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"ConfirmPassword\"]"));
            }
        }
        public IWebElement RegisterButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[6]/div/input"));
            }
        }
        public IWebElement Registration
        {

            get
            {

                return this.Driver.FindElement(By.Id("registerLink"));
            }
        }
        public IWebElement ErrorMessageEmailRequired
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li[1]"));
            }
        }
     public IWebElement Errors
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li[1]"));
             //   return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li[2]"));
              //  return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li[3]"));

            }
        }
        public IWebElement RegistrationFormError
        {
            get
            {
                return this.Driver.FindElement(By.CssSelector(" body > div.container.body-content > div > div > form > div.text-danger.validation-summary-errors > ul > li"));

               
            }
        }
        public IWebElement RegistrationError
        {
            get
            {
                return this.Driver.FindElement(By.ClassName(" body > div.container.body-content > div > div > form > div.text-danger.validation-summary-errors > ul > li"));


            }
        }
        
        public IList<IWebElement> eror
        {
            get
            {
                return this.Driver.FindElements(By.CssSelector("body > div.container.body-content > div > div > form > div.text-danger.validation-summary-errors > ul > li:nth-child"));
            }
        }
    }
   
}

