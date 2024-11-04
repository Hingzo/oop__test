using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace projekt
{
    public class CollegeSystem<T>
    {   
        /// <summary>
        /// Một Class với vai trò thao tác và chuyển đổi linh hoạt trên các Database. Đây sẽ là file hiển thị các chức năng chính trên 
        /// FrontEnd
        /// 
        /// </summary>

        // Database
        private static string basePath = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;


        //Sub Systems

        //Departments 
        protected string Department_database = Path.Combine(basePath, "database", "Department.json");
        private Manager<Department> _departmentStorage = new Manager<Department>("Department.json");

        //Courses interface
        protected string Course_database = Path.Combine(basePath, "database", "course.json");
        private Manager<Course> _courseStorage = new Manager<Course>("courses.json");

        //Classes
        protected string MajorClass_database = Path.Combine(basePath, "database", "classroom.json");
        private Manager<MajorClass> _classStorage = new Manager<MajorClass>("majorclass.json");


        //Department logic
        public void AddDepartment(Department department)
        {
            _departmentStorage.Add(department);
        }
        public void RemoveDepartment(Department department)
        {
            _departmentStorage.Remove(department);
        }
        public Department SearchDepartment(string name)
        {
            foreach(Department department in _departmentStorage.GetAll())
            {
                if (department.DepartmentName == name) { return department;};
            }
            return null;
        }


        //Course logic
        public void AddCourse(Course course)
        {
            _courseStorage.Add(course);
        }
        public void RemoveCourse(Course course)
        {
            _courseStorage.Remove(course);
        }
        public Course SearchCourse(string code)
        {
            foreach (Course course in _courseStorage.GetAll())
            {
                if (course.CourseCode == code) { return course; };
            }
            return null;
        }


        //Class logic
        public void AddClass(MajorClass Class)
        {
            _classStorage.Add(Class);
        }
        public void RemoveClass(MajorClass Class)
        {
            _classStorage.Remove(Class);
        }


    }
}
