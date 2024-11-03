using System;
using System.Collections.Generic;
using System.IO;

namespace projekt
{
    public class CollegeSystem<T>
    {
        private static string basePath = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

        protected string Department_database = Path.Combine(basePath, "database", "department.json");
        private Manager<Department> _departmentStorage = new Manager<Department>("departments.json");

        protected string Course_database = Path.Combine(basePath, "database", "course.json");
        private Manager<Course> _courseStorage = new Manager<Course>("courses.json");

        protected string MajorClass_database = Path.Combine(basePath, "database", "classroom.json");
        private Manager<MajorClass> _classStorage = new Manager<MajorClass>("majorclass.json");

        // Department logic
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
            List<Department> departments = _departmentStorage.GetAll();
            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].DepartmentName == name)
                {
                    return departments[i];
                }
            }
            return null;
        }

        // Course logic
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
            List<Course> courses = _courseStorage.GetAll();
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].CourseCode == code)
                {
                    return courses[i];
                }
            }
            return null;
        }

        // Class logic
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
