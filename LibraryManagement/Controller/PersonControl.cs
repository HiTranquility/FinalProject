﻿using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Controller
{
    internal class PersonControl<T> where T : Person, new()
    {
        private List<T> personList;
        public PersonControl()
        {
            personList = new List<T>();
        }
        private string GenerateNextPersonId(string prefix)
        {
            // Find the highest personId currently in the list that starts with the given prefix
            var maxId = personList.Select(p => p.GetId())
                                  .Where(id => id.StartsWith(prefix))  // Filter by the given prefix (e.g., "P", "M", "L", etc.)
                                  .Select(id =>
                                  {
                                      // Safely extract and parse the numeric part after the prefix
                                      string numericPart = id.Substring(prefix.Length);
                                      return int.TryParse(numericPart, out var result) ? result : 0;
                                  })
                                  .DefaultIfEmpty(0)  // If no matching IDs, start from 0
                                  .Max();

            // Increment the maxId and format it as a 3-digit number with the given prefix
            return prefix + (maxId + 1).ToString("D3");
        }


        // Add a person and automatically assign an Id if not provided
        public virtual void AddPerson(T person)
        {
            if (string.IsNullOrEmpty(person.GetId()))
            {
                string prefix = person.GetType().Name.Substring(0, 1).ToUpper();  // Get the first letter of the class name (e.g., "M" for Member, "L" for Librarian)
                person.SetId(GenerateNextPersonId(prefix));  // Generate the next ID using the prefix
            }

            personList.Add(person);
        }
        public virtual void RemovePersonById(string id)
        {
            T personToRemove = personList.FirstOrDefault(person => person.GetId() == id);
            if (personToRemove != null)
            {
                personList.Remove(personToRemove);
                Console.WriteLine($"Person with ID '{id}' has been removed.");
            }
            else
            {
                Console.WriteLine($"No person found with ID '{id}'.");
            }
        }
        public virtual void UpdatePersonById(string id)
        {
            T personToUpdate = null;

            foreach (var person in personList)
            {
                if (person.GetId() == id)
                {
                    personToUpdate = person;
                    break;
                }
            }
        }
        public virtual void DisplayAllPersons()
        {
            foreach (var person in personList)
            {
                Console.WriteLine(person.ToString());
            }
        }
        public virtual void DisplayPersonDetails(string id)
        {
            T personToDisplay = null;

            foreach (var person in personList)
            {
                if (person.GetId() == id)
                {
                    personToDisplay = person;
                    break;
                }
            }
            if (personToDisplay != null)
            {
                Console.WriteLine(personToDisplay.ToString());
            }
        }
        public virtual T GetPersonById(string id)
        {
            return personList.FirstOrDefault(person => person.GetId() == id);
        }
        public virtual List<T> GetPersonList()
        {
            return personList;
        }
        public virtual string GetIdByUsername(string username)
        {
            var staff = GetPersonList().Find(s => s.Username == username);
            return staff?.GetId();
        }
        public virtual T GetPersonByUsernameAndPassword(string username, string password)
        {
            return GetPersonList().Find(s => s.Username == username && s.Password == password);
        }
        public virtual void ReadPersonsFromFile(string filePath)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        T person = ParsePerson(line);
                        if (person != null)
                        {
                            personList.Add(person);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading person data from file: {ex.Message}");
            }
        }
        private T ParsePerson(string data)
        {
            return new T();
        }
    }
}
