using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBDDAutomationFramework.ComponentHelper
{
    [Obsolete]
    public class CustomWebElement : RemoteWebElement
    {
        private string ElementName = "Default Name";
        public string Name
        {
            set
            {
                ElementName = value;
            }
        }

        public CustomWebElement(RemoteWebDriver parentDriver, string id) : base(parentDriver, id)
        {

        }

        public override string ToString()
        {
            return ElementName;
        }


    }
}
