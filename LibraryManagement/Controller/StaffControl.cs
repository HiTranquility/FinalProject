using System;
using System.Collections.Generic;
using LibraryManagement.Model;
using LibraryManagement.Util;

namespace LibraryManagement.Controller
{
    internal class StaffControl : PersonControl<Staff>
    {
        // Constructor
        public StaffControl() : base()
        {
            // Đọc dữ liệu từ file và thêm vào danh sách
            var staffList = ReadStaffFromFile("C:\\Users\\Admin\\Downloads\\OOP\\FinalProject\\LibraryManagement\\Staff.txt");
            foreach (var staff in staffList)
            {
                AddPerson(staff);
            }
        }

        // Thêm nhân viên
        public void AddStaff(Staff staff)
        {
            AddPerson(staff);
        }

        // Xóa nhân viên theo ID
        public void RemoveStaffById(string staffId)
        {
            RemovePersonById(staffId);
        }

        // Sửa thông tin nhân viên
        public void UpdateStaffById(string staffId)
        {
            UpdatePersonById(staffId);
        }

        // Hiển thị thông tin tất cả nhân viên
        public void DisplayAllStaff()
        {
            DisplayAllPersons();
        }
        public void DisplayStaffDetails(string id)
        {
            DisplayPersonDetails(id);
        }
        public List<Staff> GetStaffList()
        {
            return GetPersonList();
        }
        // Tìm kiếm nhân viên theo ID
        public Staff GetStaffById(string staffId)
        {
            return GetPersonById(staffId);
        }

        public string GetIdByUsername(string username)
        {
            var staff = GetPersonList().Find(s => s.Username == username);
            return staff?.Username;
        }

        public Staff GetStaffByUsernameAndPassword(string username, string password)
        {
            return GetPersonList().Find(s => s.Username == username && s.Password == password);
        }

        public void WriteToFile(string filePath)
        {
            try
            {
                var content = string.Join("\n", GetPersonList().Select(staff =>
                    $"{staff.Id},{staff.Role},{staff.Name},{staff.Age},{staff.Gender}," +
                    $"{staff.DateOfBirth:MM/dd/yyyy},{staff.Address},{staff.PhoneNumber}," +
                    $"{staff.Email},{staff.Username},{staff.Password}"));
                System.IO.File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing staff data to file: {ex.Message}");
            }
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
