﻿using System;
using System.Collections.Generic;
using System.Text;
using Training10.Interfaces;

namespace Training10.Services
{
    public class RandomCounter : ICounter
    {
        static Random Rnd = new Random();
        private int _value;
        public RandomCounter()
        {
            _value = Rnd.Next(0, 1000000);
        }
        public int Value
        {
            get { return _value; }
        }
    }
}
