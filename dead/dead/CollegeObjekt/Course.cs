using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace projekt
{
    [Serializable]
    public class Course : BaseEntity
    {
        /// <summary>
        /// Một Khóa Học, hay Học Phần
        /// Trong một Khóa Học sẽ có nhiều Sinh Viên tham dự cùng với đó là 1 giảng viên đứng lớp
        /// </summary>

        //BaseEntity
        public string Id { get; set; }
        public string Name { get; set; }

        //Other
        public string DepartmentID { get; set; }
        public Lecturer Lecturer { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<Student> EnrolledStudent {get; set; }
        public Course(string departmentID) { this.DepartmentID = departmentID; }
    }
}

