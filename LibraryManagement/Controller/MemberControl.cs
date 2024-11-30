using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagement.Model;

namespace LibraryManagement.Controller
{
    internal class MemberControl : PersonControl<Member>
    {
        // Constructor
        public MemberControl() : base() { }

        // Thêm thành viên (sử dụng lại từ PersonControl)
        public void AddMember(Member member)
        {
            AddPerson(member);
        }

        // Xóa thành viên theo ID
        public void RemoveMember(string memberId)
        {
            RemovePerson(m => m.Id == memberId);
        }

        // Cập nhật thông tin thành viên
        public void UpdateMember(string memberId, string newAddress)
        {
            UpdatePerson(m => m.Id == memberId, m => m.Address = newAddress);
        }

        // Hiển thị tất cả thành viên
        public void DisplayAllMembers()
        {
            DisplayAllPersons(member =>
            {
                Console.WriteLine(member.ToString());
                Console.WriteLine("Press any key to continue to the next member...");
                Console.ReadKey();
            });
        }

        // Tìm kiếm thành viên theo ID
        public void SearchMemberById(string memberId)
        {
            var member = SearchPerson(m => m.Id == memberId);
            if (member != null)
            {
                Console.WriteLine(member.ToString());
            }
        }

        // Lấy danh sách thành viên
        public List<Member> GetMemberList()
        {
            return GetAllPersons();
        }

        // Lấy thành viên theo ID
        public Member GetMemberById(string memberId)
        {
            return SearchPerson(m => m.Id == memberId);
        }

        // Lấy thành viên theo username và password
        public Member GetMemberByUsernameAndPassword(string username, string password)
        {
            return SearchPerson(m => m.Username == username && m.Password == password);
        }

        // Lấy ID thành viên theo username
        public string GetIdByUsername(string username)
        {
            var member = SearchPerson(m => m.Username == username);
            return member?.Id;
        }

        // Ghi danh sách thành viên vào file
        public void WriteToFile(string filePath)
        {
            WriteToFile(filePath, member =>
                $"{member.Id},{member.Name},{member.Address},{member.PhoneNumber}," +
                $"{member.Email},{member.Username},{member.Password}");
        }

        // Đọc danh sách thành viên từ file
      /*  public void ReadMembersFromFile(string filePath)
        {
            var members = ReadPersonsFromFile(filePath, line =>
            {
                var data = line.Split(':');
                return new Member
                {
                    Id = data[0],
                    Name = data[1],
                    Address = data[2],
                    PhoneNumber = data[3],
                    Email = data[4],
                    Username = data[5],
                    Password = data[6]
                };
            });

            foreach (var member in members)
            {
                AddPerson(member);
            }
        }*/
    }
}
