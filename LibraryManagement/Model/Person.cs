namespace LibraryManagement.Model
{
    internal abstract class Person
    {
        private string name;
        private int age;
        private string gender;
        private DateTime dateofbirth;
        private string address;
        private string phonenumber;
        private string email;
        private string username;
        private string password;

        public string Name { get { return name; } set { this.name = value; } }
        public int Age { get { return age; } set { this.age = value; } }
        public string Gender { get { return gender; } set { this.gender = value; } }
        public DateTime DateOfBirth { get { return dateofbirth; } set { this.dateofbirth = value; } }
        public string Address { get { return address; } set { this.address = value; } }
        public string PhoneNumber { get { return phonenumber; } set { this.phonenumber = value; } }
        public string Email { get { return email; } set { this.email = value; } }
        public string Username { get { return username; } set { this.username = value; } }
        public string Password { get { return password; } set { this.password = value; } }

        public Person() { }

        public Person(string name, int age, string gender, DateTime dateofbirth, string address, string phonenumber, string email, string username, string password)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.dateofbirth = dateofbirth;
            this.address = address;
            this.phonenumber = phonenumber;
            this.email = email;
            this.username = username;
            this.password = password;
        }
        public abstract string GetId();
        public override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"Age: {Age}\n" +
                   $"Gender: {Gender}\n" +
                   $"Date of Birth: {DateOfBirth.ToShortDateString()}\n" +
                   $"Address: {Address}\n" +
                   $"Phone Number: {PhoneNumber}\n" +
                   $"Email: {Email}\n" +
                   $"Username: {Username}\n" +
                   $"Password: [Hidden]\n";
        }
    }
}
