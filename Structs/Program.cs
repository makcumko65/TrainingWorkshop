using Logger.Models;
using Structs.Models;
using Training4.Models;
using System;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

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



            //FileHelper fileHelper = new FileHelper();
            //FileLogger fileLogger = new FileLogger();
            //try { 
            //    string data = fileHelper.GetAllFilesByDirectory("d:\\EPAM.NET\\Structs");
            //    consolePrinter.WriteLine(data);
            //    fileLogger.Save("d:\\EPAM.NET\\Structs\\data.txt", data);
            //}
            //catch(DirectoryNotFoundException)
            //{
            //    consolePrinter.WriteLine("WRONG DIRECTORY");
            //}
            //consolePrinter.WriteLine(fileHelper.SearchFileByPartialName("dat", @"d:\"));
            
            FileLogger fileLogger = new FileLogger();
            try
            {
                int a = 0;
                int b = 2 / a;
            }
            catch (DivideByZeroException ex)
            {
                try
                {
                    fileLogger.Error(ex, "some message");
                }
                catch(ArgumentException ex2)
                {
                    Console.WriteLine(ex2.Message);
                }
            };
            try
            {
                fileLogger.Debug("Debug Message");
                fileLogger.Info("Info message");
                fileLogger.Fatal("Fatal message");
                fileLogger.Warn("Warn message");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            };
            //Car car = new Car(1,(decimal)32.213, 1000,(decimal)33.213);
            List<Car> cars = new List<Car>()
            {
                new Car(1,(decimal)32.213, 10),
                new Car(2,(decimal)12.213, 100),
                new Car(3,(decimal)42.213, 1000),
                new Car(4,(decimal)2.213, 1000)
            };
            BinarySerialize binarySerialize = new BinarySerialize("cars.dat");
            binarySerialize.Serialize(cars);
            binarySerialize.Deserialize();

            XMLSerialize xMLSerialize = new XMLSerialize();
            xMLSerialize.Serialize(cars);
            xMLSerialize.Deserialize();

            JSONSerialize jSONSerialize = new JSONSerialize();
            jSONSerialize.Serialize(cars);

            Console.ReadLine();
        }
    }
}
