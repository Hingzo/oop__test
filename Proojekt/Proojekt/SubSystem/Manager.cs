using projekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace projekt
{
    /// <summary>
    /// Irepository, theo định nghĩa của một class Interface, thiết kế; tạo một blueprint (sơ đồ??), định nghĩa các phương thức bắt buộc
    /// phải có của một class, hiểu tương tự như abstract nhưng chỉ giới hạn ở việc tạo ra các Hàm.
    /// 
    /// Ở đây với hệ thống hoạt động với 4 chức năng chính thêm, sửa, xóa, tìm kiếm áp dụng theo 3 mục Khóa, Học phần, và Lớp. 
    /// Điều này đồng nghĩa với việc ta sẽ phải tạo ra 1 hệ thống có khả năng thực thi những tác vụ cơ bản này trên cả 3 database trong
    /// folder database-liên hệ với các class trong collegeobject, xem qua cấu trúc của từng class để hiểu rõ hơn :>
    /// 
    /// Hệ thống với đặc tính như vậy có thể được tạo ra nhờ kết hợp class interface và design pattern Facade.
    /// Về design pattern, có thể hiểu đơn giản là ta sẽ tạo ra một class, hoạt động như một giao diện kết nối người dùng và BackEnd, 
    /// Class này sẽ quy định các logic được thực thi bên trong các câu lệnh thêm, sửa, xóa, tìm kiếm, như UI/UX :Đ ?
    /// 
    /// Kết hợp với interface, ta sẽ tạo ra được một BluePrint cho một giao diện hoàn chỉnh, quy định các chức năng cơ bản một các rõ ràng,
    /// liên hệ đến class Manager. Việc còn lại là ta sẽ đặt giao diện này trong 1 biến và sử dụng như một UI/UX. easy right :Đ?
    ///
    /// Hiểu một cách đơn giản Manager class = bản phác thảo sơ bộ cho một giao diện hoạt động, điều ta cần làm là gán cho nó một phân khúc
    /// trong "Khóa, Học PHần, Lớp" và tạo ra các biến giao diện tương ứng để giao tiếp trực tiếp với database.
    /// 
    /// Đó là mục đích chính của Class Manager :Đ
    /// </summary>
    public interface IRepository<T>
    {
        void Add(T item);
        void Remove(T item);
        List<T> GetAll();
        void SaveAll(List<T> items);
    }

    public class Manager<T> : IRepository<T>
    {
        public JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
        private readonly string _filePath;  // Path to database
        public Manager(string filePath)
        {
            _filePath = filePath;
        }

        public void Add(T entity)
        {
            List<T> items = this.GetAll();
            if (!items.Contains(entity))
            {
                items.Add(entity);
                SaveAll(items);
            }
        }

        public void Remove(T item)
        {
            List<T> items = this.GetAll();
            if (items.Contains(item))
            {
                items.Remove(item); 
            }
            SaveAll(items);
        }

        public List<T> GetAll()
        {
            if (!File.Exists(_filePath)) return new List<T>();
            string jsonString = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<T>>(jsonString);
        }

        public void SaveAll(List<T> items)
        {
            string json = JsonSerializer.Serialize(items, options);
            File.WriteAllText(_filePath, json);
        }
    }
}
