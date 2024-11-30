using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Model
{
    internal class Librarian : Person
    {
        private string id;
        private string role;
        public string Id { get { return id; } set { this.id = value; } }
        public string Role { get { return role; } set { this.role = value; } }
        public Librarian()
        {

        }
        public override string ToString()
        {
            return $"ID: {Id}\nRole: {Role}" + base.ToString();
        }
    }
}
