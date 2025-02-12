using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Util
{
    internal class Input
    {
        public static int GetNumberFromInput(string prompt)
        {
            int number;
            do
            {
                Console.Write(prompt);
                if(int.TryParse(Console.ReadLine(), out number))
                {
                    return number;
                }
                Console.WriteLine("Error: unable to parse input into a number.");
            } while (true);
        }
    }
}
