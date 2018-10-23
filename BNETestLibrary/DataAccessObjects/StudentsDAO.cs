using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BNETestLibrary.Models;

namespace BNETestLibrary.DataAccessObjects
{
    public class StudentsDAO : IDisposable, IStudentDAO
    {
        BNETestContext context;

        public StudentsDAO()
        {
            context = new BNETestContext();
        }

        public void Add(Student s)
        {
            context.Students.Add(s);
            context.SaveChanges();
        }

        public void Delete(Student s)
        {
            if (context.Entry(s).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                context.Students.Attach(s);
                context.Students.Remove(s);
            }
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Student Get(int i)
        {
            return context.Students.Find(i);
        }

        public IList<Student> GetAll()
        {
            return context.Students.ToArray();
        }

        public void Update(Student s)
        {
            context.Students.Update(s);
            context.SaveChanges();
        }
    }
}
