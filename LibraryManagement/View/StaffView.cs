using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Model;

namespace LibraryManagement.View
{
    internal class StaffView
    {
        // Hiển thị tất cả nhân viên
        public void DisplayAllStaff(List<Staff> staffList)
        {
            Console.WriteLine("---- List of Staff ----");
            foreach (var staff in staffList)
            {
                Console.WriteLine(staff.ToString());
            }
            Console.WriteLine("Press any key to continue to exit!...");
            Console.ReadKey();  // Dừng lại cho đến khi người dùng nhấn một phím
        }

        // Hiển thị thông tin nhân viên
        public void DisplayStaffDetails(Staff staff)
        {
            if (staff != null)
            {
                Console.WriteLine("---- Staff Details ----");
                Console.WriteLine(staff.ToString());
            }
            else
            {
                Console.WriteLine("Staff not found.");
            }
        }

        // Hiển thị thông báo thành công
        public void DisplaySuccessMessage(string message)
        {
            Console.WriteLine(message);
        }

        // Hiển thị thông báo lỗi
        public void DisplayErrorMessage(string message)
        {
            Console.WriteLine("Error: " + message);
        }

        // Nhận thông tin đầu vào để thêm nhân viên
        public Staff GetNewStaffInput()
        {
            Console.WriteLine("Enter Staff Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Staff Age:");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Staff Gender:");
            string gender = Console.ReadLine();

            Console.WriteLine("Enter Staff ID:");
            string id = Console.ReadLine();

            Console.WriteLine("Enter Staff Role:");
            string role = Console.ReadLine();

            return new Staff { Name = name, Age = age, Gender = gender, Id = id, Role = role };
        }

        // Nhận thông tin đầu vào để cập nhật nhân viên
        public void GetUpdateStaffInput(out string staffId, out string newRole)
        {
            Console.WriteLine("Enter Staff ID to update:");
            staffId = Console.ReadLine();

            Console.WriteLine("Enter New Role:");
            newRole = Console.ReadLine();
        }

        // Nhận thông tin đầu vào để xóa nhân viên
        public string GetStaffIdForRemoval()
        {
            Console.WriteLine("Enter Staff ID to remove:");
            return Console.ReadLine();
        }
    }
}
