﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    public class MajorClass: Department
    {
        public string ID { get; set; }
        public List<Student> students = new List<Student>();
    }
}