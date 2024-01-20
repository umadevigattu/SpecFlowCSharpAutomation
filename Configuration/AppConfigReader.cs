using Microsoft.Extensions.Configuration;
using SpecFlowBDDAutomationFramework.Interfaces;
using SpecFlowBDDAutomationFramework.Settings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBDDAutomationFramework.Configuration
{
    public class AppConfigReader
    {
        IConfiguration configuration;
        public AppConfigReader() {
            configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();
        }
        public BrowserType? GetBrowser()
        {
            string browser = System.Configuration.ConfigurationManager.AppSettings.Get(AppConfigKeys.Browser);
            try
            {
                return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int GetElementLoadTimeOut()
        {
            string timeout = System.Configuration.ConfigurationManager.AppSettings.Get(AppConfigKeys.ElementLoadTimeout);
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);
        }

        public int GetPageLoadTimeOut()
        {
            string timeout = System.Configuration.ConfigurationManager.AppSettings.Get(AppConfigKeys.PageLoadTimeout);
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);
        }

        public string GetPassword()
        {
            string value = null;
            foreach (var config in configuration.GetChildren())
            {
                if (config.Key.Equals("Password"))
                {
                    value = config.Value;
                }
            }
            return value;
        }

        public string GetUsername()
        {
            string value = null;
            foreach (var config in configuration.GetChildren())
            {
                if (config.Key.Equals("Username"))
                {
                    value = config.Value;
                }
            }
            return value;
        }

        public string GetWebsite()
        {
            string value = null;
            foreach (var config in configuration.GetChildren()) {
                if (config.Key.Equals("Url")) { 
                    value = config.Value;
                }
            }
            return value;
        }
    }
}
