﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BNETestLibrary.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> RegistredStudents { get; set; }
    }
}