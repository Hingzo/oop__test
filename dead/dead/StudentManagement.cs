using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;

namespace projekt
{
    // Delegate và sự kiện cho việc thêm, xóa sinh viên
    public delegate void StudentEventHandler(object sender, StudentEventArgs e);

    public class StudentEventArgs : EventArgs
    {
        public Student Student { get; private set; }
        public StudentEventArgs(Student student)
        {
            Student = student;
        }
    }

    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException(string message) : base(message) { }
    }

    // Lớp StudentManagementSystem (Quản lý sinh viên)
    public class StudentManagementSystem : IStudentManagement
    {
        private Dictionary<string, Student> studentDictionary = new Dictionary<string, Student>();

        // Sự kiện cho việc thêm và xóa sinh viên
        public event StudentEventHandler StudentAdded;
        public event StudentEventHandler StudentRemoved;

        // Thêm sinh viên
        public void AddStudent(Student student)
        {
            studentDictionary[student.Id] = student;
            Console.WriteLine("Thêm sinh viên thành công.");

            // Kích hoạt sự kiện khi thêm sinh viên
            StudentAdded?.Invoke(this, new StudentEventArgs(student));
        }

        // Xóa sinh viên
        public void RemoveStudent(string studentID)
        {
            Student student = FindStudentByID(studentID);
            studentDictionary.Remove(studentID);
            Console.WriteLine("Xóa sinh viên thành công.");

            // Kích hoạt sự kiện khi xóa sinh viên
            StudentRemoved?.Invoke(this, new StudentEventArgs(student));
        }

        // Sửa thông tin sinh viên
        public void EditStudent(string studentID, Student updatedStudent)
        {
            Student student = FindStudentByID(studentID);
            student.Name = updatedStudent.Name;
            student.Email = updatedStudent.Email;
            student.PhoneNumber = updatedStudent.PhoneNumber;
            student.GPA = updatedStudent.GPA;
            student.ĐRL = updatedStudent.ĐRL;
            student.Bday = updatedStudent.Bday;
            student.Gender = updatedStudent.Gender;
            student.CourseIDs = updatedStudent.CourseIDs;
            student.DepartmentID = updatedStudent.DepartmentID;
            student.ClassID = updatedStudent.ClassID;
            Console.WriteLine("Cập nhật sinh viên thành công.");
        }

        // Hiển thị danh sách sinh viên
        public void DisplayStudentList()
        {
            foreach (Student student in studentDictionary.Values)
            {
                Console.WriteLine($"ID: {student.Id}");
                Console.WriteLine($"Name: {student.Name}");
                Console.WriteLine($"Gender: {student.Gender}");
                Console.WriteLine($"Bday: {student.Bday}");
                Console.WriteLine($"ClassID: {string.Join(", ", student.ClassID)}");
                Console.WriteLine($"CourseID: {student.CourseIDs}");
                Console.WriteLine($"DepartmentID: {student.DepartmentID}");
                Console.WriteLine($"GPA: {student.GPA}");
                Console.WriteLine($"ĐRL: {student.ĐRL}");
                Console.WriteLine($"Email: {student.Email}");
                Console.WriteLine($"Phone: {student.PhoneNumber}");
                Console.WriteLine();
            }
        }

        // Tìm kiếm sinh viên theo ID
        private Student FindStudentByID(string studentID)
        {
            if (studentDictionary.ContainsKey(studentID))
            {
                return studentDictionary[studentID];
            }
            else
            {
                throw new StudentNotFoundException($"Sinh viên với ID {studentID} không tồn tại.");
            }
        }

        // Tìm sinh viên theo thuộc tính bất kỳ
        public List<Student> FindEntitiesByProperty<T>(string propertyName, T value)
        {
            List<Student> result = new List<Student>();

            foreach (Student student in studentDictionary.Values)
            {
                PropertyInfo property = typeof(Student).GetProperty(propertyName);
                if (property != null)
                {
                    var propertyValue = property.GetValue(student);
                    if (EqualityComparer<T>.Default.Equals((T)propertyValue, value))
                    {
                        result.Add(student);
                    }
                }
            }

            return result;
        }

        // Sắp xếp sinh viên theo tên
        public void SortStudentsByName()
        {
            var studentsList = new List<Student>(studentDictionary.Values);
            studentsList.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Đã sắp xếp danh sách sinh viên theo tên.");
        }

        // Sắp xếp sinh viên theo ĐRL
        public void SortStudentsByDRL()
        {
            var studentsList = new List<Student>(studentDictionary.Values);
            studentsList.Sort((x, y) => y.ĐRL.CompareTo(x.ĐRL)); // Sắp xếp giảm dần theo ĐRL
            Console.WriteLine("Đã sắp xếp danh sách sinh viên theo ĐRL.");
        }

        // Sắp xếp sinh viên theo GPA
        public void SortStudentsByGPA()
        {
            var studentsList = new List<Student>(studentDictionary.Values);
            studentsList.Sort((x, y) => y.GPA.CompareTo(x.GPA)); // Sắp xếp giảm dần theo GPA
            Console.WriteLine("Đã sắp xếp danh sách sinh viên theo GPA.");
        }
    }
}

