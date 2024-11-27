using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Model;

namespace LibraryManagement.View
{
    internal class MemberView
    {
        // Hiển thị tất cả thành viên
        public void DisplayAllMembers(List<Member> memberList)
        {
            Console.WriteLine("---- List of Members ----");
            foreach (var member in memberList)
            {
                Console.WriteLine(member.ToString());
            }
            Console.WriteLine("Press any key to continue to exit!...");
            Console.ReadKey();  // Dừng lại cho đến khi người dùng nhấn một phím
        }

        // Hiển thị chi tiết thông tin thành viên
        public void DisplayMemberDetails(Member member)
        {
            if (member != null)
            {
                Console.WriteLine("---- Member Details ----");
                Console.WriteLine(member.ToString());
            }
            else
            {
                Console.WriteLine("Member not found.");
            }
        }

        // Hiển thị thông báo thành công
        public void DisplaySuccessMessage(string message)
        {
            Console.WriteLine(message);
        }

        // Hiển thị thông báo lỗi
        public void DisplayErrorMessage(string message)
        {
            Console.WriteLine("Error: " + message);
        }

        // Nhận thông tin đầu vào để thêm thành viên
        public Member GetNewMemberInput()
        {
            Console.WriteLine("Enter Member Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Member Age:");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Member Gender:");
            string gender = Console.ReadLine();

            Console.WriteLine("Enter Member ID:");
            string id = Console.ReadLine();

            Console.WriteLine("Enter Member Address:");
            string address = Console.ReadLine();

            return new Member { Name = name, Age = age, Gender = gender, Id = id, Address = address };
        }

        // Nhận thông tin đầu vào để cập nhật địa chỉ thành viên
        public void GetUpdateMemberInput(out string memberId, out string newAddress)
        {
            Console.WriteLine("Enter Member ID to update:");
            memberId = Console.ReadLine();

            Console.WriteLine("Enter New Address:");
            newAddress = Console.ReadLine();
        }

        // Nhận thông tin đầu vào để xóa thành viên
        public string GetMemberIdForRemoval()
        {
            Console.WriteLine("Enter Member ID to remove:");
            return Console.ReadLine();
        }
        public void DisplayMemberInfo(Member member)
        {
            if (member != null)
            {
                Console.WriteLine("---- Current Member Information ----");
                Console.WriteLine($"Name: {member.Name}");
                Console.WriteLine($"Age: {member.Age}");
                Console.WriteLine($"Gender: {member.Gender}");
                Console.WriteLine($"ID: {member.Id}");
                Console.WriteLine($"Address: {member.Address}");
                Console.WriteLine($"Phone Number: {member.PhoneNumber}");
                Console.WriteLine($"Email: {member.Email}");
            }
            else
            {
                Console.WriteLine("Member not found.");
            }
        }
    }
}

