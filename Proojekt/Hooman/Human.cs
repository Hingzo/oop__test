﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    public abstract class Human
    {
        //Hoomaaan :Đ
        public string ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Bday { get; set; }
        public Boolean Gender { get; set; } 
        public string ClassID { get; set; }

        public abstract void DisplayInfo();
    }
}
