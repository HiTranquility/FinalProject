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
            string filePath = System.IO.Path.Combine(RelativePath.projectRoot, "TextFiles", "Staff.txt");
            var staffList = ReadStaffFromFile(filePath);
            foreach (var staff in staffList)
            {
                AddPerson(staff);
            }
        }

        public void WriteToFile()
        {
            try
            {
                // Construct the file path
                string filePath = System.IO.Path.Combine(RelativePath.projectRoot, "TextFiles", "Staff.txt");

                // Check if there are any staff members in the list
                var staffList = GetPersonList();
                if (staffList == null || staffList.Count == 0)
                {
                    Console.WriteLine("No staff data to write to the file.");
                    return;
                }

                // Format the data into a string
                var content = string.Join("\n", staffList.Select(staff =>
                    $"{staff.Id}:{staff.Role}:{staff.Name}:{staff.Age}:{staff.Gender}:" +
                    $"{staff.DateOfBirth:MM/dd/yyyy}:{staff.Address}:{staff.PhoneNumber}:" +
                    $"{staff.Email}:{staff.Username}:{staff.Password}"));

                // Write the data to the file
                System.IO.File.WriteAllText(filePath, content);
                Console.WriteLine("Staff data successfully written to the file.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied. Ensure you have write permissions for the target file.");
            }
            catch (System.IO.IOException ex)
            {
                Console.WriteLine($"I/O error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while writing to the file: {ex.Message}");
            }
        }


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
