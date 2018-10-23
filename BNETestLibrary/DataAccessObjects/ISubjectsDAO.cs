using BNETestLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BNETestLibrary.DataAccessObjects
{
    interface ISubjectsDAO
    {
        IList<Subject> GetAll();
        Subject Get(int i);
        void Add(Subject s);
        void Update(Subject s);
        void Delete(Subject s);
    }
}
