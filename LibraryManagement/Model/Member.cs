using System;
using System.Collections.Generic;

namespace LibraryManagement.Model
{
    internal class Member : Person
    {
        private string id;
        private string role;
        private DateTime membershipStartDate;
        private DateTime membershipEndDate;
        private List<Book> borrowedBooks;

        public string Id { get { return id; } set { id = value; } }
        public string Role { get { return role; } set { role = value; } }
        public DateTime MembershipStartDate { get { return membershipStartDate; } set { membershipStartDate = value; } }
        public DateTime MembershipEndDate { get { return membershipEndDate; } set { membershipEndDate = value; } }
        public List<Book> BorrowedBooks { get { return borrowedBooks; } set { borrowedBooks = value; } }

        public Member()
        {
            borrowedBooks = new List<Book>();
        }
        public override string GetId()
        {
            return Id; // Trả về thuộc tính `Id` của lớp `Member`
        }
        public void BorrowBook(Book book)
        {
            if (book.IsAvailable)
            {
                borrowedBooks.Add(book);
                book.BorrowBook(); 
            }
            else
            {
                Console.WriteLine($"The book '{book.Title}' is currently unavailable.");
            }
        }

        public void ReturnBook(Book book)
        {
            if (borrowedBooks.Contains(book))
            {
                borrowedBooks.Remove(book);
                book.ReturnBook(); // Update book's availability
            }
            else
            {
                Console.WriteLine($"The book '{book.Title}' is not borrowed by this member.");
            }
        }

        public override string ToString()
        {
            // Call the ToString() method of the base class and append Member details
            return base.ToString() +
                   $"\nMembership ID: {Id}\n" +
                   $"Role: {Role}\n" +
                   $"Membership Start Date: {MembershipStartDate.ToShortDateString()}\n" +
                   $"Membership End Date: {MembershipEndDate.ToShortDateString()}\n" +
                   $"Borrowed Books: {string.Join(", ", borrowedBooks.Select(b => b.Title))}";
        }
    }
}
