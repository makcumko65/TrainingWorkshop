using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Training4.Interfaces;

namespace Training4.Models
{
    public class XMLSerialize: ISerialize
    {
        private XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));

        public void Serialize(ICollection<Car> cars)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));
            using (FileStream fs = new FileStream("SerializedDate.XML", FileMode.Create))
            {
                serializer.Serialize(fs, cars);
            }  
        }

        public List<Car> Deserialize()
        {
            using (FileStream fs = new FileStream("SerializedDate.XML", FileMode.OpenOrCreate))
            {
                var newCars = (List<Car>)serializer.Deserialize(fs);

                foreach (var item in newCars)
                {
                    Console.WriteLine($"Price: {item.price} --- Quantity: {item.total}");
                }
                Console.WriteLine("Object is Deserialize");
                return newCars;
            }
        }
    }
}
