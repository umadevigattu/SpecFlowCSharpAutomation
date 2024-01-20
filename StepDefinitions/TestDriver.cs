using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using SpecFlowBDDAutomationFramework.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowBDDAutomationFramework.StepDefinitions
{
    [Binding]
    public sealed class test_specflow
    {
        private TestDriver driver;
        ResultPage resultPage;

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new TestDriver(ScenarioContext.Current);
            ScenarioContext.Current["driver"] = driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Cleanup();
        }
    }

    public class TestDriver
    {
        private AppiumDriver<AndroidElement> driver;
        private ScenarioContext current;
        ResultPage resultPage;

        public TestDriver(ScenarioContext current)
        {
            this.current = current;
        }

        public AppiumDriver<AndroidElement> Init()
        {
            AppiumOptions appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "emulator-5554");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "10.0");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.NoReset, "true");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, "C:\\Users\\aUTOMATION\\Desktop\\Demo\\SpecFlowBDDAutomation\\BlueStar_Safety.apk");

            driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), appiumOptions);

            return driver;
        }

        public void Cleanup()
        {
            if (driver != null)
            {
               // driver.Quit();
            }
        }
    }
}