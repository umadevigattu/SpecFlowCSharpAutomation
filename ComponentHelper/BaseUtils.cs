using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBDDAutomationFramework.ComponentHelper
{
    public class BaseUtils
    {
        public string GetExcelFilePath(string ExcelFileName)
        {
            string fpath = AppDomain.CurrentDomain.BaseDirectory.Contains("\\bin\\Debug") ? AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "") : AppDomain.CurrentDomain.BaseDirectory;
            string xlFilePath = fpath + "DataFiles\\" + ExcelFileName + ".xlsx";
            return xlFilePath;
        }
    }
}
