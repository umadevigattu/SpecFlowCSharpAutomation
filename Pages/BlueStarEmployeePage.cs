using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SeleniumExtras.PageObjects;
using System.Xml;
using SpecFlowBDDAutomationFramework.ComponentHelper;
using SpecFlowBDDAutomationFramework.Settings;
using AventStack.ExtentReports.Model;
using NUnit.Framework.Internal;
using SpecFlowBDDAutomationFramework.StepDefinitions;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using NUnit.Framework;

namespace SpecFlowBDDAutomationFramework.Pages
{
    public class BlueStartEmployeePage
    {
        public AppiumDriver<AndroidElement> _driver;
        readonly TestDriver driver;

        public BlueStartEmployeePage()
        {
            driver = (TestDriver)ScenarioContext.Current["driver"];
        }
        public string employee_button = "//*[@resource-id = 'com.ags.bluestarsafety:id/employee']";
        public string email ="//*[@resource-id = 'com.ags.bluestarsafety:id/editEmail']";
        public string submit_btn = "//*[@resource-id = 'com.ags.bluestarsafety:id/submit']";
        public string valid_msg = "//*[@resource-id = 'android:id/message']";
        public string ok_Btn = "//*[@resource-id = 'android:id/button1']";
        public void Launch_Selected_Mobile_App()
        {
            _driver = driver.Init();
            Thread.Sleep(10000);

        }
        public  void click_Employee(string objectkey)
        {
            AndroidElement input1 = _driver.FindElementByXPath(employee_button);
            input1.Click();
            Thread.Sleep(10000);
        }
        public  void enter_EmailAddress(string objectkey,string objectValue)
        {
            AndroidElement inputsum = _driver.FindElementByXPath(email);
            inputsum.SendKeys("abc@gnail.com");
            Thread.Sleep(10000);
            AndroidElement input2 = _driver.FindElementByXPath(submit_btn);
            input2.Click();
        }
        public  void Validate_Message(string objectkey)
        {
           
            AndroidElement msg = _driver.FindElementByXPath(valid_msg);
            string msgs =msg.Text;
            Console.WriteLine("Text:" + msgs);
            string actual_msg = "[Invalid EmailID]";
            Assert.That(msgs, Is.EqualTo(actual_msg));
            AndroidElement inputequal = _driver.FindElementByXPath(ok_Btn);
            inputequal.Click();
        }
    }
}
