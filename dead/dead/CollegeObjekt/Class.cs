using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace projekt
{
    [Serializable]
    public class Class : BaseEntity
    {
        /// <summary>
        /// Đại diện cho một Lớp Học, gồm nhiều Học Sinh.
        /// 
        /// </summary>

        public string DepartmentID { get; set; }
        public string ID { get; set; }
        public List<Student> students = new List<Student>();
    }
}
