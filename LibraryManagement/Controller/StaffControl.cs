using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagement.Model;
using LibraryManagement.Util;

namespace LibraryManagement.Controller
{
    internal class StaffControl : PersonControl<Staff>
    {
        // Constructor
        public StaffControl() : base()
        {
            var staffList = ReadStaffFromFile("C:\\Users\\Admin\\Downloads\\OOP\\FinalProject\\LibraryManagement\\Staff.txt");
            foreach (var staff in staffList)
            {
                AddPerson(staff);
            }
        }

        // Thêm nhân viên (sử dụng lại từ PersonControl)
        public void AddStaff(Staff staff)
        {
            AddPerson(staff);
        }

        // Xóa nhân viên theo ID
        public void RemoveStaff(string staffId)
        {
            RemovePerson(s => s.Id == staffId);
        }

        // Sửa thông tin nhân viên
        public void UpdateStaff(string staffId, string newRole)
        {
            UpdatePerson(s => s.Id == staffId, s => s.Role = newRole);
        }

        // Hiển thị thông tin tất cả nhân viên
        public void DisplayAllStaff()
        {
            DisplayAllPersons(staff => Console.WriteLine(staff.ToString()));
        }

        // Tìm kiếm nhân viên theo ID
        public void SearchStaffById(string staffId)
        {
            var staff = SearchPerson(s => s.Id == staffId);
            if (staff != null)
            {
                Console.WriteLine(staff.ToString());
            }
        }

        // Lấy nhân viên theo ID
        public Staff GetStaffById(string staffId)
        {
            return SearchPerson(s => s.Id == staffId);
        }

        // Lấy ID nhân viên theo username
        public string GetIdByUsername(string username)
        {
            var staff = SearchPerson(s => s.Username == username);
            return staff?.Id;
        }

        // Lấy nhân viên theo username và password
        public Staff GetStaffByUsernameAndPassword(string username, string password)
        {
            return SearchPerson(s => s.Username == username && s.Password == password);
        }

        // Ghi danh sách nhân viên vào file
        public void WriteToFile()
        {
            WriteToFile("Staff.txt", staff =>
                $"{staff.Id},{staff.Role},{staff.Name},{staff.Age},{staff.Gender}," +
                $"{staff.DateOfBirth:MM/dd/yyyy},{staff.Address},{staff.PhoneNumber}," +
                $"{staff.Email},{staff.Username},{staff.Password}");
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
