using LibraryManagement.Util;
using System;
using System.Collections.Generic;

namespace LibraryManagement.Model
{
    internal class Member : Person
    {
        private string id;
        private string role;
        private DateTime membershipStartDate;
        private string bookLink;
        private List<Book> borrowedBooks = new List<Book>();

        public string Id { get { return id; } set { this.id = value; } }
        public string Role { get { return role; } set { this.role = value; } }
        public DateTime MembershipStartDate { get { return membershipStartDate; } set { this.membershipStartDate = value; } }
        public string BookLink { get { return bookLink; } set { this.bookLink = value; } }
        public List<Book> BorrowedBooks { get { return borrowedBooks; } set { this.borrowedBooks = value; } }

        public Member()
        {
            var borrowedBooks = ReadBorrowedBooksFromFile($"C:\\Users\\Admin\\Downloads\\OOP\\FinalProject\\LibraryManagement\\BookFiles\\{bookLink}");
            this.borrowedBooks = borrowedBooks;
        }
        public override string GetId()
        {
            return Id; 
        }
        public override string ToString()
        {
            // Call the ToString() method of the base class and append Member details
            return base.ToString() +
                   $"\nMembership ID: {Id}\n" +
                   $"Role: {Role}\n" +
                   $"Membership Start Date: {MembershipStartDate.ToShortDateString()}\n";
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
                Console.WriteLine($"Available: {(book.IsAvailable ? "Yes" : "No")}");
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
