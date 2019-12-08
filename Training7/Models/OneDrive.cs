using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Training7
{
    public class OneDrive
    {
        public async void GetData(int column1, int column2)
        {
            string baseUrl = @"https://onedrive.live.com/edit.aspx?cid=a20807952a3766bd&page=view&resid=A20807952A3766BD!130&parId=A20807952A3766BD!103&app=Excel";
            //Have your using statements within a try/catch block
            try
            {
                //We will now define your HttpClient with your first using statement which will use a IDisposable.
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();

                            Stream stream = await content.ReadAsStreamAsync();
                            ReadExcel(column1, column2, stream);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Hit------------");
                Console.WriteLine(exception);
            }
        }

        public void ReadExcel(int columnn1, int column2, Stream stream)
        {
            var listColumn1 = new Dictionary<double, int>();
            var listColumn2 = new Dictionary<double, int>();

            using (ExcelPackage package = new ExcelPackage(stream))
            {
                var totalWorksheet = package.Workbook.Worksheets.Count;

                for (int sheetIndex = 1; sheetIndex <= totalWorksheet; sheetIndex++)
                {
                    var worksheet = package.Workbook.Worksheets[sheetIndex];

                    int rowCount = worksheet.Dimension.Rows;
                    int ColCount = worksheet.Dimension.Columns;
                    for (int row = 1; row <= rowCount; row++)
                    {
                        try
                        {
                            double value = (double)worksheet.Cells[row, columnn1].Value;
                            if (!listColumn1.ContainsKey(value))
                                listColumn1.Add(value, 1);
                            else
                                listColumn1[value] += 1;
                        }
                        catch (NullReferenceException)
                        {
                            continue;
                        }
                        try
                        {
                            double value = (double)worksheet.Cells[row, column2].Value;
                            //Console.WriteLine($"Column {col}, Row {row} = {value}");
                            if (!listColumn2.ContainsKey(value))
                                listColumn2.Add(value, 1);
                            else
                                listColumn2[value] += 1;
                        }
                        catch (NullReferenceException)
                        {
                            continue;
                        }
                    }
                    //List<double> uniqueList = listOfNumbers.GroupBy(i => i).Where(i => i.Count() == 1).Select(i => i.Key);
                }
                var list1 = listColumn1.Where(x => x.Value == 1).Where(y => !listColumn2.ContainsKey(y.Key)).Select(k => k.Key).ToList();
                var list2 = listColumn2.Where(x => x.Value == 1).Where(y => !listColumn1.ContainsKey(y.Key)).Select(k => k.Key).ToList();

                var list = list1.Union(list2).ToList();
            }
        }
    }
}
