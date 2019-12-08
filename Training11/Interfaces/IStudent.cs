using System;
using System.Collections.Generic;
using System.Text;
using Training11.Entities;

namespace Training11.Interfaces
{
    public interface IStudent
    {
        void Join(Student student);
        void Leave(Student student);
    }
}
