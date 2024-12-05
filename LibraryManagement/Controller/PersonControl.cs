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
        public virtual void AddPerson(T person)
        {
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
            return staff?.Username;
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

        public virtual void WriteToFile(string filePath)
        {
            try
            {
                var content = string.Join("\n", personList.Select(person => person.ToString()));
                System.IO.File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing person data to file: {ex.Message}");
            }
        }

        private T ParsePerson(string data)
        {
            return new T();
        }
    }
}
