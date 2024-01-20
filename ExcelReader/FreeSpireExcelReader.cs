using SpecFlowBDDAutomationFramework.ComponentHelper;
using Spire.Xls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace SpecFlowBDDAutomationFramework.ExcelReader
{
    public class FreeSpireExcelReader : BaseUtils
    {
        public string GetCellData(string excelFileName, string sheetName, string columnName, int row)
        {
            string filePath = GetExcelFilePath(excelFileName);

            // Load the Excel file
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(filePath);

            // Get the specified worksheet
            Worksheet worksheet = workbook.Worksheets[sheetName];

            // Find the column index based on the column name
            int columnIndex = -1;
            foreach (CellRange column in worksheet.Rows[0])
            {
                if (column.Text == columnName)
                {
                    columnIndex = column.Column;
                    break;
                }
            }

            if (columnIndex == -1)
            {
                throw new ArgumentException($"Column '{columnName}' not found in the Excel sheet.");
            }

            // Read the cell value
            string cellValue = worksheet.Range[row, columnIndex].Value;

            return cellValue;
        }
    }
}
