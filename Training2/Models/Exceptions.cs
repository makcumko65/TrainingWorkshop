using System;
using System.Collections.Generic;
using System.Text;

namespace Training2.Models
{
    public class Exceptions
    {
        public void StackOverflow()
        {

        }

        public void IndexOutOfRange()
        {
            int[] arr = new int[2] { 2, 1 };
            try
            {
                for (int i = 0; i <= arr.Length; i++)
                {
                    int number = arr[i];
                }
            }
            catch(IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void DoSomeMath(int a, int b)
        {
            if (a < 0)
                throw new ArgumentException();
            if (b > 0)
                throw new ArgumentException();
        }
    }
}
