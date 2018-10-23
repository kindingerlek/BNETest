using BNETestLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BNETestLibrary.DataAccessObjects
{
    interface IStudentDAO
    {
        IList<Student> GetAll();
        Student Get(int i);
        void Add(Student s);
        void Update(Student s);
        void Delete(Student s);
    }
}
