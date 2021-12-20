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
   public class MainPage :BasePage
    {
        private By byUserMenu => By.CssSelector("div[data-test-id='user-menu']");
        private By byUserLogOut => By.CssSelector("a[data-test-id='log-out']");
        private By byLogoLink => By.ClassName("logo-link");
        private By bySubjectDropDown => By.CssSelector("subject-dropdown[data-test-id='subject-group-dropdown']");
        private By byAddSubjectButton => By.CssSelector("span[data-test-id='add-subject-button']");

        public IWebElement UserMenu => driver.FindElement(byUserMenu);
        public IWebElement UserLogOut => driver.FindElement(byUserLogOut);
        public IWebElement LogoLink => driver.FindElement(byLogoLink);
        public IWebElement SubjectDropDown => driver.FindElement(bySubjectDropDown);
        public IWebElement AddSubjectButton => driver.FindElement(byAddSubjectButton);


        public void LogOut() 
        {
            waitIf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.TagName("db-menu")));
            UserMenu.Click();
            waitIf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(byUserLogOut));
            UserLogOut.Click();
            waitIf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("logoutButton"))).Click();
            waitIf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Return")));
            
        }

        public void ReturnToMainPage()
        {
            waitIf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(byLogoLink));
            LogoLink.Click();
            

        }

        public void AddSubject()
        {
            waitIf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(bySubjectDropDown));
            SubjectDropDown.Click();
            waitIf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(byAddSubjectButton));
            AddSubjectButton.Click();
            
        }



    }
}
