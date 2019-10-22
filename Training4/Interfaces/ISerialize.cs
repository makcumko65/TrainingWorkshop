using System;
using System.Collections.Generic;
using System.Text;
using Training4.Models;

namespace Training4.Interfaces
{
    public interface ISerialize
    {
        void Serialize(ICollection<Car> cars);
        List<Car> Deserialize();

    }
}
