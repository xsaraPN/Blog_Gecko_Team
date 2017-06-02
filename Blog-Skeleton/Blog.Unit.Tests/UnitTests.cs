using Blog.Unit.Tests.Models;
using Blog.Unit.Tests.Pages.LoginPages;
using Blog.Unit.Tests.Pages.RegistrationPages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Blog.Unit.Tests
{
    [TestFixture]
    public class UnitTests
    {
        IWebDriver driver;

        [SetUp]
        public void Init()
        {
          this.driver = BrowserHost.Instance.Application.Browser;
        }

        [TearDown]
        public void CleanUp()
        {
            this.driver.Quit();
        }        

     // // [Test, Property("Registration", 1)]
     //  public void RegistrationWithEmptyFields()
     //  {
     //
     //      var regPage = new RegistrationPage(driver);
     //      var user = AccessExcelData.GetRegistrationTestData("RegistrationWithEmptyFields");
     //
     //      regPage.NavigateTo();
     //      regPage.FillRegistrationForm(user);
     //
     //      regPage.AssertRegistration("The Email field is required.");
     //      regPage.AssertRegistration("The Full Name field is required.");
     //      regPage.AssertRegistration("The Password field is required.");
     //  }

        [Test, Property("Registration",1)]
        public void RegistrationWithInvalidEmail()
        {
            var regPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetRegistrationTestData("RegistrationWithInvalidEmail");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertRegistrationFormError("The Email field is not a valid e-mail address.");
        }


        [Test, Property("Registration", 1)]
        public void RegistrationWithoutPassword()
        {
            var regPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetRegistrationTestData("RegistrationWithoutPassword");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);
            regPage.AssertRegistrationFormError("The Password field is required.");
        }
        [Test, Property("Registration", 1)]
        public void RegistrationWithoutConfirmPassword()
        {
            var regPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetRegistrationTestData("RegistrationWithoutConfirmPassword");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertRegistrationFormError("The password and confirmation password do not match.");
        }
        [Test, Property("Registration", 1)]
        public void RegistrationWithoutEmail()
        {
            var regPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetRegistrationTestData("RegistrationWithoutEmail");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertRegistrationFormError("The Email field is required.");
        }

        [Test, Property("Login", 1)]
        public void LoginWithEmptyFields()
        {
            var loginPage = new LoginPage(driver);
            var loginUser = AccessExcelData.GetLoginTestData("LoginWithEmptyFields");

            loginPage.NavigateTo();
            loginPage.FillLoginForm(loginUser);

            loginPage.AssertLoginFormEmailError("The Email field is required.");
            loginPage.AssertLoginFormPasswordError("The Password field is required.");
          
        }

        [Test, Property("Login", 1)]
        public void LoginWithoutEmail()
        {
            var loginPage = new LoginPage(driver);
            var loginUser = AccessExcelData.GetLoginTestData("LoginWithoutEmail");

            loginPage.NavigateTo();
            loginPage.FillLoginForm(loginUser);

            loginPage.AssertLoginFormEmailError("The Email field is required.");
           
        }

        [Test, Property("Login", 1)]
        public void LoginWithoutPassword()
        {
            var loginPage = new LoginPage(driver);
            var loginUser = AccessExcelData.GetLoginTestData("LoginWithoutPassword");

            loginPage.NavigateTo();
            loginPage.FillLoginForm(loginUser);

            loginPage.AssertLoginFormPasswordError("The Password field is required.");


        }

        [Test, Property("Login", 1)]
        public void LoginWitInvalidEmail()
        {
            var loginPage = new LoginPage(driver);
            var loginUser = AccessExcelData.GetLoginTestData("LoginWitInvalidEmail");

            loginPage.NavigateTo();
            loginPage.FillLoginForm(loginUser);

            loginPage.AssertLoginFormEmailError("The Email field is not a valid e-mail address.");


        }
        [Test, Property("Login", 1)]
        public void LoginWitInvalidData()
        {
            var loginPage = new LoginPage(driver);
            var loginUser = AccessExcelData.GetLoginTestData("LoginWitInvalidData");

            loginPage.NavigateTo();
            loginPage.FillLoginForm(loginUser);

            loginPage.AssertInvalidLoginFormError("Invalid login attempt.");


        }
    }
}