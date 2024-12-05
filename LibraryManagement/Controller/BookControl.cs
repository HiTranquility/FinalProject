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
            var bookList = ReadBookFromFile("C:\\Users\\Admin\\Downloads\\OOP\\FinalProject\\LibraryManagement\\TextFiles\\Book.txt");  
            this.bookList = bookList;
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

        public void WriteToFile(string filePath)
        {
            try
            {
                var content = string.Join("\n", bookList.Select(book =>
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
        public List<Book> ReadBookFromFile(string filePath)
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
                            IsAvailable = bool.Parse(data[4]),
                            PublicationDate = DateTime.Parse(data[5])
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