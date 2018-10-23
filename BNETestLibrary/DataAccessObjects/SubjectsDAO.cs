using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BNETestLibrary.Models;

namespace BNETestLibrary.DataAccessObjects
{
    public class SubjectsDAO : IDisposable, ISubjectsDAO
    {
        BNETestContext context;

        public SubjectsDAO()
        {
            context = new BNETestContext();
        }

        public void Add(Subject s)
        {
            context.Subjects.Add(s);
            context.SaveChanges();
        }

        public void Delete(Subject s)
        {
            if (context.Entry(s).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                context.Subjects.Attach(s);
                context.Subjects.Remove(s);
            }
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Subject Get(int i)
        {
            return context.Subjects.Find(i);
        }

        public IList<Subject> GetAll()
        {
            return context.Subjects.ToArray();
        }
        
        public void Update(Subject s)
        {
            context.Subjects.Update(s);
            context.SaveChanges();
        }

    }

}
