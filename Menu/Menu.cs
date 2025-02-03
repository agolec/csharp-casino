using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.UI
{
    public class Menu
    {
        private List<string> _menuOptions;
        private char _borderCharacter { get; set; }
        public Menu(string title, params string[] menuOptions)
        {
            this._menuOptions = new List<string>();
            this._borderCharacter = '=';
            InitializeMenu(title, true, menuOptions);
        }
        public Menu(string title, bool quitOption,params string[] menuOptions) {
            this._menuOptions = new List<string>();
            this._borderCharacter = '=';
            InitializeMenu(title, quitOption,menuOptions);
        }
        public Menu(char borderCharacter, params string[] menuOptions)
        {
            this._menuOptions = new List<string>();
            this._borderCharacter = borderCharacter;
        }
        public void DisplayMenu()
        {
            int longestLineLength = GetLongestLineLength();
            PrintBorder(this._borderCharacter, longestLineLength);
            for (int i = 0; i < _menuOptions.Count; i++)
            {
                Console.WriteLine(_menuOptions[i]);
            }
            PrintBorder(this._borderCharacter,longestLineLength);
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
            for(int i = 0; i < _menuOptions.Count; i++)
            {
                if(longestLine < _menuOptions[i].Length)
                {
                    longestLine = _menuOptions[i].Length;
                }
            }
            return longestLine;
        }
        public void InitializeMenu(string title, bool quit, params string[] menuOptions)
        {
            this._menuOptions.Add(title);
            foreach (var option in menuOptions)
            {
                this._menuOptions.Add(option);
            }
            if (quit)
            {
                this._menuOptions.Add("Q: quit");
            }
        }
    }
}
