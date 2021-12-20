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
using SeleniumExtras;

namespace Snappet.Pages
{
   public class LoginPage : BasePage
    {
        //define login page elements:
        private By byUserNameField => By.Id("Input_Username");
        private By byPasswordField => By.Id("password-input");
        private By byLoginButton => By.CssSelector("button[type='submit']");

        public IWebElement userNameField => driver.FindElement(byUserNameField);
        public IWebElement passwordField => driver.FindElement(byPasswordField);
        public IWebElement loginButton => driver.FindElement(byLoginButton);

        public void WaitUntilPageIsLoaded()
        {
            waitIf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(byLoginButton));
            
        }

        public void Login(string userName, string password)
        {
            userNameField.SendKeys(userName);
            passwordField.SendKeys(password);
            loginButton.Click();
        }


        public void Open()
        {
            NavigateToUrl("https://teacher.snappet.org/");
        }

    }
}
