using Excel.Log;
using SpecFlowBDDAutomationFramework.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBDDAutomationFramework.ComponentHelper
{
    public class NavigationHelper
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(NavigationHelper));
        public static void NavigateToUrl(string Url)
        {
            //  driver = BrowserType.Chrome;
            ObjectRepository.Driver.Navigate().GoToUrl(Url);
            Logger.Info(" Navigate To Page " + Url);
        }
    }
}
