using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reqnroll_c__bdd.Helpers
{
  
    public class PageHelper : BaseHelper
    {
        WebDriverWait Wait;
        const int Timeout = 10000;
        
        public PageHelper(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new(driver, TimeSpan.FromSeconds(Timeout));
        }

        public void WaitForPageLoad()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            Wait.Until(d => js.ExecuteScript("return document.readyState").Equals("complete"));
        }

        public IWebElement FindElementByXPath(By xpath)
        {
            return driver.FindElement(xpath);
        }

        internal void WaitForElementToBeVisibleBy(By elementLocator)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
        }

        internal void WaitForElementToBeClickable(By elementLocator)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
        }
        internal void JSScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", element);
            js.ExecuteScript("window.scrollBy(0, -150);");
        }

        internal string GenerateRandomDate()
        {
            DateTime startDate = new DateTime(1950, 1, 1);
            DateTime endDate = new DateTime(2002, 12, 31);
            Random random = new Random();
            int range = (endDate - startDate).Days;
            int randomDays = random.Next(range);
            DateTime randomDate = startDate.AddDays(randomDays);
            string formattedDate = randomDate.ToString("yyyy-dd-MM");
            return formattedDate;
        }

        internal void WaitForElementToBeInvisible(By element)
        {
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(element));
        }

        internal string GetUrl()
        {
            return driver.Url;
        }
    }
}
