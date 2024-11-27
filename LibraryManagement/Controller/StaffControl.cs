using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Model;
using LibraryManagement.Util;

namespace LibraryManagement.Controller
{
    internal class StaffControl
    {
        // Danh sách nhân viên của thư viện
        private List<Staff> staffList;

        // Constructor
        public StaffControl()
        {
            staffList = ReadStaffFromFile("C:\\Users\\Admin\\Downloads\\OOP\\FinalProject\\LibraryManagement\\Staff.txt");
        }

        // Thêm nhân viên mới
        public void AddStaff(Staff staff)
        {
            staffList.Add(staff);
            Console.WriteLine("Staff added successfully.");
        }

        // Xóa nhân viên theo ID
        public void RemoveStaff(string staffId)
        {
            Staff staffToRemove = staffList.FirstOrDefault(s => s.Id == staffId);
            if (staffToRemove != null)
            {
                staffList.Remove(staffToRemove);
                Console.WriteLine("Staff removed successfully.");
            }
            else
            {
                Console.WriteLine("Staff not found.");
            }
        }

        // Sửa thông tin nhân viên
        public void UpdateStaff(string staffId, string newRole)
        {
            Staff staffToUpdate = staffList.FirstOrDefault(s => s.Id == staffId);
            if (staffToUpdate != null)
            {
                staffToUpdate.Role = newRole;
                Console.WriteLine("Staff role updated successfully.");
            }
            else
            {
                Console.WriteLine("Staff not found.");
            }
        }

        // Hiển thị thông tin tất cả nhân viên
        public void DisplayAllStaff()
        {
            foreach (var staff in staffList)
            {
                Console.WriteLine(staff.ToString());
            }
            Console.WriteLine("Press any key to continue to the next member...");
            Console.ReadKey();  // Dừng lại cho đến khi người dùng nhấn một phím
        }

        // Tìm kiếm nhân viên theo ID
        public void SearchStaffById(string staffId)
        {
            Staff staff = staffList.FirstOrDefault(s => s.Id == staffId);
            if (staff != null)
            {
                Console.WriteLine(staff.ToString());
            }
            else
            {
                Console.WriteLine("Staff not found.");
            }
        }
        public Staff GetStaffById(string staffId)
        {
            return staffList.FirstOrDefault(staff => staff.Id == staffId);
        }

        public Staff GetStaffByUsernameAndPassword(string username, string password)
        {
            return staffList.FirstOrDefault(staff => staff.Username == username && staff.Password == password);
        }
        public List<Staff> GetStaffList()
        {
            return staffList;
        }
        private void WriteToFile()
        {
            string content = "";
            foreach (var staff in staffList)
            {
                content += $"{staff.Id},{staff.Role},{staff.Name},{staff.Age},{staff.Gender},{staff.DateOfBirth.ToString("MM/dd/yyyy")},{staff.Address},{staff.PhoneNumber},{staff.Email},{staff.Username},{staff.Password}\n";
            }
            Read_WriteFile.Instance.WriteFile("Staff.txt", content);
        }

        // Đọc danh sách nhân viên từ file
        public List<Staff> ReadStaffFromFile(string filePath)
        {
            var staffList = new List<Staff>();

            try
            {
                string[] lines = Read_WriteFile.Instance.ReadFile(filePath).Split('\n');
                foreach (var line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var data = line.Split(':');
                        var staff = new Staff
                        {
                            Id = data[0],
                            Role = data[1],
                            Name = data[2],
                            Age = int.Parse(data[3]),
                            Gender = data[4],
                            DateOfBirth = DateTime.Parse(data[5]),
                            Address = data[6],
                            PhoneNumber = data[7],
                            Email = data[8],
                            Username = data[9],
                            Password = data[10].Trim()
                        };
                        staffList.Add(staff);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading staff data from file: {ex.Message}");
            }

            return staffList;
        }
    }
}