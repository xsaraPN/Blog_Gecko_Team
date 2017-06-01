using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages
{
    public static class PageAsserter
    {
          public static void AssertPageIsOpen(this Page page, string text)
        {
            Assert.AreEqual(text, page.PageTitle.Text);
        }
        public static void AssertSiteLogo(this Page page, string text)
        {
            Assert.AreEqual(text, page.Logo.Text);
        }

    }
}
