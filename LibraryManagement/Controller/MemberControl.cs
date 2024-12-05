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
            var memberList = ReadMemberFromFile("C:\\Users\\Admin\\Downloads\\OOP\\FinalProject\\LibraryManagement\\TextFiles\\Member.txt");
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
                            BookLink = data[12]
                        };
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
