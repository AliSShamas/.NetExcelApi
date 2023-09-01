using NPOI.XSSF.UserModel;

public interface IExcelReaderService
{
    List<Person> ReadExcelData(string filePath);
}

public class ExcelReaderService : IExcelReaderService
{
    public List<Person> ReadExcelData(string filePath)
    {
        var people = new List<Person>();

        using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            var workbook = new XSSFWorkbook(fs);
            var sheet = workbook.GetSheetAt(0);

            for (int i = 1; i <= sheet.LastRowNum; i++)
            {
                var row = sheet.GetRow(i);
                var person = new Person
                {
                    Name = row.GetCell(0).StringCellValue,
                    Age = (int)row.GetCell(1).NumericCellValue
                };
                people.Add(person);
            }
        }

        return people;
    }
}
