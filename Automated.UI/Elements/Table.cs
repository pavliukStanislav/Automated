using Automated.UI.Elements.Interfaces;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Automated.UI.Elements
{    
    public class Table : BaseElement, ITable
    {
        /// <summary>
        /// Header, should have some text
        /// </summary>
        private string HeaderNameXPath => xpath + "/*[@class='header']";

        /// <summary>
        /// Should have elemtn, found by indexes
        /// </summary>
        private string CellXPathMask => xpath + "/*[@class='row'][{0}]//*[@class='cell'][{1}]";

        /// <summary>
        /// SHould contains row
        /// </summary>
        private string RowXPath => xpath + "/*[@class='row']";

        /// <summary>
        /// Should contait row by row index
        /// </summary>
        private string RowXPathMask => RowXPath + "[{0}]";

        /// <summary>
        /// Should containt column
        /// </summary>
        private string ColumnXpath => xpath + "/*[@class='cell']";

        /// <summary>
        /// Should contain column by column index
        /// </summary>
        private string ColumnXpathMask => ColumnXpath + "[{0}]";

        public Table(string xpath, Browser browser) : base(xpath, browser)
        {
        }

        /// <summary>
        /// Get column index by name
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public int GetColumnIntex(string columnName)
        {
            var headers = browser.Driver.FindElements(By.XPath(HeaderNameXPath)).ToList();

            return headers.FindIndex(x => x.Text == columnName) + 1;
        }

        /// <summary>
        /// Get text from cell by row and column indexes
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public string GetCellText(int columnIndex, int rowIndex)
        {
            return wait.ForElementVisible(string.Format(CellXPathMask, rowIndex, columnIndex)).Text;
        }

        /// <summary>
        /// Get text from cell by row index and column name
        /// </summary>
        /// <param name="columntName"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public string GetCellText(string columntName, int rowIndex)
        {
            var columnIndex = GetColumnIntex(columntName);

            return GetCellText(columnIndex, rowIndex);
        }

        /// <summary>
        /// Get texts from all cells in column by column index
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        public List<string> GetColumnValues(int columnIndex)
        {
            return browser.Driver.FindElements(By.XPath(string.Format(ColumnXpathMask, columnIndex))).Select(x => x.Text).ToList();
        }

        /// <summary>
        /// Get texts from all cells in column by column name
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public List<string> GetColumnValues(string cellName)
        {
            var columnIndex = GetColumnIntex(cellName);

            return GetColumnValues(columnIndex);
        }

        /// <summary>
        /// Get texts from all cells in row by index
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public List<string> GetRowValues(int rowIndex)
        {
            return browser.Driver.FindElements(By.XPath(string.Format(RowXPathMask, rowIndex))).Select(x => x.Text).ToList();
        }

        /// <summary>
        /// Get values from all cells in table
        /// </summary>
        /// <returns></returns>
        public List<List<string>> GetTableValues()
        {
            var rowsCount = GetRowsCount();

            var result = new List<List<string>>();
            for (int i = 1; i <= rowsCount; i++)
            {
                result.Add(GetRowValues(i));
            }

            return result;
        }

        /// <summary>
        /// Get rows count
        /// </summary>
        /// <returns></returns>
        public int GetRowsCount()
        {
            return browser.Driver.FindElements(By.XPath(RowXPath)).Count;
        }
    }
}
