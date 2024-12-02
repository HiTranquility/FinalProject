using System;
using System.Collections.Generic;
using LibraryManagement.Model;

namespace LibraryManagement.Controller
{
    internal class MemberControl : PersonControl<Member>
    {
        // Constructor
        public MemberControl() : base() { }

        // Thêm thành viên
        public void AddMember(Member member)
        {
            AddPerson(member);
        }

        // Xóa thành viên theo ID
        public void RemoveMemberById(string memberId)
        {
            RemovePersonById(memberId);
        }

        // Cập nhật thông tin thành viên
        public void UpdateMemberById(string memberId)
        {
            UpdatePersonById(memberId);
        }

        // Hiển thị tất cả thành viên
        public void DisplayAllMembers()
        {
            DisplayAllPersons();
        }
        public void DisplayMemberDetails(string id)
        {
            DisplayPersonDetails(id);
        }

        // Tìm kiếm thành viên theo ID
        public Member GetMemberById(string memberId)
        {
            return GetPersonById(memberId);
        }

        // Lấy danh sách thành viên
        public List<Member> GetMemberList()
        {
            return GetPersonList();
        }

        // Lấy thành viên theo username và password
        public Member GetMemberByUsernameAndPassword(string username, string password)
        {
            return GetPersonList().Find(m => m.Username == username && m.Password == password);
        }

        // Lấy ID thành viên theo username
        public string GetIdByUsername(string username)
        {
            var staff = GetPersonList().Find(s => s.Username == username);
            return staff?.Username;
        }

        // Ghi danh sách thành viên vào file
        public void WriteToFile(string filePath)
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
        public void ReadMembersFromFile(string filePath)
        {
            try
            {
                var lines = System.IO.File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var data = line.Split(':');
                        var member = new Member
                        {
                            Id = data[0],
                            Name = data[1],
                            Address = data[2],
                            PhoneNumber = data[3],
                            Email = data[4],
                            Username = data[5],
                            Password = data[6]
                        };
                        AddPerson(member);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading member data from file: {ex.Message}");
            }
        }
    }
}
