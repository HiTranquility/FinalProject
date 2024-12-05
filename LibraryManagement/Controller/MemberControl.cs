using System;
using System.Collections.Generic;
using LibraryManagement.Model;
using LibraryManagement.Util;

namespace LibraryManagement.Controller
{
    internal class MemberControl : PersonControl<Member>
    {
        // Constructor
        public MemberControl() : base() 
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = System.IO.Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
            string filePath = System.IO.Path.Combine(projectRoot, "TextFiles", "Member.txt");

            // Read the staff list from the relative file path
            var memberList = ReadMemberFromFile(filePath);
            foreach (var member in memberList)
            {
                AddPerson(member);
            }
        }
        public override void WriteToFile(string filePath)
        {
            try
            {
                var content = string.Join("\n", GetPersonList().Select(member =>
                    $"{member.Id},{member.Name},{member.Address},{member.PhoneNumber}," +
                    $"{member.Email},{member.Username},{member.Password}"));
                System.IO.File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing member data to file: {ex.Message}");
            }
        }
        // Đọc danh sách thành viên từ file
        public List<Member> ReadMemberFromFile(string filePath)
        {
            var memberList = new List<Member>();
            try
            {
                string[] lines = Read_WriteFile.Instance.ReadFile(filePath).Split('\n');
                foreach (var line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var data = line.Split(':');
                        var member = new Member
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
                            Password = data[10],
                            MembershipStartDate = DateTime.Parse(data[11]),
                            BookLink = data[12].Trim()
                        };
                        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                        // Navigate up two levels to the project root
                        string projectRoot = System.IO.Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
                        // Construct the file path outside bin/Debug
                        string bookPath = System.IO.Path.Combine(projectRoot, "BookFiles", member.BookLink);

                        var borrowedBooks = member.ReadBorrowedBooksFromFile(bookPath);
                        member.BorrowedBooks = borrowedBooks;
                        AddPerson(member);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading member data from file: {ex.Message}");
            }
            return memberList;
        }
    }
}
