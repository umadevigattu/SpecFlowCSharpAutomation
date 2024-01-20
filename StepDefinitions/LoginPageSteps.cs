using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowBDDAutomationFramework.ComponentHelper;
using SpecFlowBDDAutomationFramework.Pages;
using SpecFlowBDDAutomationFramework.Settings;
using SpecFlowBDDAutomationFramework.Interfaces;
using Excel.Log;
using System.Configuration;
using System.Security.Policy;
using Microsoft.Extensions.Configuration;
using SpecFlowBDDAutomationFramework.Configuration;
using SpecFlowBDDAutomationFramework.ExcelReader;

namespace SpecFlowBDDAutomationFramework.StepDefinitions
{
    [Binding]
    public sealed class LoginPageSteps
    {
        private IWebDriver driver;
        LoginPage loginPage;
       // IConfig Config;
        ResultPage resultPage;
        AppConfigReader appConfigReader;
        //private readonly ExcelReaderHelper excelReaderHelper;
        //private string filePath;
        private string sheetName;
        private string columnName;
        private int row;
        private string cellValue;
        //string excelpath = "C:\\Users\\aUTOMATION\\Downloads\\SpecFlowBDDAutomation-master\\SpecFlowBDDAutomation-master\\ExcelReader\\DataFiles";
        private string filePath = Path.Combine(Directory.GetCurrentDirectory(), "C:\\Users\\aUTOMATION\\Downloads\\SpecFlowBDDAutomation-master\\SpecFlowBDDAutomation-master\\ExcelReader\\DataFiles\\CreateForm.xlsx");

        public LoginPageSteps(IWebDriver driver)
        {
            this.driver = driver;
            loginPage = new LoginPage(driver);
            appConfigReader = new AppConfigReader();
           // excelReaderHelper = new ExcelReaderHelper();
        }

        [Given(@"I Enter the Voltas Url")]
        public void GivenIEnterTheVoltasUrl()
        {
           
            // driver.Url = "https://vserveq.voltasworld.com/iams";
            NavigationHelper.NavigateToUrl(appConfigReader.GetWebsite());
           // driver.Url = ConfigurationManager.AppSettings["Website"];
            Thread.Sleep(4000);
        }


        [Given(@"I Login to Application")]
        public void GivenILoginToApplication()
        {  
            loginPage.LogintoApp(appConfigReader.GetUsername(), appConfigReader.GetPassword());
            Thread.Sleep(4000);
        }

        [When(@"Create form (.*),(.*),(.*),(.*)")]
        public void WhenCreateform(string ExcelFileName, string SheetName,string columnName, string rowNum)
        {
            
            int row = int.Parse(rowNum);
            loginPage.createForm(ExcelFileName, SheetName, columnName, row);
            Thread.Sleep(4000);
        }

        [When(@"Delete form (.*),(.*),(.*),(.*)")]
        public void WhenDeleteform(string ExcelFileName, string SheetName, string columnName, string rowNum)
        {
            int row = int.Parse(rowNum);
            loginPage.deleteActivty(ExcelFileName, SheetName, columnName, row);
            
        }

        [Then(@"Logout from App")]
        public void ThenLogoutFromApp()
        {
            loginPage.LogOut();
        }


    }
}