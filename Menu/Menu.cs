using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.UI
{
    public class Menu
    {
        List<string> menuText;
        public Menu() {
            menuText = new List<string>();
            InitializeMenu();
        }
        public void DisplayMenu()
        {
            int longestLineLength = GetLongestLineLength();
            PrintBorder('=', longestLineLength);
            for (int i = 0; i < menuText.Count; i++)
            {
                Console.WriteLine(menuText[i]);
            }
            PrintBorder('=',longestLineLength);
        }
        public void PrintBorder(char borderCharacter, int longestLineLength)
        {
            for(int i = 0; i < longestLineLength; i++)
            {
                Console.Write(borderCharacter);
            }
            Console.WriteLine(); 
        }
        public int GetLongestLineLength()
        {
            int longestLine = 0;
            for(int i = 0; i < menuText.Count; i++)
            {
                if(longestLine < menuText[i].Length)
                {
                    longestLine = menuText[i].Length;
                }
            }
            return longestLine;
        }
        public void InitializeMenu()
        {
            menuText.Add("C A S I N O");
            menuText.Add("1. Play Solitaire");
            menuText.Add("2. (or Q). Quit");
        }
    }
}
