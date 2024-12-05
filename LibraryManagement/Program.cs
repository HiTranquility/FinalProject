using System;
using LibraryManagement.Controller;
using LibraryManagement.Model;
using LibraryManagement.Util;
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
            LibrarianView librarianView = new LibrarianView();
            MemberView memberView = new MemberView();

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("------ Library Management System ------");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. See credits");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option (1-3): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string userRole;
                        string userID;
                        if (Login(staffControl, librarianControl ,memberControl, out userRole, out userID))
                        {
                            // Đăng nhập thành công, tiếp tục vào menu tương ứng
                            if (userRole == "Staff")
                            {
                                StaffView.StaffMenu(staffControl, staffView, librarianControl, memberControl);  // Vào menu Staff
                            }
                            else if (userRole == "Librarian")
                            {
                                LibrarianView.LibrarianMenu(bookControl, librarianView);  // Vào menu Member
                            }
                            else if (userRole == "Member")
                            {
                                MemberView.MemberMenu(memberControl, bookControl, memberView, userID);  // Vào menu Member
                            }
                            else break;
                        }
                        break;
                    case "2":
                        Console.WriteLine("Project: Library Management");
                        Console.WriteLine("Made by: ");
                        Console.WriteLine("22110060 - Nguyen Tan Phat");
                        Console.WriteLine("22110051 - Nguyen Huu Nghi");
                        Console.WriteLine("22110009 - Le Cong Bao");
                        Screen.WaitScreen();
                        break;
                    case "3":
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

            Staff staff = staffControl.GetPersonByUsernameAndPassword(username, password);
            if (staff != null)
            {
                userRole = "Staff";
                userID = staffControl.GetIdByUsername(username);
                Console.WriteLine("Staff logged in successfully!");
                return true;
            }
            Librarian librarian = librarianControl.GetPersonByUsernameAndPassword(username, password);
            if (librarian != null)
            {
                userRole = "Librarian";
                userID = staffControl.GetIdByUsername(username);
                Console.WriteLine("Librarian logged in successfully!");
                return true;
            }
            Member member = memberControl.GetPersonByUsernameAndPassword(username, password);
            if (member != null)
            {
                userRole = "Member";
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
