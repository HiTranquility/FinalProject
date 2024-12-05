using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Controller;
using LibraryManagement.Model;
using LibraryManagement.Util;

namespace LibraryManagement.View
{
    internal class MemberView
    {
        public static void MemberMenu(MemberControl memberControl, BookControl bookControl, MemberView memberView, string userID)
        {
            bool memberExit = false;
            Member currentMember = memberControl.GetPersonById(userID);
            if (currentMember != null)
            {
                Console.WriteLine("Member logged in successfully!");
                userID = currentMember.Id; // Lưu userID từ thành viên đã đăng nhập
            }
            else
            {
                Console.WriteLine("Member not found! Please check your Username or Password.");
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
                // Quay lại menu chính
                return;
            }            

            while (!memberExit)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("         Member Menu               ");
                Console.WriteLine("====================================");
                Console.WriteLine($"| 1. View My Information           |");
                Console.WriteLine($"| 2. Borrow Book                   |");
                Console.WriteLine($"| 3. Return Book                   |");
                Console.WriteLine($"| 4. View All Borrowed Books       |");
                Console.WriteLine($"| 5. Back to Main Menu             |");
                Console.WriteLine("====================================");
                Console.Write("Choose an option (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        memberControl.DisplayPersonDetails(currentMember.GetId());
                        break;

                    case "2":
                        bookControl.DisplayAllBooks();
                        Console.Write("Enter Book ID to borrow: ");
                        string bookIdToBorrow = Console.ReadLine();
                        if (bookControl.BorrowBook(bookIdToBorrow))
                        {
                            bool availability = false;
                            bookControl.SetAvailability(bookIdToBorrow, availability);
                            Book book = bookControl.GetBookById(bookIdToBorrow);
                            memberControl.GetPersonById(userID).BorrowedBooks.Add(book);
                        }
                        break;

                    case "3":
                        memberControl.GetPersonById(userID).DisplayBorrowedBookDetails();
                        Console.Write("Enter Book ID to return: ");
                        string bookIdToReturn = Console.ReadLine();
                        if (bookControl.ReturnBook(bookIdToReturn))
                        {
                            bool availability = true;
                            bookControl.SetAvailability(bookIdToReturn, availability);
                            Book book = bookControl.GetBookById(bookIdToReturn);
                            memberControl.GetPersonById(userID).BorrowedBooks.Remove(book);
                        }
                        break;

                    case "4":
                        memberControl.GetPersonById(userID).DisplayBorrowedBookDetails();
                        Screen.WaitScreen();
                        break;

                    case "5":
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

