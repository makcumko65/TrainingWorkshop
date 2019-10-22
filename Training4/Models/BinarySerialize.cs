using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Training4.Interfaces;

namespace Training4.Models
{
    public class BinarySerialize : ISerialize
    {
        public string Way { get; set; }
        private BinaryFormatter formatter = new BinaryFormatter();

        public BinarySerialize(string Way) {
            this.Way = Way;
        }

        public void Serialize(ICollection<Car> cars)
        {
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream($@"{Way}", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, cars);

                Console.WriteLine("Object is serialized");
            }
        }

        public List<Car> Deserialize()
        {
            using (FileStream fs = new FileStream($@"{Way}", FileMode.OpenOrCreate))
            {
                var newCars = (List<Car>)formatter.Deserialize(fs);

                foreach (var item in newCars)
                {
                    Console.WriteLine($"Price: {item.price} --- Quantity: {item.quantity}");
                }
                Console.WriteLine("Object is Deserialize");
                return newCars;
            }
        }
    }
}
