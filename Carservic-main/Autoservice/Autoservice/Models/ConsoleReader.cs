using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoservice.Models
{
    static class ConsoleReader
    {
        public static int ReadInt(string printMessage)
        {
            int value;

            do
            {
                Console.Write(printMessage);
            }
            while (int.TryParse(Console.ReadLine(), out value) == false);

            return value;
        }

        public static string ReadString(string printMessage)
        {
            string value;

            do
            {
                Console.Write(printMessage);
                value = Console.ReadLine();
            }
            while (String.IsNullOrWhiteSpace(value) == true);

            return value;
        }
    }
}
