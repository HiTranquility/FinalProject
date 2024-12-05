using LibraryManagement.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Model
{
    internal class Member : Person
    {
        private string id;
        private string role;
        private DateTime membershipStartDate;
        private string bookLink;
        private List<Book> borrowedBooks;

        // Các thuộc tính đánh dấu sự thay đổi
        private bool isRoleChanged;
        private bool isMembershipStartDateChanged;
        private bool isBookLinkChanged;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Role
        {
            get { return role; }
            set { role = value; isRoleChanged = true; }
        }

        public DateTime MembershipStartDate
        {
            get { return membershipStartDate; }
            set { membershipStartDate = value; isMembershipStartDateChanged = true; }
        }

        public string BookLink
        {
            get { return bookLink; }
            set { bookLink = value; isBookLinkChanged = true; }
        }

        public List<Book> BorrowedBooks
        {
            get { return borrowedBooks; }
            set { borrowedBooks = value; }
        }

        // Constructor
        public Member()
        {
            borrowedBooks = new List<Book>();
        }

        public override string GetId()
        {
            return Id;
        }
        public override void SetId(string id)
        {
            this.id = id;
        }

        public override string ToString()
        {
            string memberInfo = base.ToString() +
                   $"\nMembership ID: {Id}\n";

            // Kiểm tra và tô đậm các trường đã thay đổi
            Console.ForegroundColor = isRoleChanged ? ConsoleColor.Yellow : ConsoleColor.White;
            memberInfo += $"Role: {Role}\n";

            Console.ForegroundColor = isMembershipStartDateChanged ? ConsoleColor.Yellow : ConsoleColor.White;
            memberInfo += $"Membership Start Date: {MembershipStartDate.ToShortDateString()}\n";

            Console.ForegroundColor = isBookLinkChanged ? ConsoleColor.Yellow : ConsoleColor.White;
            memberInfo += $"Book Link: {BookLink}\n";

            Console.ResetColor();
            return memberInfo;
        }

        public void DisplayBorrowedBookDetails()
        {
            if (borrowedBooks.Count == 0)
            {
                Console.WriteLine("You have not borrowed any books.");
                return;
            }

            Console.WriteLine("------ Borrowed Books ------");
            foreach (var book in borrowedBooks)
            {
                Console.WriteLine($"Book ID: {book.Id}");
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"Genre: {book.Genre}");
                Console.WriteLine($"Publication Date: {book.PublicationDate:MM/dd/yyyy}");
                Console.WriteLine("---------------------------");
            }
        }

        public void WriteToFile(string filePath)
        {
            try
            {
                var content = string.Join("\n", borrowedBooks.Select(book =>
                    $"{book.Id},{book.Title},{book.Author},{book.Genre},{book.IsAvailable}," +
                    $"{book.PublicationDate:MM/dd/yyyy}"));

                // Write the formatted content to the file
                System.IO.File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing book data to file: {ex.Message}");
            }
        }

        // Đọc danh sách sách từ file
        public List<Book> ReadBorrowedBooksFromFile(string filePath)
        {
            var bookList = new List<Book>();
            try
            {
                string[] lines = Read_WriteFile.Instance.ReadFile(filePath).Split('\n');
                foreach (var line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var data = line.Split(':');
                        var book = new Book
                        {
                            Id = data[0],
                            Title = data[1],
                            Author = data[2],
                            Genre = data[3],
                            PublicationDate = DateTime.Parse(data[4])
                        };
                        bookList.Add(book);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading book data from file: {ex.Message}");
            }

            return bookList;
        }
    }
}
