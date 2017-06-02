using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.Seleno.Configuration;

namespace Blog.Unit.Tests
{
    public class BrowserHost
    {
        public static readonly SelenoHost Instance = new SelenoHost();
        public static readonly string RootUrl = @"http://localhost:60634/Article/List";

        static BrowserHost()
        {
            var ChromeDriverPath = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ChromeDriverFile"];            
            Instance.Run("Blog", 60638, w => w.WithRemoteWebDriver(() => new ChromeDriver(ChromeDriverPath)));
        }
    }
}