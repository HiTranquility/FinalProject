using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Model
{
    internal class Staff : Person
    {
        private string id;
        private string role;
        public string Id { get { return id; } set { this.id = value; } }
        public string Role { get { return role; } set { this.role = value; } }
        public Staff() { }
        public override string ToString()
        {
            return $"\nID: {Id}\nRole: {Role}" + base.ToString();
        }
    }
}
