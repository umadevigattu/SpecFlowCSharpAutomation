using Excel;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using xl = Microsoft.Office.Interop.Excel;

namespace SpecFlowBDDAutomationFramework.ExcelReader
{
    class ExcelReaderHelper
    {
        xl.Application xlApp = null;
        xl.Workbooks workbooks = null;
        xl.Workbook workbook = null;
        Hashtable sheets;
        public string xlFilePath;


        public ExcelReaderHelper(string xlFilePath)
        {
            this.xlFilePath = xlFilePath;
        }

        public ExcelReaderHelper()
        {
        }

        public void openExcel() {
            xlApp = new xl.Application();
            workbooks = xlApp.Workbooks;
            workbook = workbooks.Open(xlFilePath);
            sheets = new Hashtable();
            int count = 1;
            foreach (xl.Worksheet sheet in workbook.Sheets)
            {
                sheets[count] = sheet.Name;
                count++;
            }
        }



        public void CloseExcel() {
            workbook.Close(false, xlFilePath, null);
            Marshal.FinalReleaseComObject(workbook);
            workbook = null;

            workbooks.Close();
            Marshal.FinalReleaseComObject(workbooks);
            workbooks = null;

            xlApp.Quit();
            Marshal.FinalReleaseComObject(xlApp);
            xlApp = null;

        }

        public string GetCellData(string sheetName, string colName, int rowNumber) {
            openExcel();
            string value = string.Empty;
            int sheetValue = 0;
            int colNumber = 0;
            if (sheets.ContainsValue(sheetName))
            {
                foreach (DictionaryEntry sheet in sheets)
                {
                    if (sheet.Value.Equals(sheetName)) {
                        sheetValue = (int)sheet.Key;
                    }
                }
                xl.Worksheet worksheet = null;
                worksheet = workbook.Worksheets[sheetValue] as xl.Worksheet;
                xl.Range range = worksheet.UsedRange;
                for (int i = 1; i <= range.Columns.Count; i++)
                {
                    string colNameValue = Convert.ToString((range.Cells[1, i] as xl.Range).Value2);
                    if (colNameValue.ToLower() == colName.ToLower())
                    {
                        colNumber = i;
                        break;
                    }
                }
                value = Convert.ToString((range.Cells[rowNumber, colNumber] as xl.Range).Value2);
                Marshal.FinalReleaseComObject(worksheet);
                worksheet = null;
            }
            CloseExcel();
            return value;
        }
    }
}
     /*   public void Load(string filePath) { 
            excelPackage = new ExcelPackage(new FileInfo(filePath));
        }

        public void SelectSheet(string sheetName) { 
            currentWorksheet = excelPackage.Workbook.Worksheets[sheetName];
        
        }

        public string ReadCell(string columnName, int row) {
            var columnIndex = GetColumnIndexFromName(columnName);
            return currentWorksheet.Cells[row, columnIndex].Value?.ToString();
        
        }
        private int GetColumnIndexFromName(string columnName)
        {
            var columnCount = currentWorksheet.Dimension.End.Column;
            for (int col = 1; col <= columnCount; col++)
            {
                var cellValue = currentWorksheet.Cells[1, col].Value?.ToString();
                if (string.Equals(cellValue, columnName, StringComparison.OrdinalIgnoreCase))
                    return col;
            }
            return -1;
        }*/

       /* private static IExcelDataReader GetExcelReader(string xlPath, string sheetName)
        {
            if (_cache.ContainsKey(sheetName))
            {
                reader = _cache[sheetName];
            }
            else
            {
                stream = new FileStream(xlPath, FileMode.Open, FileAccess.ReadWrite);
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                _cache.Add(sheetName, reader);
            }
            return reader;
        }


        public static int GetTotalRows(string xlPath, string sheetName)
        {
            IExcelDataReader _reader = GetExcelReader(xlPath, sheetName);
            return _reader.AsDataSet().Tables[sheetName].Rows.Count;
        }

        public static object GetCellData(string xlPath, string sheetName, int row, int column)
        {

            IExcelDataReader _reader = GetExcelReader(xlPath, sheetName);
            DataTable table = _reader.AsDataSet().Tables[sheetName];
            return table.Rows[row][column];
        }

        private static object GetData(Type type, object data)
        {
            switch (type.Name)
            {
                case "String":
                    return data.ToString();
                case "Double":
                    return Convert.ToDouble(data);
                case "DateTime":
                    return Convert.ToDateTime(data);
                default:
                    return data.ToString();
            }
        }
    }
}*/
