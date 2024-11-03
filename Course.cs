using System;
using System.Collections.Generic;

namespace projekt
{
    public class Course : Department
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public Lecturer Lecturer { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public List<Student> EnrolledStudents = new List<Student>();

        // Thêm sinh viên
        public void AddStudent(Student student)
        {
            bool exists = false;
            for (int i = 0; i < EnrolledStudents.Count; i++)
            {
                if (EnrolledStudents[i].ID == student.ID)
                {
                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                EnrolledStudents.Add(student);
            }
        }

        // Xóa sinh viên theo ID
        public void RemoveStudent(string studentId)
        {
            Student studentToRemove = null;
            for (int i = 0; i < EnrolledStudents.Count; i++)
            {
                if (EnrolledStudents[i].ID == studentId)
                {
                    studentToRemove = EnrolledStudents[i];
                    break;
                }
            }

            if (studentToRemove != null)
            {
                EnrolledStudents.Remove(studentToRemove);
            }
        }

        // Cập nhật thông tin sinh viên
        public void UpdateStudent(Student updatedStudent)
        {
            for (int i = 0; i < EnrolledStudents.Count; i++)
            {
                if (EnrolledStudents[i].ID == updatedStudent.ID)
                {
                    EnrolledStudents[i].Name = updatedStudent.Name;
                    EnrolledStudents[i].ClassID = updatedStudent.ClassID;
                    EnrolledStudents[i].ClassName = updatedStudent.ClassName;
                    break;
                }
            }
        }

        // Lấy danh sách sinh viên
        public List<Student> GetAllStudents()
        {
            return EnrolledStudents;
        }
    }
}
