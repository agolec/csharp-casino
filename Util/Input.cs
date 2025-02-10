using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Util
{
    internal class Input
    {
        public static int GetNumberFromInput(string prompt, string errorMessage)
        {
            int number;
            do
            {
                Console.Write(prompt);
                if(int.TryParse(Console.ReadLine(), out number))
                {
                    return number;
                }
                Console.WriteLine(errorMessage);
            } while (true);
        }
    }
}
