using AventStack.ExtentReports.Configuration;
using OpenQA.Selenium;
using SpecFlowBDDAutomationFramework.Interfaces;
using SpecFlowBDDAutomationFramework.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBDDAutomationFramework.Settings
{
    public class ObjectRepository
    {
        public static IConfig Config { get; set; }
        public static IWebDriver Driver { get; set; }


        public static LoginPage lPage;
        public static ResultPage ePage;
    }
}
