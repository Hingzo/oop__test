using System;
using System.Collections.Generic;

namespace projekt
{
    public class Student : Human
    {
        public string Major { get; set; }
        public int Year { get; set; }
        public double GPA { get; set; }
        public string SchoolYear { get; set; }
        public string ClassName { get; set; } // Bổ sung ClassName

        public List<string> classID = new List<string>();

        public override void DisplayInfo()
        {
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Phone: {PhoneNumber}");
            Console.WriteLine($"Major: {Major}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine($"GPA: {GPA}");
            Console.WriteLine($"ClassName: {ClassName}"); // Hiển thị ClassName
        }
    }
}
