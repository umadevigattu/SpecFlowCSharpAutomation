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
    public class ExampleSteps
    {
        private AppiumDriver<AndroidElement> _driver;
        readonly TestDriver driver;
        
        public ExampleSteps()
        {
            driver = (TestDriver)ScenarioContext.Current["driver"];
        }

        [Given(@"I am using the calculator")]
        public void GivenIAmOnThecalulatorPage()
        {
            _driver = driver.Init();
            Thread.Sleep(10000);
            
        }

        [When(@"I add two values")]
        public void WhenIAddTwo()
        {
            AndroidElement input1 = _driver.FindElementByXPath("//*[@resource-id = 'com.ags.bluestarsafety:id/employee']");
            input1.Click();
            Thread.Sleep(10000);
            AndroidElement inputsum = _driver.FindElementByXPath("//*[@resource-id = 'com.ags.bluestarsafety:id/editEmail']");
            inputsum.SendKeys("abc@gmail.com");
            Thread.Sleep(10000);
            AndroidElement input2 = _driver.FindElementByXPath("//*[@resource-id = 'com.ags.bluestarsafety:id/submit']");
            input2.Click();
            /*AndroidElement inputequal = _driver.FindElementByXPath("//*[@resource-id = 'android:id/button1']");
            inputequal.Click();
            AndroidElement inpuPhotos = _driver.FindElementByXPath("//*[@resource-id = 'com.android.permissioncontroller:id/permission_allow_button']");
            inpuPhotos.Click();
            AndroidElement inpuid = _driver.FindElementByXPath("//*[@resource-id = 'android:id/button1']");
            inpuid.Click();
        */

        }

        [Then(@"I should see the sum 3")]
        public void ThenIShouldSeeTitle()
        {
            string sum = "[Invalid EmailID]";
            Assert.That(_driver.FindElementByXPath("//*[@resource-id = 'android:id/message']").Text, Is.EqualTo(sum));
            AndroidElement inputequal = _driver.FindElementByXPath("//*[@resource-id = 'android:id/button1']");
            inputequal.Click();
        }
    }
}