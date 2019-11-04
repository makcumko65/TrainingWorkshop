using Structs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training9.Interfaces;

namespace Training9.Models
{
    public class ParallelSum : IParallelSum
    {
        private readonly IPrinter printer;
        private readonly int[,] nums;
        private Random random = new Random();

        public int Rows { get; set; }
        public int Columns { get; set; }

        public ParallelSum(IPrinter printer, int Rows, int Columns)
        {
            this.printer = printer;
            this.Rows = Rows;
            this.Columns = Columns;
            nums = new int[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    nums[i, j] = random.Next(1, 1000);
                }
            }
        }

        public int GetParallelSum(int numberOfThreads)
        {
            int columnInOneThread = Columns / numberOfThreads;
            Task[] tasks = new Task[numberOfThreads];
            List<int> sum = new List<int>();

            for (int k = 0; k < numberOfThreads; k++)
            {
                int x = k;
                tasks[x] = new Task(() =>
                {
                    for (int i = 0; i < Rows; i++)
                    {
                        for (int j = x * columnInOneThread; j < columnInOneThread * (x+1); j++)
                        {
                            sum.Add(nums[i, j]);
                        }
                    }
                });
            }
            foreach (var item in tasks)
            {
                item.Start();
            }
            Task.WaitAll(tasks);
            return sum.Sum();
        }
    }
}
