using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using SpecFlowBDDAutomationFramework.Pages;
using TechTalk.SpecFlow;
using SpecFlowBDDAutomationFramework.Configuration;
using SpecFlowBDDAutomationFramework.ComponentHelper;
using SpecFlowBDDAutomationFramework.Pages;

namespace SpecFlowBDDAutomationFramework.StepDefinitions
{
    [Binding]
    public class BlueStarSteps: BlueStartEmployeePage
    {
        private AppiumDriver<AndroidElement> _driver;
        readonly TestDriver driver;

        public BlueStarSteps()
        {
            driver = (TestDriver)ScenarioContext.Current["driver"];
        }


        [Given(@"User launching BlueStar App")]
        public void GivenUserLaunchingBlueStarApp()
        {
            Launch_Selected_Mobile_App();
        }

        [When(@"User click on ""(.*)""")]
        public void WhenUserClickOn(string data)
        {
            click_Employee(data);
        }

        [When(@"User enter ""(.*)"" address as""(.*)""")]
        public void WhenUserEnterAddressAs(string emailID_Obj, string emailID_val)
        {
            enter_EmailAddress(emailID_Obj, emailID_val);
        }

        [Then(@"User should verify email address is ""(.*)""or not")]
        public void ThenUserShouldVerifyEmailAddressIsOrNot(string data)
        {
            Validate_Message(data);
        }
    }
}