using System;
using System.Collections.Generic;
using LibraryManagement.Model;

namespace LibraryManagement.Controller
{
    internal class LibrarianControl : PersonControl<Librarian>
    {
        public LibrarianControl() : base()
        {
        }

        // Add a new librarian (reuses AddPerson from PersonControl)
        public void AddLibrarian(Librarian librarian)
        {
            AddPerson(librarian);
            Console.WriteLine("Librarian added successfully.");
        }

        // Remove a librarian by ID (reuses RemovePersonById from PersonControl)
        public void RemoveLibrarian(string librarianId)
        {
            RemovePersonById(librarianId);
        }

        // Update librarian's role (reuses UpdatePerson from PersonControl)
        public void UpdateLibrarian(string librarianId)
        {
            UpdatePersonById(librarianId);
        }

        // Display all librarians (reuses DisplayAllPersons from PersonControl)
        public void DisplayAllLibrarians()
        {
            DisplayAllPersons();
        }

        public void DisplayLibrarianDetails(string id)
        {
            DisplayPersonDetails(id);
        }
        public List<Librarian> GetLibrarianList()
        {
            return GetPersonList();
        }

        // Search for a librarian by ID (reuses SearchPerson from PersonControl)
        public Librarian GetLibrarianById(string librarianId)
        {
            return GetPersonById(librarianId);
        }

        // Get librarian by username and password
        public Librarian GetLibrarianByUsernameAndPassword(string username, string password)
        {
            return GetPersonList().Find(s => s.Username == username && s.Password == password);
        }

        // Get librarian ID by username
        public string GetIdByUsername(string username)
        {
            var staff = GetPersonList().Find(s => s.Username == username);
            return staff?.Username;
        }
    }
}
