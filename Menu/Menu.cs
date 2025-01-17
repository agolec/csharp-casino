using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.UI
{
    public class Menu
    {
        private List<string> menuText;
        private char borderCharacter { get; set; }
        public Menu(params string [] menuOptions) {
            menuText = new List<string>();
            this.borderCharacter = '=';
            InitializeMenu(menuOptions);
        }
        public Menu(char borderCharacter, params string[] menuOptions)
        {
            menuText = new List<string>();
            this.borderCharacter = borderCharacter;

        }
        public void DisplayMenu()
        {
            int longestLineLength = GetLongestLineLength();
            PrintBorder(this.borderCharacter, longestLineLength);
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
        public void InitializeMenu(params string[] menuOptions)
        {
            foreach (var option in menuOptions)
            {
                this.menuText.Add(option);
            }
        }
    }
}
