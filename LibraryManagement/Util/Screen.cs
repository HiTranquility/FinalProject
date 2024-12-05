using LibraryManagement.Controller;
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
        // Xử lý sự kiện khi người dùng nhấn Ctrl+C hoặc tắt cửa sổ console
        public static void OnCancel(object sender, ConsoleCancelEventArgs e)
        {
            // Chặn sự kiện tắt console và yêu cầu người dùng xác nhận lưu thay đổi
            e.Cancel = true; // Chặn hành động tắt console

            Console.WriteLine("\nBạn có muốn lưu thay đổi trước khi thoát? (yes/no)");
            string input = Console.ReadLine().ToLower();

            if (input == "yes")
            {
                Console.WriteLine("Đang lưu thay đổi...");
                Console.WriteLine("Thay đổi đã được lưu.");
            }
            else
            {
                Console.WriteLine("Chưa lưu thay đổi.");
            }

            Environment.Exit(0);  // Kết thúc chương trình
        }
    }
}
