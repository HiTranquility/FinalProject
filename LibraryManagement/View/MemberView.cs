//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using LibraryManagement.Controller;
//using LibraryManagement.Model;

//namespace LibraryManagement.View
//{
//    internal class MemberView
//    {
//        public void DisplaySuccessMessage(string message)
//        {
//            Console.WriteLine(message);
//        }

//        // Hiển thị thông báo lỗi
//        public void DisplayErrorMessage(string message)
//        {
//            Console.WriteLine("Error: " + message);
//        }
//        public static void MemberMenu(MemberControl memberControl, BookControl bookControl, MemberView memberView)
//        {
//            bool memberExit = false;
//            Member currentMember = memberControl.GetMemberById();

//            if (currentMember == null)
//            {
//                Console.WriteLine("Member not found.");
//                return;
//            }

//            while (!memberExit)
//            {
//                Console.Clear();
//                Console.WriteLine("------ Member Menu ------");
//                Console.WriteLine("1. View My Information");
//                Console.WriteLine("2. Borrow Book");
//                Console.WriteLine("3. Return Book");
//                Console.WriteLine("4. View Number of Borrowed Books");
//                Console.WriteLine("5. Back to Main Menu");
//                Console.Write("Choose an option (1-5): ");

//                string choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1":
//                        memberView.DisplayMemberInfo(currentMember);
//                        break;

//                    case "2":
//                        Console.Write("Enter Book ID to borrow: ");
//                        string bookIdToBorrow = Console.ReadLine();
//                        bookControl.BorrowBook(bookIdToBorrow);
//                        break;

//                    case "3":
//                        Console.Write("Enter Book ID to return: ");
//                        string bookIdToReturn = Console.ReadLine();
//                        bookControl.ReturnBook(bookIdToReturn);
//                        break;

//                    case "4":
//                        int borrowedBooksCount = memberControl.GetBorrowedBooksCount(currentMember.MemberId);
//                        Console.WriteLine($"You have currently borrowed {borrowedBooksCount} books.");
//                        Console.WriteLine("Press any key to continue...");
//                        Console.ReadKey();
//                        break;

//                    case "5":
//                        memberExit = true;
//                        break;

//                    default:
//                        Console.WriteLine("Invalid choice! Please try again.");
//                        break;
//                }
//            }
//        }
//    }
//}

