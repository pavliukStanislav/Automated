using Automated.Configurations;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;

namespace Automated.OtherTools.Excel
{
    public static class FileCreator
    {
        static FileCreator()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public static void SaveToExcelFile(IEnumerable<ExampleExcelTemplate> fileData, string fileName)
        {
            string path = Path.Combine(EnvironmentVariables.WorkingDirectory, "ExcellFiles", fileName + ".xlsx");

            using DataTable dataTable = ConvertToDataTable(fileData);
            dataTable.GenerateExcel(path);
        }

        private static DataTable ConvertToDataTable<T>(IEnumerable<T> models)
        {
            var dataTable = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                dataTable.Columns.Add(prop.Name);
            }

            foreach (T item in models)
            {
                var values = new object[props.Length];

                for (var i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        private static void GenerateExcel(this DataTable dataTable, string path)
        {
            using Stream stream = ToXlsxStream(dataTable);

            using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);

            stream.Seek(0, SeekOrigin.Begin);
            stream.CopyTo(fileStream);
        }

        private static Stream ToXlsxStream(DataTable table)
        {
            const uint sheetId = 1;

            var stream = new MemoryStream();

            using var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook);

            WorkbookPart workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();
            document.WorkbookPart!.Workbook.AppendChild(new Sheets());

            var sheetPart = document.WorkbookPart.AddNewPart<WorksheetPart>();
            var sheetData = new SheetData();
            sheetPart.Worksheet = new Worksheet(sheetData);

            var sheets = document.WorkbookPart.Workbook.GetFirstChild<Sheets>();
            string relationshipId = document.WorkbookPart.GetIdOfPart(sheetPart);

            var sheet = new Sheet
            {
                Id = relationshipId,
                SheetId = sheetId,
                Name = "SheetName"
            };

            sheets!.AppendChild(sheet);

            DataColumnCollection columns = table.Columns;

            foreach (DataRow tableRow in table.Rows)
            {
                var newRow = new Row();

                foreach (DataColumn col in columns)
                {
                    var cell = new Cell
                    {
                        DataType = CellValues.String,
                        CellValue = new CellValue(tableRow[col.ColumnName].ToString() ?? string.Empty)
                    };

                    newRow.AppendChild(cell);
                }

                sheetData.AppendChild(newRow);
            }

            workbookPart.Workbook.Save();

            stream.Position = 0;

            return stream;
        }
    }
}
