using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace projekt
{
    public static class Init
    {

        public static List<Student> students = new List<Student>();
        public static List<Lecturer> lecturers = new List<Lecturer>();
        public static List<Department> departments = new List<Department>();
        public static List<Course> courses = new List<Course>();
        public static List<MajorClass> classes = new List<MajorClass>();

        public static Random rnd = new Random();
        public static void Read()
        {

            string rootPath = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

            string studentdb = Path.Combine(rootPath, "database", "Student.json");
            string lecturerdb = Path.Combine(rootPath, "database", "Lecturer.json");
            string departmentdb = Path.Combine(rootPath, "database", "Department.json");
            string coursedb = Path.Combine(rootPath, "database", "Course.json");
            string classdb = Path.Combine(rootPath, "database", "MajorClass.json");

            //Student
            string jsonStudent = File.ReadAllText(studentdb);
            using (JsonDocument doc = JsonDocument.Parse(jsonStudent))
            {
                JsonElement root = doc.RootElement;
                foreach (JsonElement element in root.EnumerateArray())
                {
                    Student student = new Student
                    {
                        ID = element.GetProperty("id").GetString(),
                        Name = element.GetProperty("name").GetString(),
                        Email = element.GetProperty("email").GetString(),
                        Gender = element.GetProperty("gender").GetString(),
                        Bday = element.GetProperty("birthday").GetString(),
                        PhoneNumber = element.GetProperty("PhoneNumber").GetString(),
                        SchoolYear = element.GetProperty("SchoolYear").GetString(),
                        GPA = Math.Round(Convert.ToDouble(element.GetProperty("GPA").GetString()), 2),
                        Major = element.GetProperty("major").GetString(),
                        ClassID = element.GetProperty("ClassID").GetString()

                    };
                    students.Add(student);
                }
            }


            //Lecturer
            string jsonLecturer = File.ReadAllText(lecturerdb);
            using (JsonDocument doc = JsonDocument.Parse(jsonLecturer))
            {
                JsonElement root = doc.RootElement;
                foreach (JsonElement element in root.EnumerateArray())
                {
                    // Create new Student and populate fields from JSON
                    Lecturer lecturer = new Lecturer
                    {
                        ID = element.GetProperty("ID").GetString(),
                        Name = element.GetProperty("Name").GetString(),
                        Email = element.GetProperty("Email").GetString(),
                        Gender = element.GetProperty("Gender").GetString(),
                        PhoneNumber = element.GetProperty("PhoneNumber").GetString(),
                        Bday = element.GetProperty("Bday").GetString(),
                        Department = element.GetProperty("Department").GetString(),
                        Education = element.GetProperty("Education").GetString()
                    };
                    lecturers.Add(lecturer);
                }
            }


            //Class
            string jsonClass = File.ReadAllText(classdb);
            using (JsonDocument doc = JsonDocument.Parse(jsonClass))
            {
                JsonElement root = doc.RootElement;
                foreach (JsonElement element in root.EnumerateArray())
                {
                    MajorClass clas = new MajorClass
                    {
                        DepartmentID = element.GetProperty("DepartmentID").GetInt16(),
                        DepartmentName = element.GetProperty("DepartmentName").GetString(),
                        ID = element.GetProperty("ID").GetString(),
                        students = new List<Student>()
                    };

                    foreach (Student student in students)
                    {
                        if (student.ClassID == clas.ID) { clas.students.Add(student); }
                    }
                    classes.Add(clas);
                }
            }


            //Courses
            string jsonCourse = File.ReadAllText(coursedb);
            using (JsonDocument doc = JsonDocument.Parse(jsonCourse))
            {
                JsonElement root = doc.RootElement;
                int i = 0; 
                foreach(JsonElement element in root.EnumerateArray())
                {
                    Course course = new Course
                    {
                        DepartmentID = element.GetProperty("DepartmentID").GetInt16(),
                        DepartmentName = element.GetProperty("DepartmentName").GetString(),
                        CourseCode = element.GetProperty("CourseCode").GetString(),
                        CourseName = element.GetProperty("CourseName").GetString(),
                        Lecturer = lecturers[i],
                        Start = element.GetProperty("Start").GetDateTime(),
                        End = element.GetProperty("End").GetDateTime()
                    };
                    courses.Add(course); i++;
                }
            }


            //Department
            string jsonDepartment = File.ReadAllText(departmentdb);
            using (JsonDocument doc = JsonDocument.Parse(jsonDepartment))
            {
                JsonElement root = doc.RootElement;
                foreach (JsonElement element in root.EnumerateArray())
                {
                    Department department = new Department
                    {
                        DepartmentID = element.GetProperty("DepartmentID").GetInt16(),
                        DepartmentName = element.GetProperty("DepartmentName").GetString(),
                        MajorClasses = new List<MajorClass>(),
                        CourseOffered = new List<Course>(),
                        Lecturers = new List<Lecturer>()
                    };
                    //Add classes
                    foreach (MajorClass clas in classes)
                    {
                        if (clas.DepartmentID == department.DepartmentID) { department.MajorClasses.Add(clas); }
                    }
                    //Add Lecturer
                    foreach (Lecturer lec in lecturers)
                    {
                        if (lec.Department == department.DepartmentName) { department.Lecturers.Add(lec); }
                    }
                    //Add Course
                    foreach (Course course in courses)
                    {
                        if (course.DepartmentID == department.DepartmentID) { department.CourseOffered.Add(course); }
                    }

                    departments.Add(department);
                }
            }
        }
    }
}
