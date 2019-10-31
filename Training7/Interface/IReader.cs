using System;
using System.Collections.Generic;
using System.Text;

namespace Training7.Interface
{
    public interface IReader
    {
        ICollection<double> GetDataTableFromExcel(int column1, int column2);
        void SaveIntoFile();
    }
}
