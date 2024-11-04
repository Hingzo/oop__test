using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    public class Lecturer: Human
    {
        public string Department { get; set; }
        public string Education { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Phone: {PhoneNumber}");
            Console.WriteLine($"Department: {Department}");
        }
    }
}
