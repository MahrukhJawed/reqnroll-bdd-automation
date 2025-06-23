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
    internal class MyInfoStep : BaseHelper
    {
        private ILog log => GetFeature<ILog>("log");
        private LoginPage loginPageObject => Objects.loginPageObject;
        private MyInfoPage infoPageObject => Objects.infoPageObject;

        string originalDate, editedDate, newDate;

        [Given("the user is logged into the app")]
        public void GivenTheUserIsLoggedIntoTheApp()
        {
            log.Info("Starting test: " + TestContext.CurrentContext.Test.Name);
            loginPageObject.PerformLogin();
          
        }

        [When("the user updates their date of birth")]
        public void WhenTheUserUpdatesTheirDateOfBirth()
        {
            infoPageObject.NavigateToInfoPage();
            infoPageObject.VerifyDOBIsNotNull();
            Assert.That(infoPageObject.VerifyDOBIsNotNull(), Is.True);
            originalDate = infoPageObject.GetDateOfBirth();
            newDate = infoPageObject.EditDateOfBirth();
        }

        [When("the user clicks on the save button")]
        public void WhenTheUserClicksOnTheSaveButton()
        {
            infoPageObject.SubmitForm();
            Thread.Sleep(8000);
            editedDate = infoPageObject.GetDateOfBirth();
        }

        [Then("the new date of birth should be saved successfully")]
        public void ThenTheNewDateOfBirthShouldBeSavedSuccessfully()
        {
            Assert.That(editedDate, Is.Not.SameAs(originalDate));
            Assert.That(editedDate, Is.EqualTo(newDate));
            log.Info("Ending test: " + TestContext.CurrentContext.Test.Name);
        }

    }
}
