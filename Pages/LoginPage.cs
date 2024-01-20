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
using SpecFlowBDDAutomationFramework.ExcelReader;
using OpenQA.Selenium.Interactions;

namespace SpecFlowBDDAutomationFramework.Pages
{
    public class LoginPage : BaseUtils
    {
        private IWebDriver driver;
        ExcelReaderHelper excelReaderHelper;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            //excelReaderHelper = new ExcelReaderHelper();
            ObjectRepository.Driver = driver;   
        }
        By userName = By.XPath("//input[@Id='UserID']");
        By password = By.XPath("//input[@Id='Password']");
        By loginButton = By.XPath("//button[@type='submit']");
        By formsConfiguration = By.XPath("//a[contains(text(),'Forms Configuration')]");
        By newButton = By.XPath("//span[contains(text(),'New')]");
        By category = By.XPath("//select[@id='ProductCategoryId']");
        By processType = By.XPath("//select[@id='ProcessTypeId']");
        By activityName = By.XPath("//input[@Id='ActivityName']");
        By saveButton = By.XPath("//button[@name='assetcreate']");
        By successMessage = By.XPath("//label[contains(text(),'Created successfully')]");
        By closedPopup = By.XPath("//a[@id='closePopupNotificationView']");
        By userProfile = By.XPath("//a[@id='userProfileDropdown']");
        By logoutButton = By.XPath("//a[@id='btnSignout']");
        By logoutButtonYes = By.XPath("//button[contains(text(),'Yes')]");
        By searchActivity = By.XPath("//input[@type='search'][@aria-controls='activtyList']");
        By optionsPopup = By.XPath("//div[@class='dropdownnew-content']");
        By deleteActivity = By.XPath("//span[contains(text(),'Delete')]");
        By activitiyOption = By.XPath("//div[@class='dropdownnew']");
        By deleteSuccessMessage = By.XPath("//label[contains(text(),'Activity deleted successfully.')]");

        [FindsBy(How = How.XPath, Using = "//*[@id='activtyList']/tbody/tr/td[9]/div/button")]
        private IWebElement activitiyOption1;

     
        public IWebElement category1 => driver.FindElement(By.XPath("//select[@id='ProductCategoryId']"));
        public IWebElement processType1 => driver.FindElement(By.XPath("//select[@id='ProcessTypeId']"));

        // public IWebElement password => driver.FindElement(By.Id("Password"));
        public IWebElement LoginButton => driver.FindElement(By.XPath("//button[@type='submit']"));
      
        public void LogintoApp(string usernme,string pwd)
        {
            TextBoxHelper.TypeInTextBox(userName, usernme);
            TextBoxHelper.TypeInTextBox(password, pwd);
            ButtonHelper.ClickButton(loginButton);
        }
        public void createForm(string ExcelFileName,string SheetName, string columnName, int row)
        {
            FreeSpireExcelReader freeSpireExcelReader = new FreeSpireExcelReader();
            //excelReaderHelper = new FreeSpireExcelReader(GetExcelFilePath(ExcelFileName));
            //excelReaderHelper.GetExcelFilePath(ExcelFileName);
            string actdesc = freeSpireExcelReader.GetCellData(ExcelFileName, SheetName, columnName, row);
            GenericHelper.WaitForWebElementInPage(formsConfiguration, TimeSpan.FromSeconds(30));
            LinkHelper.ClickLink(formsConfiguration);
            GenericHelper.WaitForWebElementInPage(newButton, TimeSpan.FromSeconds(30));
            ButtonHelper.ClickButton(newButton);
            GenericHelper.WaitForWebElementInPage(category, TimeSpan.FromSeconds(30));
            category1.Click();
            category1.SendKeys(Keys.Down);
            category1.SendKeys(Keys.Return);
            category1.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            processType1.Click();
            processType1.SendKeys(Keys.Down);
            processType1.SendKeys(Keys.Return);
            processType1.SendKeys(Keys.Enter);
           // ComboBoxHelper.SelectElementByValue(processType, "Scrap");
            TextBoxHelper.TypeInTextBox(activityName, actdesc);
            ButtonHelper.ClickButton(saveButton);
            GenericHelper.WaitForWebElementInPage(successMessage, TimeSpan.FromSeconds(30));
            ButtonHelper.ClickButton(closedPopup);

        }

        public void deleteActivty(string ExcelFileName, string SheetName, string columnName, int row) {
            FreeSpireExcelReader freeSpireExcelReader = new FreeSpireExcelReader();
            //excelReaderHelper = new FreeSpireExcelReader(GetExcelFilePath(ExcelFileName));
            //excelReaderHelper.GetExcelFilePath(ExcelFileName);
            string actdesc = freeSpireExcelReader.GetCellData(ExcelFileName, SheetName, columnName, row);
            LinkHelper.ClickLink(formsConfiguration);
            GenericHelper.WaitForWebElementInPage(newButton, TimeSpan.FromSeconds(30));
            TextBoxHelper.TypeInTextBox(searchActivity, actdesc);
            Thread.Sleep(2000);
            IWebElement button = driver.FindElement(By.CssSelector("button.dropbtn"));

            // Create an instance to the Actions class
            Actions actions = new Actions(driver);

            // Perform the mouse hover action
            actions.MoveToElement(button).Perform();
            GenericHelper.WaitForWebElementInPage(optionsPopup, TimeSpan.FromSeconds(30));
            LinkHelper.ClickLink(deleteActivity);
            GenericHelper.WaitForWebElementInPage(deleteSuccessMessage, TimeSpan.FromSeconds(30));
            ButtonHelper.ClickButton(closedPopup);
            //deleteActivity.click();
        }
        public void LogOut()
        {
            ButtonHelper.ClickButton(userProfile);
            GenericHelper.WaitForWebElementInPage(logoutButton, TimeSpan.FromSeconds(30));
            ButtonHelper.ClickButton(logoutButton);
            GenericHelper.WaitForWebElementInPage(logoutButtonYes, TimeSpan.FromSeconds(30));
            ButtonHelper.ClickButton(logoutButtonYes);

            
        }

    }
}
