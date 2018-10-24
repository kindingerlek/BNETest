using System;
using System.Collections.Generic;
using System.Text;

namespace BNETestLibrary.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
