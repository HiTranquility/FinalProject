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
            Console.ReadKey();  // Dừng lại cho đến khi người dùng nhấn một phím
        }
    }
}
