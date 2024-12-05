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


            while (!memberExit)
            {
                Console.Clear();
                Console.WriteLine("------ Member Menu ------");
                Console.WriteLine("1. View My Information");
                Console.WriteLine("2. Borrow Book");
                Console.WriteLine("3. Return Book");
                Console.WriteLine("4. View all Borrowed Books");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Choose an option (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        memberControl.DisplayPersonDetails(currentMember.GetId());
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

