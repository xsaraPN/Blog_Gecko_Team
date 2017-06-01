using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Unit.Tests.Pages.RegistrationPages
{
    public static class RegistrationPageAsserter
    {
      
        public static void AssertRegistrationFormError(this RegistrationPage page, string text)
        {
            Assert.AreEqual(text, page.RegistrationFormError.Text);
           
        }
        public static void AssertRegistration(this RegistrationPage page, string text)
        {
            Assert.Contains(text, page.eror.ToList());

        }
    }
}
