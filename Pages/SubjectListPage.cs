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
    public class SubjectListPage :BasePage
    {
        private By bySubjectList => By.ClassName("subject-item-inner");
        private By byRemoveButton => By.ClassName("btn-txt-delete");
        private By byDeleteConfirmPopup => By.ClassName("delete-confirm");
        private By bySubjectNameField => By.CssSelector("input[type='text']");
        private By bySubjecSaveButton => By.ClassName("btn-primary");

        public List<IWebElement> SubjectList => driver.FindElements(bySubjectList).ToList();
        public IWebElement RemoveButton => driver.FindElement(byRemoveButton);
        public IWebElement deleteConfirmPopup => driver.FindElement(byDeleteConfirmPopup);
        public IWebElement SubjectNameField => driver.FindElement(bySubjectNameField);
        public IWebElement SubjectSaveButton => driver.FindElement(bySubjecSaveButton);

        public IWebElement FindSubjectByName(string name)
        {
            return SubjectList.FirstOrDefault(q=>q.FindElement(By.TagName("strong")).Text == name);
        }

        public void WaitUntilPageIsLoaded()
        {
            waitIf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(bySubjectList));
            Thread.Sleep(5000);
        }

        public void DeleteSubject(string name)
        {
            var subjectToDelete = FindSubjectByName(name);

            var editButton = subjectToDelete.FindElements(By.TagName("span")).FirstOrDefault(q => q.Text == "Edit");
            ScrollToView(editButton);
            waitIf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(editButton));
            editButton.Click();
            ScrollToView(RemoveButton);
            waitIf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(byRemoveButton));
            RemoveButton.Click();
            waitIf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(byDeleteConfirmPopup));
            deleteConfirmPopup.FindElements(By.TagName("button")).FirstOrDefault(q => q.Text == "Remove").Click();

        }

        public void EditSubjectName(string text)
        {
            waitIf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(bySubjectNameField));
            SubjectNameField.Clear();
            SubjectNameField.SendKeys(text);
            waitIf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("btn-primary")));
            var saveButton = driver.FindElements(By.ClassName("btn-primary")).FirstOrDefault(q => q.Text == "Save");
            ScrollToView(saveButton);
            waitIf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(saveButton));
            saveButton.Click();
        }
        public void FindEditSubjectButton(string name)
        {
            var subjectToEdit = FindSubjectByName(name);
            var editButton = subjectToEdit.FindElements(By.TagName("span")).FirstOrDefault(q => q.Text == "Edit");
            ScrollToView(editButton);
            waitIf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(editButton));
            editButton.Click();

        }


    }

}
