using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using LibraryManagement.Model;
using LibraryManagement.Util;

namespace LibraryManagement.Controller
{
    internal class BookControl
    {
        private List<Book> bookList; 
        public BookControl()
        {
            string filePath = System.IO.Path.Combine(RelativePath.projectRoot, "TextFiles", "Book.txt");
            var bookList = ReadBookFromFile(filePath);
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
        public bool BorrowBook(string bookId)
        {
            Book bookToBorrow = bookList.FirstOrDefault(b => b.Id == bookId);
            if (bookToBorrow != null)
            {
                if (bookToBorrow.IsAvailable)
                {
                    bookToBorrow.BorrowBook();
                    Console.WriteLine("Book borrowed successfully!");
                    Screen.WaitScreen();
                    return true;
                }
                else
                {
                    Console.WriteLine($"The book '{bookToBorrow.Title}' is currently not available for borrowing.");
                    Screen.WaitScreen();
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Book not found.");
                Screen.WaitScreen();
                return false;
            }
        }

        // Trả sách
        public bool ReturnBook(string bookId)
        {
            Book bookToReturn = bookList.FirstOrDefault(b => b.Id == bookId);
            if (bookToReturn != null)
            {
                bookToReturn.ReturnBook();
                Console.WriteLine("Book returned sucessfully!");
                Screen.WaitScreen();
                return true;
            }
            return false;
        }

        // Lấy danh sách sách
        public List<Book> GetBookList()
        {
            return bookList;
        }
        public void SetAvailability(string bookId, bool isAvailable)
        {
            Book bookToUpdate = bookList.FirstOrDefault(b => b.Id == bookId);
            if (bookToUpdate != null) bookToUpdate.IsAvailable = isAvailable; 
        }

        public void WriteToFile()
        {
            try
            {
                var content = string.Join("\n", bookList.Select(book =>
                    $"{book.Id}:{book.Title}:{book.Author}:{book.Genre}:{book.IsAvailable}:{book.PublicationDate:MM/dd/yyyy}"));

                string filePath = System.IO.Path.Combine(RelativePath.projectRoot, "TextFiles", "Book.txt");
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