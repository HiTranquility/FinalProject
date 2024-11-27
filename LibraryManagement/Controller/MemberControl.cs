using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Model;

namespace LibraryManagement.Controller
{
    internal class MemberControl
    {
        private List<Member> memberList;

        public MemberControl()
        {
            memberList = new List<Member>();
        }

        // Thêm thành viên mới
        public void AddMember(Member member)
        {
            memberList.Add(member);
            Console.WriteLine("Member added successfully.");
        }

        // Xóa thành viên theo ID
        public void RemoveMember(string memberId)
        {
            Member memberToRemove = memberList.FirstOrDefault(m => m.Id == memberId);
            if (memberToRemove != null)
            {
                memberList.Remove(memberToRemove);
                Console.WriteLine("Member removed successfully.");
            }
            else
            {
                Console.WriteLine("Member not found.");
            }
        }

        // Cập nhật thông tin thành viên
        public void UpdateMember(string memberId, string newAddress)
        {
            Member memberToUpdate = memberList.FirstOrDefault(m => m.Id == memberId);
            if (memberToUpdate != null)
            {
                memberToUpdate.Address = newAddress;
                Console.WriteLine("Member address updated successfully.");
            }
            else
            {
                Console.WriteLine("Member not found.");
            }
        }

        // Hiển thị tất cả thành viên
        public void DisplayAllMembers()
        {
            foreach (var member in memberList)
            {
                Console.WriteLine(member.ToString());
                Console.WriteLine("Press any key to continue to the next member...");
                Console.ReadKey();  // Dừng lại cho đến khi người dùng nhấn một phím
            }
        }

        // Tìm kiếm thành viên theo ID
        public void SearchMemberById(string memberId)
        {
            Member member = memberList.FirstOrDefault(m => m.Id == memberId);
            if (member != null)
            {
                Console.WriteLine(member.ToString());
            }
            else
            {
                Console.WriteLine("Member not found.");
            }
        }

        // Trả về danh sách thành viên
        public List<Member> GetMemberList()
        {
            return memberList;
        }

        // Lấy thành viên theo ID
        public Member GetMemberById(string memberId)
        {
            return memberList.FirstOrDefault(member => member.Id == memberId);
        }



        // Lấy thành viên theo username và password
        public Member GetMemberByUsernameAndPassword(string username, string password)
        {
            return memberList.FirstOrDefault(member => member.Username == username && member.Password == password);
        }


    }
}
