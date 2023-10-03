using OfficeOpenXml;

namespace HomeWork_20_Sentabr
{
    internal static class Ex
    {
        private static string path = @"D:\userdata.xlsx";

        public static void AddData()
        {
            Console.Write("Userdata count: ");
            string count = Console.ReadLine();
            if (!int.TryParse(count, out int sch))
            {
                return;
            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;


            using (var package = new ExcelPackage(path))
            {
                var sheet = package.Workbook.Worksheets["My Sheet"];

                for (int i = 1; i < sch + 1; i++)
                {
                    Console.Write("No: ");
                    string no = Console.ReadLine();
                    sheet.Cells[$"A{sch}"].Value = no;
                    package.Save();

                    Console.Write("Lastname Firstname: ");
                    string name = Console.ReadLine();
                    sheet.Cells[$"B{sch}"].Value = name;
                    package.Save();

                    Console.Write("Phone number: ");
                    string phone = Console.ReadLine();
                    sheet.Cells[$"C{sch}"].Value = phone;
                    package.Save();

                    Console.Write("Date of birth: ");
                    string datest = Console.ReadLine();

                    if (DateTime.TryParse(datest, out DateTime date))
                    {
                        sheet.Cells[$"D{sch}"].Value = date.ToString("dd MM yyyy");
                    }
                    Console.WriteLine("*******************************");
                }


            }
        }
        public static void ReadData(string from, string to)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(path))
            {
                var worksheet = package.Workbook.Worksheets["My Sheet"];
                var jsondata = worksheet.Cells[$"{from}:{to}"].ToJson();

                Console.WriteLine(jsondata);
            }
        }
    }
}
