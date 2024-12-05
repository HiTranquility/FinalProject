using System;
using System.Collections.Generic;
using LibraryManagement.Model;
using LibraryManagement.Util;

namespace LibraryManagement.Controller
{
    internal class LibrarianControl : PersonControl<Librarian>
    {
        public LibrarianControl() : base()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = System.IO.Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
            string filePath = System.IO.Path.Combine(projectRoot, "TextFiles", "Librarian.txt");

            var librarianList = ReadLibrarianFromFile(filePath);
            foreach (var librarian in librarianList)
            {
                AddPerson(librarian);
            }
        }
        public override void WriteToFile(string filePath)
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

        public List<Librarian> ReadLibrarianFromFile(string filePath)
        {
            var librarianList = new List<Librarian>();
            try
            {
                string[] lines = Read_WriteFile.Instance.ReadFile(filePath).Split('\n');
                foreach (var line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var data = line.Split(':');
                        var librarian = new Librarian
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
                        librarianList.Add(librarian);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading staff data from file: {ex.Message}");
            }

            return librarianList;
        } 

    }
}
