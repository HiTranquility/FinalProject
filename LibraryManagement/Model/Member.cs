using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Model
{
    internal class Member : Person
    {
        private string id;
        private DateTime membershipStartDate;
        private DateTime membershipEndDate;
        private List<string> borrowedBooks;

        public string Id { get { return id; } set { this.id = value; } }
        public DateTime MembershipStartDate { get { return membershipStartDate; } set { this.membershipStartDate = value; } }
        public DateTime MembershipEndDate { get { return membershipEndDate; } set { this.membershipEndDate = value; } }
        public List<string> BorrowedBooks { get { return borrowedBooks; } set { this.borrowedBooks = value; } }

        public Member()
        {
            borrowedBooks = new List<string>();  
        }

        public void BorrowBook(string bookTitle)
        {
            borrowedBooks.Add(bookTitle);
        }

        public void ReturnBook(string bookTitle)
        {
            borrowedBooks.Remove(bookTitle);
        }

        public override string ToString()
        {
            // Gọi phương thức ToString() của lớp Person và thêm thông tin Member
            return $"\nMembership ID: {Id}\nMembership Start Date: {MembershipStartDate.ToShortDateString()}\nMembership End Date: {MembershipEndDate.ToShortDateString()}\nBorrowed Books: {string.Join(", ", BorrowedBooks)}" + base.ToString();
        }
    }
}

