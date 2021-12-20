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
    class ActivateSubjectPage: BasePage
    {
        private By byActivateSubjectDropdown => By.TagName("subjects-dropdown");
        private By byActivateSubjects => By.ClassName("select2-results__options");
        private By byActivateSubjectsList => By.ClassName("select2-results__option");
        private By bySuggestionCard => By.ClassName("card-inner");
        private By bySubjectNameField => By.CssSelector("input[type='text']");

        public IWebElement AddSubjectDropdown => driver.FindElement(byActivateSubjectDropdown);
        public List<IWebElement> ActivateSubjects => driver.FindElements(byActivateSubjectsList).ToList();

        public IWebElement nextButton => driver.FindElements(By.TagName("a")).FirstOrDefault(q => q.Text == "Next");
        public List<IWebElement> SuggestionCards => driver.FindElements(bySuggestionCard).ToList();

        public IWebElement ButtonActivate => driver.FindElements(By.TagName("button")).FirstOrDefault(q=> q.Text == "Activate subject");

        public IWebElement SubjectNameField => driver.FindElement(bySubjectNameField);

        public void WaitUntilPageIsLoaded()
        {
            waitIf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(byActivateSubjectDropdown));
        }

        public void SelectSubject(string subjectName)
        {
            AddSubjectDropdown.Click();
            waitIf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(byActivateSubjects));
            var foundSubject = ActivateSubjects.FirstOrDefault(q => q.Text == subjectName);
            if (foundSubject != null)
            {
                foundSubject.Click();
            }
        }

        public void SelectFirstSuggestionCard()
        {
            
            waitIf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(bySuggestionCard));
            var foundSugesstionCard = SuggestionCards.FirstOrDefault();
            if (foundSugesstionCard != null)
            {
                foundSugesstionCard.Click();
            }
        }
        public bool ClickNext()
        {
            
            if (nextButton != null)
            {
                nextButton.Click();
                return true;
            }
            return false;
        }

        public bool ClickActivateSubject()
        {
            waitIf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.TagName("button")));

            if (ButtonActivate != null)
            {
                ButtonActivate.Click();
                return true;
            }
            return false;
        }

        public void InsertSubjectName(string text)
        {
            waitIf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.TagName("button")));

            SubjectNameField.Clear();
            SubjectNameField.SendKeys(text);
            
        }
      

      
    }
}
