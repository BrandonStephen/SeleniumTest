using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PterodactylTest.Pages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace PterodactylTest
{
    [Binding]
    public class LoginFeatureSteps
    {
        IWebDriver driver;
        LoginPage lp;

        [Scope(Feature = "LoginFeature")]
        [BeforeScenario]
        public void SetUp()
        {
            driver = new ChromeDriver();
            lp = new LoginPage(driver);
        }



        [Given(@"I am on the login screen")]
        public void GivenIAmOnTheLoginScreen()
        {
            lp.Navigate("http://54.37.241.250:81/");
        }
        
        [Given(@"I have entered my username")]
        public void GivenIHaveEnteredMyUsername()
        {
            lp.EnterUsername("Xaritomi");
        }
        
        [Given(@"I have entered my password")]
        public void GivenIHaveEnteredMyPassword()
        {
            lp.EnterPassword("DooMed345--@@");
        }
        
        [Given(@"I am on the Admin page")]
        public void GivenIAmOnTheAdminPage()
        {
            lp.GoToSummaryPage();
        }
        
        [Given(@"I have entered an invalid username")]
        public void GivenIHaveEnteredAnInvalidUsername()
        {
            Thread.Sleep(2000);
            lp.EnterUsername("Test");
        }
        
        [Given(@"I have entered an invalid password")]
        public void GivenIHaveEnteredAnInvalidPassword()
        {
            lp.EnterPassword("Test1234");
        }

        [Given(@"I have pressed the sign in button")]
        public void GivenIHavePressedTheSignInButton()
        {
            lp.Login();
        }


        [Then(@"I can see a summary page")]
        public void ThenICanSeeASummaryPage()
        {
            Thread.Sleep(2000);
            Assert.AreEqual("http://54.37.241.250:81/", driver.Url);
        }
        
        [Then(@"I can see an error message")]
        public void ThenICanSeeAnErrorMessage()
        {
            Thread.Sleep(2000);
            Assert.AreEqual("Username or Password incorrect", lp.CheckErrorMessage());
        }

        [Scope(Feature = "LoginFeature")]
        [AfterScenario]
        public void AfterScenario()
        {
            driver.Close();
        }
    }
}
