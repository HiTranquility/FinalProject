using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagement.Model;

namespace LibraryManagement.Controller
{
    internal class LibrarianControl
    {
        private List<Librarian> librarianList;

        public LibrarianControl()
        {
            librarianList = new List<Librarian>();
        }

        // Add a new librarian
        public void AddLibrarian(Librarian librarian)
        {
            librarianList.Add(librarian);
            Console.WriteLine("Librarian added successfully.");
        }

        // Remove a librarian by ID
        public void RemoveLibrarian(string librarianId)
        {
            Librarian librarianToRemove = librarianList.FirstOrDefault(l => l.Id == librarianId);
            if (librarianToRemove != null)
            {
                librarianList.Remove(librarianToRemove);
                Console.WriteLine("Librarian removed successfully.");
            }
            else
            {
                Console.WriteLine("Librarian not found.");
            }
        }

        // Update librarian's role
        public void UpdateLibrarian(string librarianId, string newRole)
        {
            Librarian librarianToUpdate = librarianList.FirstOrDefault(l => l.Id == librarianId);
            if (librarianToUpdate != null)
            {
                librarianToUpdate.Role = newRole;
                Console.WriteLine("Librarian role updated successfully.");
            }
            else
            {
                Console.WriteLine("Librarian not found.");
            }
        }


        // Display all librarians
        public void DisplayAllLibrarians()
        {
            if (librarianList.Count == 0)
            {
                Console.WriteLine("No librarians found.");
                return;
            }

            foreach (var librarian in librarianList)
            {
                Console.WriteLine(librarian.ToString());
                Console.WriteLine("Press any key to continue to the next librarian...");
                Console.ReadKey();  // Pause to allow the user to read the information
            }
        }

        // Search librarian by ID
        public void SearchLibrarianById(string librarianId)
        {
            Librarian librarian = librarianList.FirstOrDefault(l => l.Id == librarianId);
            if (librarian != null)
            {
                Console.WriteLine(librarian.ToString());
            }
            else
            {
                Console.WriteLine("Librarian not found.");
            }
        }

        // Get librarian by username and password
        public Librarian GetLibrarianByUsernameAndPassword(string username, string password)
        {
            return librarianList.FirstOrDefault(librarian => librarian.Username == username && librarian.Password == password);
        }

        // Get librarian ID by username
        public string GetIdByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }

            var librarian = librarianList.FirstOrDefault(l => l.Username == username);
            return librarian?.Id;
        }

        // Get a librarian by ID
        public Librarian GetLibrarianById(string librarianId)
        {
            return librarianList.FirstOrDefault(librarian => librarian.Id == librarianId);
        }

        // Return the list of librarians
        public List<Librarian> GetLibrarianList()
        {
            return librarianList;
        }
    }
}
