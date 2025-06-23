using log4net;
using Reqnroll;
using reqnroll_c__bdd.Helpers;
using reqnroll_c__bdd.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reqnroll_c__bdd.StepDefinitions
{
    [Binding]
    internal class LogoutStep : BaseHelper
    {
        private ILog log => GetFeature<ILog>("log");
        private LogoutPage logoutPageObject => Objects.logoutPageObject;
        private PageHelper pageHelperObject => Objects.pageHelperObject;

        [When("the user clicks on the logout button")]
        public void WhenTheUserClicksOnTheLogoutButton()
        {
            log.Info("Starting test: " + TestContext.CurrentContext.Test.Name);
            logoutPageObject.OpenUserProfile();
            logoutPageObject.ClickLogout();
        }

        [Then("the user should be redirected to the login screen")]
        public void ThenTheUserShouldBeRedirectedToTheLoginScreen()
        {
            string url = pageHelperObject.GetUrl();
            Assert.That(url.Equals("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login"));
            log.Info("Ending test: " + TestContext.CurrentContext.Test.Name);
        }

    }
}
