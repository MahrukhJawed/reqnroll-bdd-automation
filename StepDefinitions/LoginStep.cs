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
    internal class LoginStep : BaseHelper
    {
        private ILog log => GetFeature<ILog>("log");
        private LoginPage loginPageObject => Objects.loginPageObject;

        [Given("the user is on the login page")]
        public void GivenTheUserIsOnTheLoginPage()
        {
            log.Info("Starting test: " + TestContext.CurrentContext.Test.Name);
            loginPageObject.NavigateToUrl();
        }

        [When("the user enters a valid username and password")]
        public void WhenTheUserEntersAValidUsernameAndPassword()
        {
            loginPageObject.EnterUsername();
            loginPageObject.EnterPassword();
        }

        [When("the user clicks the login button")]
        public void WhenTheUserClicksTheLoginButton()
        {
            loginPageObject.ClickLoginBtn();
        }

        [Then("the user should be redirected to the dashboard page")]
        public void ThenTheUserShouldBeRedirectedToTheDashboardPage()
        {
            Assert.True(loginPageObject.IsDashboardDisplayed());
            log.Info("Ending test: " + TestContext.CurrentContext.Test.Name);
        }

      

    }
}
