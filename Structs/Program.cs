using Logger.Models;
using Training4.Models;
using System;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using Structs.Models;
using Training5.Models;
using Training7.Models;
using System.Data;
using Training8.Models;
using Training3.Models;

namespace Structs
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePrinter consolePrinter = new ConsolePrinter();
            //Person person = new Person("Tom", "Surname", 18);
            //Console.WriteLine(person.GetFormatPerson(2));
            //Console.WriteLine(person.GetFormatPerson(22));
            //Console.WriteLine();

            //Rectangle rectangle = new Rectangle(3, 4, 10, 5);
            //Console.WriteLine($"P = {rectangle.Perimetr()}");

            //Console.Write("Enter n:");
            //Int32.TryParse(Console.ReadLine(), out int n);
            //Console.WriteLine(Enum.GetName(typeof(Month), n));
            //Exceptions exceptions = new Exceptions();
            //try
            //{
            //    exceptions.IndexOutOfRange();
            //}
            //catch(IndexOutOfRangeException ex)
            //{
            //    consolePrinter.WriteLine(ex.Message);
            //}



            FileHelper fileHelper = new FileHelper();
            FileLogger fileLogger = new FileLogger();
            try
            {
                string data = fileHelper.GetAllFilesByDirectory("d:\\EPAM.NET\\Structs");
                consolePrinter.WriteLine(data);
                //fileLogger.Save("d:\\EPAM.NET\\Structs\\data.txt", data);
            }
            catch (DirectoryNotFoundException)
            {
                consolePrinter.WriteLine("WRONG DIRECTORY");
            }
            //consolePrinter.WriteLine(fileHelper.SearchFileByPartialName("dat", @"d:\"));

            //FileLogger fileLogger = new FileLogger();
            //try
            //{
            //    int a = 0;
            //    int b = 2 / a;
            //}
            //catch (DivideByZeroException ex)
            //{
            //    try
            //    {
            //        fileLogger.Error(ex, "some message");
            //    }
            //    catch(ArgumentException ex2)
            //    {
            //        Console.WriteLine(ex2.Message);
            //    }
            //};
            //try
            //{
            //    fileLogger.Debug("Debug Message");
            //    fileLogger.Info("Info message");
            //    fileLogger.Fatal("Fatal message");
            //    fileLogger.Warn("Warn message");
            //}
            //catch (ArgumentException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //};
            //Car car = new Car(1,(decimal)32.213, 1000,(decimal)33.213);
            //List<Car> cars = new List<Car>()
            //{
            //    new Car(1,(decimal)32.213, 10),
            //    new Car(2,(decimal)12.213, 100),
            //    new Car(3,(decimal)42.213, 1000),
            //    new Car(4,(decimal)2.213, 1000)
            //};
            //BinarySerialize binarySerialize = new BinarySerialize("cars.dat");
            //binarySerialize.Serialize(cars);
            //binarySerialize.Deserialize();

            //XMLSerialize xMLSerialize = new XMLSerialize();
            //xMLSerialize.Serialize(cars);
            //xMLSerialize.Deserialize();

            //JSONSerialize jSONSerialize = new JSONSerialize();
            //jSONSerialize.Serialize(cars);
            //Reflection reflection = new Reflection(consolePrinter);
            //reflection.GetInfoAboutDLL("Logger.dll");
            //ExcelReader excelReader = new ExcelReader(consolePrinter);
            //System.Diagnostics.Stopwatch time = System.Diagnostics.Stopwatch.StartNew();
            //var smth = excelReader.GetDataTableFromExcel(1,2);
            //foreach (var item in smth)
            //{
            //    Console.WriteLine(item);
            //}
            //time.Stop();
            //consolePrinter.WriteLine(time.Elapsed.TotalMilliseconds.ToString());
            //excelReader.SaveIntoFile();

            //Console.Write("Enter a: ");
            //double x = Double.Parse(Console.ReadLine());
            //Console.Write("Enter b: ");
            //double y = Double.Parse(Console.ReadLine());
            //Console.Write("Enter operation: ");
            //char operation = Char.Parse(Console.ReadLine());
            //ConsoleCalculator consoleCalculator = new ConsoleCalculator(consolePrinter);
            //consolePrinter.WriteLine(consoleCalculator.Calculation(x, y, operation).ToString());
            //FileCalculator fileCalculator = new FileCalculator();
            //var tuple = ReadFromFile();
            //SaveToFile(fileCalculator.Calculation(tuple.Item1, tuple.Item2, tuple.Item3));
            // FileManager fileManager = new FileManager(consolePrinter);
            //fileManager.GetDublicateFilesInFolder("d:\\EPAM.NET\\Structs");
            Console.ReadLine();
        }
        public static (double,double,char) ReadFromFile()
        {
            var wayToRead = ConfigurationManager.AppSettings.Get("UrlToReadInFile");
            using (StreamReader sr = new StreamReader(wayToRead))
            {
                var helper = sr.ReadToEnd();
                try
                {
                    (double,double,char) result = (helper[0],helper[1],helper[2]);
                    Console.WriteLine(result.Item1.ToString());
                    Console.WriteLine(result.Item2.ToString());
                    return result;
                }
                catch (NullReferenceException)
                {
                    throw new NullReferenceException();
                }
            }
        }
        private static void SaveToFile(double result)
        {
            var wayToSave = ConfigurationManager.AppSettings.Get("UrlToSaveInFile");
            using (StreamWriter sr = new StreamWriter(wayToSave))
            {
                sr.WriteLine(result);
            }
        }
    }
}
