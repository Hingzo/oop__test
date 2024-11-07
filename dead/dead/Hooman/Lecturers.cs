using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Reflection.Metadata.Ecma335;
using System.Reflection;
using System.Xml.Linq;

namespace projekt
{
    [Serializable]
    // Lớp Lecturer (Giảng viên)
    public class Lecturer : IENTITY
    {
        //IENTITY attributes
        public string Id { get; set; } 
        public string Name { get; set; } 
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Bday { get; set; }
        public string Gender { get; set; }
        public string DepartmentID { get; set; }

        //Other attrs
        public string Education { get; set; }

        public Dictionary<string, string> DisplayInfo()
        {
            return new Dictionary<string, string>
            {
                ["Id"] = Id,
                ["Name"] = Name,
                ["Email"] = Email,
                ["PhoneNumber"] = PhoneNumber,
                ["Bday"] = Bday,
                ["Gender"] = Gender,
                ["DepartmentID"] = DepartmentID
            };
        }
    }
}

