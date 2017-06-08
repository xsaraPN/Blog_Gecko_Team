﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages.LoginPage
{
    public static class LoginPageAsserter
    {
        public static void AssertLogo(this LoginPage page)
        {
            //Assert.AreEqual("SOFTUNI BLOG", page.Logo.Text);
        }

        public static void AssertLoginFormEmailError(this LoginPage page, string text)
        {

            Assert.AreEqual(text, page.EmailError.Text);
        }

        public static void AssertLoginFormPasswordError(this LoginPage page, string text)
        {

            Assert.AreEqual(text, page.PasswordError.Text);

        }

        public static void AssertInvalidPasswordError(this LoginPage page, string text)
        {

            Assert.AreEqual(text, page.InvalidPassword.Text);

        }

        public static void AssertInvalidEmailError(this LoginPage page, string text)
        {
            Assert.AreEqual(text, page.InvalidEmail.Text);
        }

        public static void SuccessfulLogin(this LoginPage page, string text)
        {
            Assert.AreEqual(text, page.ManageUser.Text);
        }

        public static void AssertPageUrl(this LoginPage loginUser)
        {
            Assert.AreEqual("http://localhost:60639/Article/Login", loginUser.URL);
        }

        public static void AssertLoginUser(this LoginPage loginUser)
        {
            Assert.AreEqual($"Hello {loginUser.EMAIL}!", loginUser.ManageUser.Text);
        }

        public static void AssertAccountLogin(this LoginPage loginUser)
        {
            try
            {
                string mainURL = loginUser.Driver.Url;               
                Assert.IsTrue(mainURL.Contains("http://localhost:60639/Account/Login"));
            }
            
             catch (Exception e)
            {
                loginUser.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Wrong URL {loginUser.Driver.Url}");
            }
        }
    }
}
