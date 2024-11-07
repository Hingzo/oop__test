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
        public static List<Class> classes = new List<Class>();
        public static Random rnd = new Random();

        public static void Read()
        {

            string rootPath = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

            string studentdb = Path.Combine(rootPath, "database", "Student.json");
            string lecturerdb = Path.Combine(rootPath, "database", "Lecturer.json");
            string departmentdb = Path.Combine(rootPath, "database", "Department.json");
            string coursedb = Path.Combine(rootPath, "database", "Course.json");
            string classdb = Path.Combine(rootPath, "database", "Class.json");

            //Student
            string jsonStudent = File.ReadAllText(studentdb);
            using (JsonDocument doc = JsonDocument.Parse(jsonStudent))
            {
                JsonElement root = doc.RootElement;
                foreach (JsonElement element in root.EnumerateArray())
                {
                    Student student = new Student
                    {
                        Id = element.GetProperty("Id").GetString(),
                        Name = element.GetProperty("Name").GetString(),
                        Email = element.GetProperty("Email").GetString(),
                        Gender = element.GetProperty("Gender").GetString(),
                        Bday = element.GetProperty("Birthday").GetString(),
                        PhoneNumber = element.GetProperty("PhoneNumber").GetString(),
                        SchoolYear = element.GetProperty("SchoolYear").GetString(),
                        GPA = Math.Round(Convert.ToDouble(element.GetProperty("GPA").GetString()), 2),
                        ĐRL = Convert.ToDouble(element.GetProperty("TrainingPoint").GetString()),
                        ClassID = element.GetProperty("ClassID").GetString(),
                        DepartmentID = element.GetProperty("DepartmentID").GetString(),
                    };
                    foreach(JsonElement course in element.GetProperty("CourseID").EnumerateArray())
                    {
                        student.CourseIDs.Add(course.GetString());
                    }
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
                        Id = element.GetProperty("ID").GetString(),
                        Name = element.GetProperty("Name").GetString(),
                        Email = element.GetProperty("Email").GetString(),
                        Gender = element.GetProperty("Gender").GetString(),
                        PhoneNumber = element.GetProperty("PhoneNumber").GetString(),
                        Bday = element.GetProperty("Birthday").GetString(),
                        DepartmentID = element.GetProperty("DepartmentID").GetString(),
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
                    Class clas = new Class
                    {
                        DepartmentID = element.GetProperty("DepartmentID").GetString(),
                        ID = element.GetProperty("ClassID").GetString(),
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
                    Course course = new Course(departmentID: element.GetProperty("DepartmentID").ToString())
                    {
                        Id = element.GetProperty("CourseCode").GetString(),
                        Name = element.GetProperty("CourseNotation").GetString(),
                        Start = element.GetProperty("Start").GetDateTime(),
                        End = element.GetProperty("End").GetDateTime(),
                        EnrolledStudent = new List<Student>()
                    };

                    //Assign Lecturer
                    foreach (Lecturer lec in lecturers)
                    {
                        if (lec.Id == element.GetProperty("LecturerID").ToString()) { course.Lecturer = lec; }
                    }

                    //Add Student
                    int j = rnd.Next(0, 19);
                    for(int cnt = 0; cnt < 30; cnt++) { course.EnrolledStudent.Add(students[j + cnt]); }
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
                    Department department = new Department(departmentID: element.GetProperty("DepartmentID").GetString(),
                        departmentNotation: element.GetProperty("Notation").GetString())
                    {
                        Classes = new List<Class>(),
                        Lecturers = new List<Lecturer>()
                    };
                    //Add classes
                    foreach (Class clas in classes)
                    {
                        if (clas.DepartmentID == department.DepartmentID) { department.Classes.Add(clas); }
                    }
                    //Add Lecturer
                    foreach (Lecturer lec in lecturers)
                    {
                        if (lec.DepartmentID == department.DepartmentID) { department.Lecturers.Add(lec); }
                    }


                    departments.Add(department);
                }
            }
        }
    }
}