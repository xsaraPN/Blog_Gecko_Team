﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace Blog.UI.Tests.Pages.ArticlesDashboard
{
    public static class ArticleDashboardAsserter
    {
        public static void AssertPageUrl(this ArticlesDashboard dash)
        {
            try
            {
                Assert.AreEqual("http://localhost:60639/Article/List", dash.Driver.Url);
            }            
             catch (Exception e)
            {
                dash.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"URL is wrong {dash.Driver.Url}");
            }
        }

        public static void AssertFunctionalMenuButtons(this ArticlesDashboard dash)
        {
            try
            {
                dash.CreateButton.Click();
                Assert.AreEqual("http://localhost:60639/Article/Create", dash.Driver.Url);
                dash.Driver.Navigate().Back();
                dash.ManageUser.Click();
                Assert.AreEqual("http://localhost:60639/Manage", dash.Driver.Url);
                dash.Driver.Navigate().Back();
                dash.LogOut.Click();
                dash.AssertPageUrl();
                Assert.IsTrue(dash.Login.Displayed);
                Assert.IsTrue(dash.Login.Enabled);
            }
            catch (Exception e)
            {
                dash.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Menu Buttons are not all");
            }
        }

        public static void AssertAvailableLoginButton(this ArticlesDashboard dash)
        {
            try
            {
                Assert.IsTrue(dash.Login.Displayed);
                Assert.IsTrue(dash.Login.Enabled);
            }
            catch (Exception e)
            {
                dash.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Create button is missing");
            }
        }

        public static void AssertAvailableCreateButton(this ArticlesDashboard dash)
        {
            try
            {
                Assert.IsTrue(dash.CreateButton.Displayed);
                Assert.IsTrue(dash.CreateButton.Enabled);                
            }
            catch (Exception e)
            {
                dash.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Create button is missing");
            }
        }

        public static void AssertAvailableManageUserButton(this ArticlesDashboard dash)
        {
            try
            {                
                Assert.IsTrue(dash.ManageUser.Displayed);
                Assert.IsTrue(dash.ManageUser.Enabled);                
            }
            catch (Exception e)
            {
                dash.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"ManageUser button is missing");
            }
        }

        public static void AssertAuthorSign(this ArticlesDashboard dash, string author)
        {
            try
            {
                IWebElement foundArticle = dash.AuthorSign[dash.AuthorSign.Count - 1];
                Assert.AreEqual(author, foundArticle.Text);
            }
            catch (Exception e)
            {
                dash.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Author Sign is missing");
            }
        }

        public static void AssertArticleDetailsView(this ArticlesDashboard dash, int ArticleId, string title, string content, string author)
        {
            try
            {
                Assert.AreEqual($"http://localhost:60639/Article/Details/{ArticleId}", dash.Driver.Url);
                Assert.AreEqual(dash.Title.Text, title);
                Assert.AreEqual(dash.Content.Text, content);
                Assert.AreEqual(dash.Author.Text, author);

                Assert.IsTrue(dash.EditButtonArticle.Displayed);
                Assert.IsTrue(dash.EditButtonArticle.Enabled);
                Assert.IsTrue(dash.DeleteButtonArticle.Displayed);
                Assert.IsTrue(dash.DeleteButtonArticle.Enabled);
                Assert.IsTrue(dash.BackButtonArticle.Displayed);
                Assert.IsTrue(dash.BackButtonArticle.Enabled);
            }
            catch (Exception e)
            {
                dash.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Some Articles details are missing");
            }
        }

        public static void AssertAvailableLogOutButton(this ArticlesDashboard dash)
        {
            try
            {                
                Assert.IsTrue(dash.LogOut.Displayed);
                Assert.IsTrue(dash.LogOut.Enabled);
            }
            catch (Exception e)
            {
                dash.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"LogOut button is missing");
            }
        }
        
        public static void AssertArticleDetailsDashboard(this ArticlesDashboard dash, string title, string content, string author)
        {
            try
            {
                string href = dash.FindArticleIdByTitle(title).GetAttribute("href");
                List<string> articleDetails = href.Split('/').ToList();
                int ArticleId = int.Parse(articleDetails[articleDetails.Count - 1]);
                
                List<IWebElement> elements = dash.ContainerDashboardTitle;
                int a = new int();
                for (int i = 0; i < elements.Count; i++)
                    if (elements[i].GetAttribute("href").Contains($"{ArticleId}"))
                        a = i;
                IWebElement foundArticleTitle = dash.ContainerDashboardTitle[a];
                IWebElement foundArticleContent = dash.ContainerDashboardContent[a];
                IWebElement foundArticleAuthorSign = dash.AuthorSign[a];
                Assert.AreEqual(title, foundArticleTitle.Text);
                Assert.AreEqual(content, foundArticleContent.Text);
                Assert.AreEqual(author, foundArticleAuthorSign.Text);
            }
            catch (Exception e)
            {
                dash.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Article is not found");
            }
        }
                
        public static void AssertDeleteArticleDashboard(this ArticlesDashboard dash, string title)
        {            
                var reminder = dash.Wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > div > div")));
                List<IWebElement> list = reminder.FindElements(By.TagName("a")).ToList();
                IWebElement foundArticle = null;
                for (int i = 0; i < list.Count; i++)
                    if (list[i].Text.Equals(title))
                        foundArticle = list[i];
                Assert.IsTrue(foundArticle == null,"Not found Deleted Article in Dashboard", "Found Deleted Article in Dashboard");                              
        }


        public static void AssertAvailableScrolBarsDashboard(this ArticlesDashboard dash)
        {

            IJavaScriptExecutor javascript = (IJavaScriptExecutor)dash.Driver;
            Boolean horzscrollStatus = (Boolean)javascript.ExecuteScript("return document.documentElement.scrollWidth>document.documentElement.clientWidth;");
            Boolean VertscrollStatus = (Boolean)javascript.ExecuteScript("return document.documentElement.scrollHeight>document.documentElement.clientHeight;");

            if (VertscrollStatus & horzscrollStatus)
            {
                dash.log.Info("Both Scroll bars are shown.");
                Assert.Pass("Both Scroll bars are shown.");
            }
            else if (horzscrollStatus)
            {
                dash.log.Info("Horizontal Scroll bars are shown.");
                Assert.Pass("HorizontalScroll bars are shown.");
            }
            else if (VertscrollStatus)
            {
                dash.log.Info("Vertical scroll bars are shown.");
                Assert.Fail("Vertical scroll bars are shown.");
            }
            else
            {
                dash.log.Info("No scroll bars are shown.");
                Assert.Fail("No scroll bars are shown.");
            }
        }
    }
}
