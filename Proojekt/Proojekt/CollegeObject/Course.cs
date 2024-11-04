using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    public class Course : Department
    {
        /// <summary>
        /// Một Khóa Học, hay Học Phần
        /// Trong một Khóa Học sẽ có nhiều Sinh Viên tham dự cùng với đó là 1 giảng viên đứng lớp
        /// </summary>
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public Lecturer Lecturer { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Course(int departmentID, string departmentName)
        : base(departmentID, departmentName) { }

    }
}