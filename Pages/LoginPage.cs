using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace PterodactylTest.Pages
{
    class LoginPage
    {
        IWebDriver driver;
        public LoginPage(IWebDriver Driver)
        {
            this.driver = Driver;
            PageFactory.InitElements(driver, this);
        }

        // These variables are responsible for selecting the elements to log into the website.
        [FindsBy(How = How.Id, Using = "usernamefld")]
        public IWebElement UsernameField;

        [FindsBy(How = How.Id, Using = "passwordfld")]
        public IWebElement PasswordField;

        [FindsBy(How = How.XPath, Using = "//*[@id='total']/div/div[2]/div/form/input[4]")]
        public IWebElement LoginButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='headerrow']/div/div[2]/h4")]
        public IWebElement ErrorMessage;

        // These variables are responsible for navigation
        [FindsBy(How = How.Id, Using = "logo")]
        public IWebElement Logo;

        [FindsBy(How = How.XPath, Using = "//*[@id='widget - system_information - 0']/div[1]/h2")]
        public IWebElement DashboardCheck;

        public void WaitForElement(IWebElement element, string identifier, string type)
        {
            WebDriverWait WaitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            if (type == "xpath")
            {
                WaitForElement.Until(ExpectedConditions.ElementIsVisible(By.XPath(identifier)));
            }
            else if (type == "id")
            {
                WaitForElement.Until(ExpectedConditions.ElementIsVisible(By.Id(identifier)));
            }
            else if (type == "classname")
            {
                WaitForElement.Until(ExpectedConditions.ElementIsVisible(By.ClassName(identifier)));
            }
            else
            { }
            
            element.Click();
        }
        public void Navigate(string url)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        public void EnterUsername(string Username)
        {
            WaitForElement(UsernameField, "usernamefld", "id");
            UsernameField.SendKeys(Username);
        }

        public void EnterPassword(string Password)
        {
            WaitForElement(UsernameField, "passwordfld", "id");
            PasswordField.SendKeys(Password);
        }

        public void Login()
        {
            LoginButton.Click();
        }

        public void GoToSummaryPage()
        {

            WaitForElement(Logo, "logo", "id");
        }

        public string CheckCurrentPage()
        {
            return DashboardCheck.Text;
        }

        public string CheckErrorMessage()
        {
            return ErrorMessage.Text;
        }
    }
}
