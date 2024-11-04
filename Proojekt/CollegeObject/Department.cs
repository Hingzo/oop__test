using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace projekt
{
    public class Department
    {
        /// <summary>
        /// Khoa, vd Khoa BIT, Ngân hàng,...
        /// Trong một Khoa sẽ có nhiều giảng viên cùng tham gia giảng dạy
        /// có nhiều Lớp Học trục thuộc và các Học Phần tương ứng
        /// </summary>
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public List<Course> CourseOffered { get; set; }
        public List<Lecturer> Lecturers { get; set; }
        public List<MajorClass> MajorClasses { get; set; }
    }

}
