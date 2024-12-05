using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Util
{
    internal class Screen
    {
        public static void WaitScreen()
        {
            Console.WriteLine("Press any key to continue to exit!...");
            Console.ReadKey(); 
        }
        public static void DisplaySuccessMessage(string message)
        {
            Console.WriteLine(message);
            Screen.WaitScreen();
        }
        public static void DisplayErrorMessage(string message)
        {
            Console.WriteLine("Error: " + message);
            Screen.WaitScreen();
        }
    }
}
