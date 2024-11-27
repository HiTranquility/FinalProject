using System;

namespace LibraryManagement.Model
{
    internal class Book
    {
        private string id;
        private string title;
        private string author;
        private string genre;
        private bool isAvailable;
        private DateTime publicationDate;

        public string Id { get { return id; } set { id = value; } }
        public string Title { get { return title; } set { title = value; } }
        public string Author { get { return author; } set { author = value; } }
        public string Genre { get { return genre; } set { genre = value; } }
        public bool IsAvailable { get { return isAvailable; } set { isAvailable = value; } }
        public DateTime PublicationDate { get { return publicationDate; } set { publicationDate = value; } }

        public Book() { }

        public Book(string id, string title, string author, string genre, DateTime publicationDate)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.genre = genre;
            this.publicationDate = publicationDate;
            this.isAvailable = true;  // Sách mới mặc định là có sẵn
        }

        // Phương thức mượn sách
        public void BorrowBook()
        {
            if (isAvailable)
            {
                isAvailable = false;
                Console.WriteLine($"The book '{Title}' has been borrowed.");
            }
            else
            {
                Console.WriteLine($"The book '{Title}' is currently not available.");
            }
        }

        // Phương thức trả sách
        public void ReturnBook()
        {
            isAvailable = true;
            Console.WriteLine($"The book '{Title}' has been returned.");
        }

        // Phương thức ToString để hiển thị thông tin sách
        public override string ToString()
        {
            return $"ID: {Id}\n" +
                   $"Title: {Title}\n" +
                   $"Author: {Author}\n" +
                   $"Genre: {Genre}\n" +
                   $"Publication Date: {PublicationDate.ToShortDateString()}\n" +
                   $"Available: {(IsAvailable ? "Yes" : "No")}";
        }
    }
}
