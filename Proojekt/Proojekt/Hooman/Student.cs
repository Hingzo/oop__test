using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    public class Student: Human
    {
        public string Major { get; set; }
        public double GPA { get; set; }
        public string SchoolYear { get; set; }

        public string ClassID { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Phone: {PhoneNumber}");
            Console.WriteLine($"Major: {Major}");
            Console.WriteLine($"GPA: {GPA}");
        }
    }
}
