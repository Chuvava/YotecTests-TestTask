using ExcelDataReader;
using System.Data;
using System.IO;


namespace YotecTestsV1.ExcelReader
{
    public class ExcelReaderHelper
    {
        private static FileStream stream;
        private static IExcelDataReader reader;

        public static string GetCellData(string xlPath, int row, int column)
        {
            stream = new FileStream(xlPath, FileMode.Open, FileAccess.Read);
            reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            DataTable table = reader.AsDataSet().Tables[0];

            return table.Rows[row][column].ToString();
        }

    }
}
