using OpenQA.Selenium;
using Reqnroll;
using reqnroll_c__bdd.Helpers;
using reqnroll_c__bdd.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reqnroll_c__bdd.Pages
{
    public class LogoutPage : BaseHelper
    {
        private Setup context; 
        private PageHelper pageHelperObject;
        public LogoutPage(IWebDriver driver, PageHelper pageHelperObject, Setup context)
        {
            this.driver = driver;
            this.pageHelperObject = pageHelperObject;
            this.context = context;
        }


        #region Element Locators
        By UsernameBy = By.XPath("//p[@class='oxd-userdropdown-name']");
        By UserAvatarBy = By.XPath("//span[@class='oxd-userdropdown-tab']/img[@alt='profile picture']");
        By UserProfileMenu = By.XPath("//ul[@class='oxd-dropdown-menu']");
        By LogoutBy = By.XPath("//ul[@class='oxd-dropdown-menu']/li/a[text()='Logout']");
        By Loader = By.XPath("//div[@class='oxd-form-loader']");
        #endregion

        #region Methods

        internal void OpenUserProfile()
        {
            pageHelperObject.WaitForPageLoad();
            pageHelperObject.WaitForElementToBeInvisible(Loader);
            pageHelperObject.WaitForElementToBeVisibleBy(UserAvatarBy);
            pageHelperObject.WaitForElementToBeVisibleBy(UsernameBy);
            pageHelperObject.FindElementByXPath(UsernameBy).Click();
            pageHelperObject.WaitForElementToBeVisibleBy(UserProfileMenu);
        }

        internal void ClickLogout()
        {
            pageHelperObject.FindElementByXPath(LogoutBy).Click();
        }

        #endregion
    }
}
