using System;
using LibraryManagement.Controller;
using LibraryManagement.Model;
using LibraryManagement.View;

namespace LibraryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Khởi tạo các đối tượng của Controller và View
            StaffControl staffControl = new StaffControl();
            MemberControl memberControl = new MemberControl();
            BookControl bookControl = new BookControl();
            StaffView staffView = new StaffView();
            MemberView memberView = new MemberView();

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("------ Library Management System ------");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Exit");
                Console.Write("Choose an option (1-2): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string userRole;
                        if (Login(staffControl, memberControl, out userRole))
                        {
                            // Đăng nhập thành công, tiếp tục vào menu tương ứng
                            if (userRole == "staff")
                            {
                                StaffMenu(staffControl, staffView);  // Vào menu Staff
                            }
                            else if (userRole == "member")
                            {
                                MemberMenu(memberControl, bookControl, memberView, userRole);  // Vào menu Member
                            }
                        }
                        break;
                    case "2":
                        exit = true;
                        Console.WriteLine("Exiting the program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        // Login function for both staff and members
        static bool Login(StaffControl staffControl, MemberControl memberControl, out string userRole)
        {
            Console.Clear();
            Console.WriteLine("------ Login ------");
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            // Kiểm tra thông tin đăng nhập cho nhân viên
            Staff staff = staffControl.GetStaffByUsernameAndPassword(username, password);
            if (staff != null)
            {
                userRole = "staff"; // Đánh dấu là staff
                Console.WriteLine("Staff logged in successfully!");
                return true;
            }

            // Kiểm tra thông tin đăng nhập cho thành viên
            Member member = memberControl.GetMemberByUsernameAndPassword(username, password);
            if (member != null)
            {
                userRole = "member"; // Đánh dấu là member
                Console.WriteLine("Member logged in successfully!");
                return true;
            }

            userRole = null;
            Console.WriteLine("Invalid credentials. Please try again.");
            return false;
        }


        static void StaffMenu(StaffControl staffControl, StaffView staffView)
        {
            bool staffExit = false;
            while (!staffExit)
            {
                Console.Clear();
                Console.WriteLine("------ Staff Management Menu ------");
                Console.WriteLine("1. Add Staff");
                Console.WriteLine("2. Update Staff");
                Console.WriteLine("3. Remove Staff");
                Console.WriteLine("4. Display All Staff");
                Console.WriteLine("5. Search Staff by ID");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Choose an option (1-6): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Staff newStaff = staffView.GetNewStaffInput();
                        staffControl.AddStaff(newStaff);
                        staffView.DisplaySuccessMessage("Staff added successfully.");
                        break;

                    case "2":
                        staffView.GetUpdateStaffInput(out string staffId, out string newRole);
                        staffControl.UpdateStaff(staffId, newRole);
                        staffView.DisplaySuccessMessage("Staff updated successfully.");
                        break;

                    case "3":
                        string staffIdToRemove = staffView.GetStaffIdForRemoval();
                        staffControl.RemoveStaff(staffIdToRemove);
                        staffView.DisplaySuccessMessage("Staff removed successfully.");
                        break;

                    case "4":
                        staffView.DisplayAllStaff(staffControl.GetStaffList());
                        break;

                    case "5":
                        Console.WriteLine("Enter Staff ID to search:");
                        string searchId = Console.ReadLine();
                        staffControl.SearchStaffById(searchId);
                        break;

                    case "6":
                        staffExit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        static void MemberMenu(MemberControl memberControl, BookControl bookControl, MemberView memberView, string userId)
        {
            bool memberExit = false;
            Member currentMember = memberControl.GetMemberById(userId);

            if (currentMember == null)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            while (!memberExit)
            {
                Console.Clear();
                Console.WriteLine("------ Member Menu ------");
                Console.WriteLine("1. View My Information");
                Console.WriteLine("2. Borrow Book");
                Console.WriteLine("3. Return Book");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Choose an option (1-4): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        memberView.DisplayMemberInfo(currentMember);
                        break;

                    case "2":
                        Console.Write("Enter Book ID to borrow: ");
                        string bookIdToBorrow = Console.ReadLine();
                        bookControl.BorrowBook(bookIdToBorrow);
                        break;

                    case "3":
                        Console.Write("Enter Book ID to return: ");
                        string bookIdToReturn = Console.ReadLine();
                        bookControl.ReturnBook(bookIdToReturn);
                        break;

                    case "4":
                        memberExit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }
    }
}
