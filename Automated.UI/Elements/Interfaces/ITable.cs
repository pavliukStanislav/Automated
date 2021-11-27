using System.Collections.Generic;

namespace Automated.UI.Elements.Interfaces
{
    public interface ITable: IBaseElement
    {
        string GetCellText(int columnIndex, int rowIndex);
        string GetCellText(string columntName, int rowIndex);
        int GetColumnIntex(string columnName);
        List<string> GetColumnValues(int columnIndex);
        List<string> GetColumnValues(string cellName);
        int GetRowsCount();
        List<string> GetRowValues(int rowIndex);
        List<List<string>> GetTableValues();
    }
}
