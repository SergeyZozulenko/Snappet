using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using log4net.Core;
using log4net;
using Snappet.Helpers;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium.Interactions;


namespace Snappet.Helpers
{
    public class BasePage {

        private static IWebDriver _driver;
        public WebDriverWait waitIf;
        TimeSpan t = new TimeSpan(0, 0, 10);//for timer set


        public BasePage()
        {
            waitIf = new WebDriverWait(driver, t);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            
        }

        public static IWebDriver driver 
        {
            get
               {
                if (_driver == null)
                {
                    _driver = new ChromeDriver();
                   
                }

             return _driver;
                
            }

    }

        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
   

        public void ScrollToView(IWebElement element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            
        }


        
        public void CloseBrowser()
        {
            driver.Quit();
        }

    }
}
