using System;
using System.Collections.Generic;
using System.Text;

namespace Structs
{
    public struct Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public Person(string Name, string Surname, int Age)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
        }

        public string GetFormatPerson(int n)
        {
            if(n > 0 || Age > 0)
            {
                return n > Age ? $"{Name} {Surname} older than {n}": $"{Name} {Surname} younger than {n}";
            }
            return "Age must be > 0";
        }
    }
}
