using projekt;
using System.Text.Json;

public interface IStudentManagement
{
    /*Lớp IStudentManagement là một giao diện quy định các chức năng quản lý sinh viên mà mọi lớp triển khai nó phải có, bao gồm:

Thêm, xóa, sửa thông tin sinh viên.
Hiển thị danh sách sinh viên.
Tìm kiếm sinh viên theo tiêu chí cụ thể.
Sắp xếp danh sách sinh viên theo tên, GPA, và ĐRL.*/

    void AddStudent(Student student);
    void RemoveStudent(string studentID);
    void EditStudent(string studentID, Student updatedStudent);
    void DisplayStudentList();
    List<Student> FindEntitiesByProperty<T>(string propertyName, T value);
    void SortStudentsByName();
    void SortStudentsByDRL();
    void SortStudentsByGPA();
}
