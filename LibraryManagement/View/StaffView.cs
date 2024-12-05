using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Controller;
using LibraryManagement.Model;
using LibraryManagement.Util;

namespace LibraryManagement.View
{
    internal class StaffView
    {
        // Staff Function
        #region
        public void DisplayAllStaff(List<Staff> staffList)
        {
            Console.WriteLine("---- List of Staff ----");

            // Define column widths for better alignment
            int idWidth = 5;
            int nameWidth = 17;
            int ageWidth = 5;
            int genderWidth = 10;
            int dobWidth = 15;
            int addressWidth = 27;
            int phoneWidth = 15;
            int emailWidth = 25;

            // Print table headers
            Console.WriteLine(
                $"{"ID".PadRight(idWidth)}{"Name".PadRight(nameWidth)}{"Age".PadRight(ageWidth)}{"Gender".PadRight(genderWidth)}{"DOB".PadRight(dobWidth)}{"Address".PadRight(addressWidth)}{"Phone Number".PadRight(phoneWidth)}{"Email".PadRight(emailWidth)}"
            );

            foreach (var staff in staffList)
            {
                // Print each staff's details
                Console.WriteLine(
                    $"{staff.Id.PadRight(idWidth)}{staff.Name.PadRight(nameWidth)}{staff.Age.ToString().PadRight(ageWidth)}{staff.Gender.PadRight(genderWidth)}{staff.DateOfBirth.ToString("yyyy-MM-dd").PadRight(dobWidth)}{staff.Address.PadRight(addressWidth)}{staff.PhoneNumber.PadRight(phoneWidth)}{staff.Email.PadRight(emailWidth)}"
                );
            }

            Screen.WaitScreen();
        }

        public void DisplayStaffDetails(Staff staff)
        {
            if (staff != null)
            {
                Console.WriteLine("---- Staff Details ----");

                // Define column widths for better alignment
                int labelWidth = 15;
                int valueWidth = 30;

                // Display staff details with label and value aligned
                Console.WriteLine($"{"ID:".PadRight(labelWidth)}{staff.Id.PadRight(valueWidth)}");
                Console.WriteLine($"{"Name:".PadRight(labelWidth)}{staff.Name.PadRight(valueWidth)}");
                Console.WriteLine($"{"Age:".PadRight(labelWidth)}{staff.Age.ToString().PadRight(valueWidth)}");
                Console.WriteLine($"{"Gender:".PadRight(labelWidth)}{staff.Gender.PadRight(valueWidth)}");
                Console.WriteLine($"{"Date of Birth:".PadRight(labelWidth)}{staff.DateOfBirth.ToString("yyyy-MM-dd").PadRight(valueWidth)}");
                Console.WriteLine($"{"Address:".PadRight(labelWidth)}{staff.Address.PadRight(valueWidth)}");
                Console.WriteLine($"{"Phone Number:".PadRight(labelWidth)}{staff.PhoneNumber.PadRight(valueWidth)}");
                Console.WriteLine($"{"Email:".PadRight(labelWidth)}{staff.Email.PadRight(valueWidth)}");
            }
            else
            {
                Console.WriteLine("Staff not found.");
            }

            Screen.WaitScreen();
        }

        public Staff GetNewStaffInput()
        {
            Console.WriteLine("Enter Staff ID:");
            string id = Console.ReadLine();

            Console.WriteLine("Enter Staff Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Staff Age:");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Staff Gender:");
            string gender = Console.ReadLine();

            Console.WriteLine("Enter Staff Date of Birth (YYYY-MM-DD):");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Staff Address:");
            string address = Console.ReadLine();

            Console.WriteLine("Enter Staff Phone Number:");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter Staff Email:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter Staff Username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter Staff Password:");
            string password = Console.ReadLine();

            return new Staff
            {
                Id = id,
                Role = "staff",
                Name = name,
                Age = age,
                Gender = gender,
                DateOfBirth = dateOfBirth,
                Address = address,
                PhoneNumber = phoneNumber,
                Email = email,
                Username = username,
                Password = password
            };
        }
        public void GetUpdateStaffInput(out string staffId)
        {
            Console.WriteLine("Enter Staff ID to update:");
            staffId = Console.ReadLine();
        }
        public string GetStaffIdForRemoval()
        {
            Console.WriteLine("Enter Staff ID to remove:");
            return Console.ReadLine();
        }
        #endregion
        // Member Function
        #region
        public void DisplayAllMembers(List<Member> memberList)
        {
            Console.WriteLine("---- List of Members ----");

            // Define column widths for better alignment
            int idWidth = 5;
            int nameWidth = 17;
            int ageWidth = 5;
            int genderWidth = 10;
            int dobWidth = 15;
            int addressWidth = 27;
            int phoneWidth = 15;
            int emailWidth = 25;

            // Print table headers
            Console.WriteLine(
                $"{"ID".PadRight(idWidth)}{"Name".PadRight(nameWidth)}{"Age".PadRight(ageWidth)}{"Gender".PadRight(genderWidth)}{"DOB".PadRight(dobWidth)}{"Address".PadRight(addressWidth)}{"Phone Number".PadRight(phoneWidth)}{"Email".PadRight(emailWidth)}"
            );

            foreach (var member in memberList)
            {
                // Print each member's details
                Console.WriteLine(
                    $"{member.Id.PadRight(idWidth)}{member.Name.PadRight(nameWidth)}{member.Age.ToString().PadRight(ageWidth)}{member.Gender.PadRight(genderWidth)}{member.DateOfBirth.ToString("yyyy-MM-dd").PadRight(dobWidth)}{member.Address.PadRight(addressWidth)}{member.PhoneNumber.PadRight(phoneWidth)}{member.Email.PadRight(emailWidth)}"
                );
            }

            Screen.WaitScreen();
        }

        public void DisplayMemberDetails(Member member)
        {
            if (member != null)
            {
                Console.WriteLine("---- Member Details ----");

                // Define column widths for better alignment
                int labelWidth = 15;
                int valueWidth = 30;

                // Display member details with label and value aligned
                Console.WriteLine($"{"ID:".PadRight(labelWidth)}{member.Id.PadRight(valueWidth)}");
                Console.WriteLine($"{"Name:".PadRight(labelWidth)}{member.Name.PadRight(valueWidth)}");
                Console.WriteLine($"{"Age:".PadRight(labelWidth)}{member.Age.ToString().PadRight(valueWidth)}");
                Console.WriteLine($"{"Gender:".PadRight(labelWidth)}{member.Gender.PadRight(valueWidth)}");
                Console.WriteLine($"{"Date of Birth:".PadRight(labelWidth)}{member.DateOfBirth.ToString("yyyy-MM-dd").PadRight(valueWidth)}");
                Console.WriteLine($"{"Address:".PadRight(labelWidth)}{member.Address.PadRight(valueWidth)}");
                Console.WriteLine($"{"Phone Number:".PadRight(labelWidth)}{member.PhoneNumber.PadRight(valueWidth)}");
                Console.WriteLine($"{"Email:".PadRight(labelWidth)}{member.Email.PadRight(valueWidth)}");
            }
            else
            {
                Console.WriteLine("Member not found.");
            }

            Screen.WaitScreen();
        }
        public Member GetNewMemberInput()
        {
            Console.WriteLine("Enter Member ID:");
            string id = Console.ReadLine();

            Console.WriteLine("Enter Member Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Member Age:");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Member Gender:");
            string gender = Console.ReadLine();

            Console.WriteLine("Enter Member Date of Birth (YYYY-MM-DD):");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Member Address:");
            string address = Console.ReadLine();

            Console.WriteLine("Enter Member Phone Number:");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter Member Email:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter Member Username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter Member Password:");
            string password = Console.ReadLine();

            return new Member
            {
                Id = id,
                Role = "member",
                Name = name,
                Age = age,
                Gender = gender,
                DateOfBirth = dateOfBirth,
                Address = address,
                PhoneNumber = phoneNumber,
                Email = email,
                Username = username,
                Password = password
            };
        }
        public void GetUpdateMemberInput(out string memberId)
        {
            Console.WriteLine("Enter Member ID to update:");
            memberId = Console.ReadLine();
        }
        public string GetMemberIdForRemoval()
        {
            Console.WriteLine("Enter Member ID to remove:");
            return Console.ReadLine();
        }
        #endregion
        // Librarian Function
        #region
        public void DisplayAllLibrarian(List<Librarian> librarianList)
        {
            Console.WriteLine("---- List of Librarians ----");

            // Define column widths for better alignment
            int idWidth = 5;
            int nameWidth = 17;
            int ageWidth = 5;
            int genderWidth = 10;
            int dobWidth = 15;
            int addressWidth = 27;
            int phoneWidth = 15;
            int emailWidth = 25;
            int roleWidth = 15;
            // Print table headers
            Console.WriteLine(
                $"{"ID".PadRight(idWidth)}{"Name".PadRight(nameWidth)}{"Age".PadRight(ageWidth)}{"Gender".PadRight(genderWidth)}{"DOB".PadRight(dobWidth)}{"Address".PadRight(addressWidth)}{"Phone Number".PadRight(phoneWidth)}{"Email".PadRight(emailWidth)}{"Role".PadRight(roleWidth)}"
            );

            foreach (var librarian in librarianList)
            {
                // Print each librarian's details
                Console.WriteLine(
                    $"{librarian.Id.PadRight(idWidth)}{librarian.Name.PadRight(nameWidth)}{librarian.Age.ToString().PadRight(ageWidth)}{librarian.Gender.PadRight(genderWidth)}{librarian.DateOfBirth.ToString("yyyy-MM-dd").PadRight(dobWidth)}{librarian.Address.PadRight(addressWidth)}{librarian.PhoneNumber.PadRight(phoneWidth)}{librarian.Email.PadRight(emailWidth)}{librarian.Role.PadRight(roleWidth)}"
                );
            }

            Screen.WaitScreen();
        }

        public void DisplayLibrarianDetails(Librarian librarian)
        {
            if (librarian != null)
            {
                Console.WriteLine("---- Librarian Details ----");

                // Define column widths for better alignment
                int labelWidth = 15;
                int valueWidth = 30;

                // Display librarian details with label and value aligned
                Console.WriteLine($"{"ID:".PadRight(labelWidth)}{librarian.Id.PadRight(valueWidth)}");
                Console.WriteLine($"{"Name:".PadRight(labelWidth)}{librarian.Name.PadRight(valueWidth)}");
                Console.WriteLine($"{"Age:".PadRight(labelWidth)}{librarian.Age.ToString().PadRight(valueWidth)}");
                Console.WriteLine($"{"Gender:".PadRight(labelWidth)}{librarian.Gender.PadRight(valueWidth)}");
                Console.WriteLine($"{"Date of Birth:".PadRight(labelWidth)}{librarian.DateOfBirth.ToString("yyyy-MM-dd").PadRight(valueWidth)}");
                Console.WriteLine($"{"Address:".PadRight(labelWidth)}{librarian.Address.PadRight(valueWidth)}");
                Console.WriteLine($"{"Phone Number:".PadRight(labelWidth)}{librarian.PhoneNumber.PadRight(valueWidth)}");
                Console.WriteLine($"{"Email:".PadRight(labelWidth)}{librarian.Email.PadRight(valueWidth)}");
                Console.WriteLine($"{"Role:".PadRight(labelWidth)}{librarian.Role.PadRight(valueWidth)}");
            }
            else
            {
                Console.WriteLine("Librarian not found.");
            }

            Screen.WaitScreen();
        }
        public Librarian GetNewLibrarianInput()
        {
            Console.WriteLine("Enter Librarian ID:");
            string id = Console.ReadLine();

            Console.WriteLine("Enter Librarian Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Librarian Age:");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Librarian Gender:");
            string gender = Console.ReadLine();

            Console.WriteLine("Enter Librarian Date of Birth (YYYY-MM-DD):");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Librarian Address:");
            string address = Console.ReadLine();

            Console.WriteLine("Enter Librarian Phone Number:");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter Librarian Email:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter Librarian Username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter Librarian Password:");
            string password = Console.ReadLine();

            Console.WriteLine("Enter Librarian Role:");
            string role = Console.ReadLine();

            return new Librarian
            {
                Id = id,
                Role = "librarian",
                Name = name,
                Age = age,
                Gender = gender,
                DateOfBirth = dateOfBirth,
                Address = address,
                PhoneNumber = phoneNumber,
                Email = email,
                Username = username,
                Password = password,
            };
        }
        public void GetUpdateLibrarianInput(out string librarianId)
        {
            Console.WriteLine("Enter Librarian ID to update:");
            librarianId = Console.ReadLine();
        }
        #endregion

        public static void StaffMenu(StaffControl staffControl, StaffView staffView, LibrarianControl librarianControl, MemberControl memberControl)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("       Main Management Menu        ");
                Console.WriteLine("====================================");
                Console.WriteLine($"| 1. Staff Management              |");
                Console.WriteLine($"| 2. Librarian Management          |");
                Console.WriteLine($"| 3. Member Management             |");
                Console.WriteLine($"| 4. Exit                          |");
                Console.WriteLine("====================================");
                Console.Write("Choose an option (1-4): ");


                string mainChoice = Console.ReadLine();

                switch (mainChoice)
                {
                    case "1":
                        StaffManagement(staffControl, staffView);
                        break;
                    case "2":
                        LibrarianManagement(librarianControl, staffView);
                        break;
                    case "3":
                        MemberManagement(memberControl, staffView);
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        public static void StaffManagement(StaffControl staffControl, StaffView staffView)
        {
            bool staffExit = false;
            while (!staffExit)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("       Staff Management             ");
                Console.WriteLine("====================================");
                Console.WriteLine($"| 1. Add Staff                     |");
                Console.WriteLine($"| 2. Update Staff                  |");
                Console.WriteLine($"| 3. Remove Staff                  |");
                Console.WriteLine($"| 4. Display All Staff             |");
                Console.WriteLine($"| 5. Search Staff by ID            |");
                Console.WriteLine($"| 6. Back to Main Menu             |");
                Console.WriteLine("====================================");
                Console.Write("Choose an option (1-6): ");


                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Staff newStaff = staffView.GetNewStaffInput();
                        staffControl.AddPerson(newStaff);
                        Screen.DisplaySuccessMessage("Staff added successfully.");
                        break;

                    case "2":
                        staffView.GetUpdateStaffInput(out string staffId);
                        staffControl.UpdatePersonById(staffId);
                        Screen.DisplaySuccessMessage("Staff updated successfully.");
                        break;

                    case "3":
                        Console.WriteLine("Enter Staff ID to remove:");
                        string staffIdToRemove = Console.ReadLine();
                        staffControl.RemovePersonById(staffIdToRemove);
                        Screen.DisplaySuccessMessage("Staff removed successfully.");
                        break;

                    case "4":
                        staffView.DisplayAllStaff(staffControl.GetPersonList());
                        break;

                    case "5":
                        Console.WriteLine("Enter Staff ID to search:");
                        string searchStaffId = Console.ReadLine();
                        staffView.DisplayStaffDetails(staffControl.GetPersonById(searchStaffId));
                        break;

                    case "6":
                        staffExit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        public static void LibrarianManagement(LibrarianControl librarianControl, StaffView staffView)
        {
            bool librarianExit = false;
            while (!librarianExit)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("      Librarian Management          ");
                Console.WriteLine("====================================");
                Console.WriteLine($"| 1. Add Librarian                 |");
                Console.WriteLine($"| 2. Update Librarian              |");
                Console.WriteLine($"| 3. Remove Librarian              |");
                Console.WriteLine($"| 4. Display All Librarians        |");
                Console.WriteLine($"| 5. Search Librarian by ID        |");
                Console.WriteLine($"| 6. Back to Main Menu             |");
                Console.WriteLine("====================================");
                Console.Write("Choose an option (1-6): ");


                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Add Librarian
                        Librarian newLibrarian = staffView.GetNewLibrarianInput();
                        librarianControl.AddPerson(newLibrarian);
                        Screen.DisplaySuccessMessage("Librarian added successfully.");
                        break;

                    case "2":
                        // Update Librarian (Get all update details)
                        staffView.GetUpdateLibrarianInput(out string librarianId);
                        librarianControl.UpdatePersonById(librarianId);
                        Screen.DisplaySuccessMessage("Librarian updated successfully.");
                        break;

                    case "3":
                        // Remove Librarian
                        Console.WriteLine("Enter Librarian ID to remove:");
                        string librarianIdToRemove = Console.ReadLine();
                        librarianControl.RemovePersonById(librarianIdToRemove);
                        Screen.DisplaySuccessMessage("Librarian removed successfully.");
                        break;

                    case "4":
                        // Display all Librarians
                        staffView.DisplayAllLibrarian(librarianControl.GetPersonList());
                        break;

                    case "5":
                        // Search Librarian by ID
                        Console.WriteLine("Enter Librarian ID to search:");
                        string searchLibrarianId = Console.ReadLine();
                        staffView.DisplayLibrarianDetails(librarianControl.GetPersonById(searchLibrarianId));
                        break;

                    case "6":
                        librarianExit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        public static void MemberManagement(MemberControl memberControl, StaffView staffView)
        {
            bool memberExit = false;
            while (!memberExit)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("        Member Management           ");
                Console.WriteLine("====================================");
                Console.WriteLine($"| 1. Add Member                    |");
                Console.WriteLine($"| 2. Update Member                 |");
                Console.WriteLine($"| 3. Remove Member                 |");
                Console.WriteLine($"| 4. Display All Members           |");
                Console.WriteLine($"| 5. Search Member by ID           |");
                Console.WriteLine($"| 6. Back to Main Menu             |");
                Console.WriteLine("====================================");
                Console.Write("Choose an option (1-6): ");


                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter Member Details:");
                        Member newMember = staffView.GetNewMemberInput();
                        memberControl.AddPerson(newMember);
                        Screen.DisplaySuccessMessage("Member added successfully.");
                        break;

                    case "2":
                        Console.WriteLine("Enter Member ID and new membership level:");
                        staffView.GetUpdateMemberInput(out string memberId);
                        memberControl.UpdatePersonById(memberId);
                        Screen.DisplaySuccessMessage("Member updated successfully.");
                        break;

                    case "3":
                        Console.WriteLine("Enter Member ID to remove:");
                        string memberIdToRemove = Console.ReadLine();
                        memberControl.RemovePersonById(memberIdToRemove);
                        Screen.DisplaySuccessMessage("Member removed successfully.");
                        break;

                    case "4":
                        staffView.DisplayAllMembers(memberControl.GetPersonList());
                        break;

                    case "5":
                        Console.WriteLine("Enter Member ID to search:");
                        string searchMemberId = Console.ReadLine();
                        staffView.DisplayMemberDetails(memberControl.GetPersonById(searchMemberId));
                        break;

                    case "6":
                        memberExit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }
    }
}
