using log4net;
using OpenQA.Selenium;
using reqnroll_c__bdd.Helpers;
using reqnroll_c__bdd.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reqnroll_c__bdd.Pages
{
    public class LoginPage : BaseHelper
    {
        private Setup context;
        private PageHelper pageHelperObject;
        public LoginPage(IWebDriver driver, PageHelper pageHelperObject, Setup context) 
        {
            this.driver = driver;
            this.pageHelperObject = pageHelperObject;
            this.context = context;
        }

        #region Element Locators
        By UsernameBy = By.XPath("//div/input[@name='username']");
        By PasswordBy = By.XPath("//input[@name='password']");
        By LoginBtnBy = By.XPath("//button[@type='submit']");
        By DashboardTitleBy = By.XPath(@"//span/h6[text()='Dashboard']");

        #endregion

        #region Methods

        internal void NavigateToUrl()
        {
            pageHelperObject.WaitForPageLoad();
            driver.Navigate().GoToUrl(context.BaseURL);
        }

        internal void EnterUsername()
        {
            pageHelperObject.WaitForElementToBeVisibleBy(UsernameBy);
            IWebElement username = pageHelperObject.FindElementByXPath(UsernameBy);
            username.SendKeys(context.Username);
        }

        internal void EnterPassword()
        {
            pageHelperObject.WaitForElementToBeVisibleBy(PasswordBy);
            IWebElement password = pageHelperObject.FindElementByXPath(PasswordBy);
            password.SendKeys(context.Password);
        }

        internal void ClickLoginBtn()
        {
            pageHelperObject.WaitForElementToBeVisibleBy(LoginBtnBy);
            pageHelperObject.FindElementByXPath(LoginBtnBy).Click();
        }

        internal bool IsDashboardDisplayed()
        {
            pageHelperObject.WaitForElementToBeVisibleBy(DashboardTitleBy);
            if (DashboardTitleBy != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        internal void PerformLogin()
        {
            NavigateToUrl();
            EnterUsername();
            EnterPassword();
            ClickLoginBtn();
        }

        #endregion
    }

}
