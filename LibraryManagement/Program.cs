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
            LibrarianControl librarianControl = new LibrarianControl();
            MemberControl memberControl = new MemberControl();
            BookControl bookControl = new BookControl();
            StaffView staffView = new StaffView();
            //MemberView memberView = new MemberView();

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
                        string userID;
                        if (Login(staffControl, librarianControl ,memberControl, out userRole, out userID))
                        {
                            // Đăng nhập thành công, tiếp tục vào menu tương ứng
                            if (userRole == "staff")
                            {
                                StaffView.StaffMenu(staffControl, staffView, librarianControl, memberControl);  // Vào menu Staff
                            }
                            else if (userRole == "librarian")
                            {
                                //LibrarianMenu(memberControl, bookControl, userID);  // Vào menu Member
                            }
                            else
                            {
                                //MemberView.MemberMenu(memberControl, bookControl, memberView);  // Vào menu Member
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

        public static bool Login(StaffControl staffControl, LibrarianControl librarianControl ,MemberControl memberControl, out string userRole, out string userID)
        {
            Console.Clear();
            Console.WriteLine("------ Login ------");
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            Staff staff = staffControl.GetStaffByUsernameAndPassword(username, password);
            if (staff != null)
            {
                userRole = "staff";
                userID = staffControl.GetIdByUsername(username);
                Console.WriteLine("Staff logged in successfully!");
                return true;
            }
            Librarian librarian = librarianControl.GetLibrarianByUsernameAndPassword(username, password);
            if (librarian != null)
            {
                userRole = "librarian";
                userID = staffControl.GetIdByUsername(username);
                Console.WriteLine("Librarian logged in successfully!");
                return true;
            }
            // Kiểm tra thông tin đăng nhập cho thành viên
            Member member = memberControl.GetMemberByUsernameAndPassword(username, password);
            if (member != null)
            {
                userRole = "member"; // Đánh dấu là member
                userID = memberControl.GetIdByUsername(username);
                Console.WriteLine("Member logged in successfully!");
                return true;
            }

            userRole = null;
            userID = null;
            Console.WriteLine("Invalid credentials. Please try again.");
            return false;
        }

    }
}
