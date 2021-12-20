using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using Snappet.Helpers;
using Snappet.Pages;
using System;



namespace Snappet.Tests
{
    [TestFixture]
    
    public class SubjectTests
    {
        LoginPage loginPage = new LoginPage();
        MainPage mainPage = new MainPage();
        ActivateSubjectPage activatePage = new ActivateSubjectPage();
        SubjectListPage subjectListPage = new SubjectListPage();

        public static ExtentTest test;
        public static ExtentReports extent;
       
        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\sergz\OneDrive\Desktop\Snappet\Snappet\Report\index2.html");
            extent.AttachReporter(htmlReporter);
        }

        [SetUp]
        public void Init()
        {
            //login
            loginPage.Open();
            loginPage.WaitUntilPageIsLoaded();
            loginPage.Login("TechChallengeTeacher", "P@ssw0rd");
         }

        [TearDown]
        public void Clean()
        {
            mainPage.ReturnToMainPage();
            mainPage.LogOut();


        }

        [Test]
        public void ActivateSubject()
        {
            test = extent.CreateTest("Activate Subject test").Info("Test started");
            try
            {
                var testSubjectName = "OlTest2";
                var testSelectSubject = "Spelling";

                mainPage.AddSubject();
                // activate subject
                activatePage.WaitUntilPageIsLoaded();
                activatePage.SelectSubject(testSelectSubject);
                var isClickSuccessful = activatePage.ClickNext();

                Assert.IsTrue(isClickSuccessful);

                activatePage.ClickNext(); 
                activatePage.SelectFirstSuggestionCard(); 
                activatePage.InsertSubjectName(testSubjectName); 
                isClickSuccessful = activatePage.ClickActivateSubject();

                Assert.IsTrue(isClickSuccessful); 
                
                subjectListPage.WaitUntilPageIsLoaded();
                Assert.IsNotNull(subjectListPage.FindSubjectByName(testSubjectName));

                //delete created subject
                subjectListPage.WaitUntilPageIsLoaded();
                subjectListPage.DeleteSubject(testSubjectName);
                //log to test
                test.Log(Status.Pass, "Test passed");
            }
            catch(Exception ex)
            {
                test.Log(Status.Fail, "Test Fail : " + ex.Message);
                
            }

        }

        [Test]
        public void EditSubjectName()
        {
            test = extent.CreateTest("Edit Subject test").Info("Test started");
            var testSubjectName = "OlTest2";
            var testSelectSubject = "Spelling";
            var testEditSubjectName = "EditedName";
            mainPage.AddSubject();
            // activate subject
            activatePage.WaitUntilPageIsLoaded();
            activatePage.SelectSubject(testSelectSubject);
            var isClickSuccessful = activatePage.ClickNext();
            Assert.IsTrue(isClickSuccessful);
            activatePage.ClickNext(); // "next" on 2nd wizard page
            activatePage.SelectFirstSuggestionCard(); // select first card
            activatePage.InsertSubjectName(testSubjectName); //insert test subject name
            isClickSuccessful = activatePage.ClickActivateSubject();
            Assert.IsTrue(isClickSuccessful); //check that Activate button is clickable
            //Assert subject created
            subjectListPage.WaitUntilPageIsLoaded();
            Assert.IsNotNull(subjectListPage.FindSubjectByName(testSubjectName));
            //edit subject name
            subjectListPage.FindEditSubjectButton(testSubjectName);
            subjectListPage.EditSubjectName(testEditSubjectName);
            Assert.AreEqual(testEditSubjectName, "EditedName");
            subjectListPage.WaitUntilPageIsLoaded();
            subjectListPage.DeleteSubject(testEditSubjectName);
            //test logs
            test.Log(Status.Pass, "Test passed");

        }

        [Test, Ignore("not implemented yet")]
        public void EditSubjectGrade()
        {
            // edit subject grade
            // assert - grade changed
        }

        [OneTimeTearDown]
        public void CleanAll()
        {

            BasePage.driver.Quit();
            extent.Flush();

        }
    }
}
