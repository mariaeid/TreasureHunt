using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    class SupportingMethods
    {
        //Method that clears previous output provided to the user
        public static void ClearOutputLine(int clearY)
        {
            Console.SetCursorPosition(0, clearY);
            Console.WriteLine(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, clearY);
        }

        //Method to verify that the user input is a number and convert the number to an int
        public static int ReadNumber(string prompt)
        {
            while (true)
            {
                Console.SetCursorPosition(0, 14);
                Console.WriteLine(prompt);
                var input = Console.ReadLine();
                int value;

                if (Int32.TryParse(input, out value))
                {
                    ClearOutputLine(15);
                    ClearOutputLine(17);
                    return value;
                }

                else
                {
                    ClearOutputLine(15);
                    ClearOutputLine(17);
                    Console.WriteLine("Not a number.");
                }
            }
        }
    }
}
