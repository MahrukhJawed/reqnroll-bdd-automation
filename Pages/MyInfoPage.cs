using log4net;
using OpenQA.Selenium;
using Reqnroll;
using reqnroll_c__bdd.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reqnroll_c__bdd.Pages
{
    public class MyInfoPage : BaseHelper
    {
        private Setup context;
        private PageHelper pageHelperObject;
        public MyInfoPage(IWebDriver driver , PageHelper pageHelperObject, Setup context)
        {
            this.driver = driver;
            this.pageHelperObject = pageHelperObject;
            this.context = context;
        }

        #region Element Locators
        By InfoPageLeftMenu = By.XPath("//a/span[text()='My Info']");
        By DateOfBirthBy = By.XPath("//label[text()='Date of Birth']/parent::div//following-sibling::div//input");
        By SubmitBy = By.XPath("(//button[@type='submit'])[1]");
        By LeftMenu = By.XPath("//div/ul[@class='oxd-main-menu']");
        By Loader = By.XPath("//div[@class='oxd-form-loader']");
        #endregion

        #region Methods


        internal void NavigateToInfoPage()
        {
            pageHelperObject.WaitForPageLoad();
            pageHelperObject.WaitForElementToBeVisibleBy(LeftMenu);
            pageHelperObject.WaitForElementToBeClickable(InfoPageLeftMenu);
            pageHelperObject.FindElementByXPath(InfoPageLeftMenu).Click();
        }

        internal bool VerifyDOBIsNotNull()
        {
            pageHelperObject.WaitForElementToBeVisibleBy(DateOfBirthBy);
            IWebElement dob = pageHelperObject.FindElementByXPath(DateOfBirthBy);
            pageHelperObject.JSScrollToElement(dob);
            if (dob.Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal string EditDateOfBirth()
        {
            pageHelperObject.WaitForElementToBeVisibleBy(DateOfBirthBy);
            IWebElement dob = pageHelperObject.FindElementByXPath(DateOfBirthBy);
            pageHelperObject.JSScrollToElement(dob);
            string date = pageHelperObject.GenerateRandomDate();
            dob.Clear();
            for (int i = 0; i < 10; i++)
            {
                dob.SendKeys(Keys.Backspace);
            }
            dob.SendKeys(date); 
            return date;
        }

        internal void SubmitForm()
        {
            pageHelperObject.WaitForElementToBeVisibleBy(SubmitBy);
            pageHelperObject.FindElementByXPath(SubmitBy).Click();
            pageHelperObject.WaitForElementToBeInvisible(Loader);
        }

        internal string GetDateOfBirth()
        {
            IWebElement dob = pageHelperObject.FindElementByXPath(DateOfBirthBy);
            string editedDOB = dob.GetAttribute("value");
            return editedDOB;
        }

        #endregion
    }

}

