using Automated.Data;
using Syncfusion.XlsIO;
using System.IO;
using TechTalk.SpecFlow;

namespace Automated.Transformations
{
    [Binding]
    public class FileTransformations
    {
        [StepArgumentTransformation(@"'(.*)' xlsx file")]
        public IWorkbook XlsxTransformation(string fileName)
        {
            using (var ee = new ExcelEngine())
            {
                var app = ee.Excel;
                app.DefaultVersion = ExcelVersion.Excel2016;

                var path = Path.Combine(FilePath.XlsxFiles, fileName + $".{FileExtension.xlsx.ToString("G")}");
                using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    return app.Workbooks.Open(fileStream, ExcelOpenType.Automatic);
                }
            }            
        }
    }
}
