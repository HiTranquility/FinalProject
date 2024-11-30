using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagement.Model;
using LibraryManagement.Util;

namespace LibraryManagement.Controller
{
    internal class BookControl
    {
        private List<Book> bookList;

        public BookControl()
        {
            bookList = new List<Book>();
        }

        // Thêm sách mới
        public void AddBook(Book book)
        {
            bookList.Add(book);
        }

        // Xóa sách theo ID
        public void RemoveBook(string bookId)
        {
            Book bookToRemove = bookList.FirstOrDefault(b => b.Id == bookId);
            if (bookToRemove != null)
            {
                bookList.Remove(bookToRemove);
            }
        }

        // Cập nhật thông tin sách
        public void UpdateBook(string bookId, string newTitle, string newAuthor, string newGenre, bool newAvalability ,DateTime newPublicationDate)
        {
            Book bookToUpdate = bookList.FirstOrDefault(b => b.Id == bookId);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = newTitle;
                bookToUpdate.Author = newAuthor;
                bookToUpdate.Genre = newGenre;
                bookToUpdate.IsAvailable = newAvalability;
                bookToUpdate.PublicationDate = newPublicationDate;
            }
        }

        // Hiển thị tất cả sách
        public void DisplayAllBooks()
        {
            foreach (var book in bookList)
            {
                Console.WriteLine(book.ToString());
                Console.WriteLine("--------------------------------------------");
            }
            Screen.WaitScreen();
        }

        // Tìm kiếm sách theo ID
        public void SearchBookById(string bookId)
        {
            Book book = bookList.FirstOrDefault(b => b.Id == bookId);
            if (book != null)
            {
                Console.WriteLine(book.ToString());
            }
        }
        public Book GetBookById(string bookId)
        {
            return bookList.FirstOrDefault(b => b.Id == bookId);
        }

        // Mượn sách
        public void BorrowBook(string bookId)
        {
            Book bookToBorrow = bookList.FirstOrDefault(b => b.Id == bookId);
            if (bookToBorrow != null)
            {
                if (bookToBorrow.IsAvailable)
                {
                    bookToBorrow.BorrowBook();
                }
                else
                {
                    Console.WriteLine($"The book '{bookToBorrow.Title}' is currently not available for borrowing.");
                }
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        // Trả sách
        public void ReturnBook(string bookId)
        {
            Book bookToReturn = bookList.FirstOrDefault(b => b.Id == bookId);
            if (bookToReturn != null)
            {
                bookToReturn.ReturnBook();
            }
        }

        // Lấy danh sách sách
        public List<Book> GetBookList()
        {
            return bookList;
        }

        // Nhập thông tin sách mới từ người dùng
        public Book GetNewBookInput()
        {
            Console.WriteLine("Enter Book ID:");
            string id = Console.ReadLine();
            Console.WriteLine("Enter Book Title:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter Book Author:");
            string author = Console.ReadLine();
            Console.WriteLine("Enter Book Genre:");
            string genre = Console.ReadLine();
            Console.WriteLine("Enter Publication Date (yyyy-MM-dd):");
            bool newAvability = false;
            DateTime publicationDate = DateTime.Parse(Console.ReadLine());

            return new Book(id, title, author, genre, newAvability, publicationDate);
        }

        // Cập nhật thông tin sách
        public void GetUpdateBookInput(out string bookId, out string newTitle, out string newAuthor, out string newGenre, out DateTime newPublicationDate)
        {
            Console.WriteLine("Enter Book ID to update:");
            bookId = Console.ReadLine();
            Console.WriteLine("Enter new Book Title:");
            newTitle = Console.ReadLine();
            Console.WriteLine("Enter new Book Author:");
            newAuthor = Console.ReadLine();
            Console.WriteLine("Enter new Book Genre:");
            newGenre = Console.ReadLine();
            Console.WriteLine("Enter new Publication Date (yyyy-MM-dd):");
            newPublicationDate = DateTime.Parse(Console.ReadLine());
        }

        // Lấy ID sách để xóa
        public string GetBookIdForRemoval()
        {
            Console.WriteLine("Enter Book ID to remove:");
            return Console.ReadLine();
        }
        private void WriteToFile()
        {
            string content = "";
            foreach (var book in bookList)
            {
                content += $"{book.Id},{book.Title},{book.Author},{book.Genre},{book.IsAvailable},{book.PublicationDate.ToString("MM/dd/yyyy")}\n";
            }
            Read_WriteFile.Instance.WriteFile("Books.txt", content);
        }

        // Đọc danh sách sách từ file
        public List<Book> ReadBooksFromFile(string filePath)
        {
            var books = new List<Book>();

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
                            IsAvailable = bool.Parse(data[4]),
                            PublicationDate = DateTime.Parse(data[5])
                        };
                        books.Add(book);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading book data from file: {ex.Message}");
            }

            return books;
        }
    }
}