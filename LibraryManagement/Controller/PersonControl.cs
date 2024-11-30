using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Controller
{
    internal class PersonControl<T> where T : class, new()
    {
        // Danh sách các đối tượng kiểu T
        private List<T> personList;

        // Constructor
        public PersonControl()
        {
            personList = new List<T>();
        }

        // Thêm đối tượng kiểu T
        public void AddPerson(T person)
        {
            personList.Add(person);
        }

        // Xóa đối tượng kiểu T dựa trên ID (giả định rằng kiểu T có thuộc tính Id)
        public void RemovePersonById(string id)
        {
            T personToRemove = personList.FirstOrDefault(person => GetId(person) == id);
            if (personToRemove != null)
            {
                personList.Remove(personToRemove);
            }
        }

        // Cập nhật thông tin đối tượng kiểu T dựa trên ID (giả định rằng kiểu T có thuộc tính Id)
        public void UpdatePersonById(string id, string newInfo)
        {
            T personToUpdate = personList.FirstOrDefault(person => GetId(person) == id);
            if (personToUpdate != null)
            {
                UpdatePersonInfo(personToUpdate, newInfo);
            }
        }

        // Hiển thị thông tin tất cả đối tượng
        public void DisplayAllPersons()
        {
            foreach (var person in personList)
            {
                Console.WriteLine(PersonToString(person));
            }
        }

        // Tìm kiếm đối tượng kiểu T dựa trên ID
        public T SearchPersonById(string id)
        {
            return personList.FirstOrDefault(person => GetId(person) == id);
        }

        // Lấy danh sách tất cả đối tượng
        public List<T> GetPersonList()
        {
            return personList;
        }

        // Đọc danh sách đối tượng từ file (mô phỏng)
        public void ReadPersonsFromFile(string filePath)
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

        // Ghi danh sách đối tượng ra file (mô phỏng)
        public void WriteToFile(string filePath)
        {
            try
            {
                var content = string.Join("\n", personList.Select(PersonToString));
                System.IO.File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing person data to file: {ex.Message}");
            }
        }