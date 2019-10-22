using System;
using System.Collections.Generic;
using System.Text;

namespace Training4.Models
{
    [Serializable]
    public class Car
    {
        public int carId;
        public decimal price;
        public int quantity;
        [NonSerialized]
        public decimal total;
        

        public Car(int carId, decimal price, int quantity) {
            this.carId = carId;
            this.price = price;
            this.quantity = quantity;
            this.total = price * quantity;
        }

        public Car() { }
    }
}
