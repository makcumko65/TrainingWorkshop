using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using Structs.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using Training7.Interface;

namespace Training7.Models
{
    public class ExcelReader : IReader
    {
        private readonly IPrinter printer;
        private readonly List<double> list = new List<double>();

        public ExcelReader(IPrinter printer)
        {
            this.printer = printer;
        }

        public ICollection<double> GetDataTableFromExcel(int column1, int column2)
        {
            var filePath = @"D:/EPAM.NET/Structs/TrainingWorkshop/Training7/excelfile.xlsx";
            FileInfo file = new FileInfo(filePath);
            var listColumn1 = new Dictionary<double,int>();
            var listColumn2 = new Dictionary<double,int>();

            using (ExcelPackage package = new ExcelPackage(file))
            {
                var totalWorksheet = package.Workbook.Worksheets.Count;

                for (int sheetIndex = 1; sheetIndex <= totalWorksheet; sheetIndex++)
                {
                    var worksheet = package.Workbook.Worksheets[sheetIndex];

                    int rowCount = worksheet.Dimension.Rows;
                    int ColCount = worksheet.Dimension.Columns;
                    for(int row = 1; row <= rowCount; row++)
                    {
                        try
                        {
                            double value = (double)worksheet.Cells[row, column1].Value;
                            if (!listColumn1.ContainsKey(value))
                                listColumn1.Add(value, 1);
                            else
                                listColumn1[value] += 1;
                        }
                        catch (NullReferenceException)
                        {
                            continue;
                        }
                    }
                    for (int row = 1; row <= rowCount; row++)
                    {
                        try
                        {
                            double value = (double)worksheet.Cells[row, column2].Value;
                            //Console.WriteLine($"Column {col}, Row {row} = {value}");
                            if (!listColumn2.ContainsKey(value))
                                listColumn2.Add(value, 1);
                            else
                                listColumn2[value] += 1;
                        }
                        catch(NullReferenceException)
                        {
                            continue;
                        }
                    }
                    //List<double> uniqueList = listOfNumbers.GroupBy(i => i).Where(i => i.Count() == 1).Select(i => i.Key);
                }
                var list1 = listColumn1.Where(x => x.Value == 1).Where(y => !listColumn2.ContainsKey(y.Key)).Select(k => k.Key).ToList();
                var list2 = listColumn2.Where(x => x.Value == 1).Where(y => !listColumn1.ContainsKey(y.Key)).Select(k => k.Key).ToList();
                
                var list = list1.Union(list2).ToList();
                return list;
               // Console.WriteLine();
            }
        }
        public void SaveIntoFile()
        {
            FileInfo uniqueFile = new FileInfo("uniqueExcelFile.xlsx");
            using (var uniqueExcelPackage = new ExcelPackage(uniqueFile))
            {
                var uniqueWorksheet = uniqueExcelPackage.Workbook.Worksheets.Add(DateTime.Now.ToString());

                for (int i = 0; i < list.Count; i++)
                {
                    uniqueWorksheet.Cells[i + 1, 1].Value = list[i];
                }

                uniqueExcelPackage.SaveAs(uniqueFile);
            }
        }
    }
}
