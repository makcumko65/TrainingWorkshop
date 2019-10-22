using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Training4.Interfaces;

namespace Training4.Models
{
    public class JSONSerialize : ISerialize
    {
        JsonSerializer serializer = new JsonSerializer();
        public List<Car> Deserialize()
        {
            List<Car> newCars;
            using (StreamReader file = File.OpenText("cars.json"))
            {
                newCars = (List<Car>)serializer.Deserialize(file, typeof(List<Car>));
            }
            return newCars;
        }

        public void Serialize(ICollection<Car> cars)
        {
            //using (FileStream fs = new FileStream("car.json", FileMode.OpenOrCreate))
            //{
            //    var result = JsonConvert.SerializeObject(cars);
            //    Console.WriteLine(result);
            //    Console.WriteLine();
            //}
            using (StreamWriter sw = new StreamWriter("cars.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, cars);
            }
        }
    }
}
