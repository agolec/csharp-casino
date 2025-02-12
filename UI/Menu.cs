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
        private string _title { set; get; }
        private char _borderCharacter { get; set; }
        private int _longestMenuOption { get; set; }
        private bool _quitOption { get; set; }
        /// <summary>
        /// Menu constructor which adds an implicit Quit option.
        /// </summary>
        /// <param name="title">Title of your menu</param>
        /// <param name="menuOptions">Options in your menu. This constructor will add a "Quit" option as the final menu choice.</param>
        public Menu(string title, params string[] menuOptions)
        {
            this._menuOptions = new List<string>();
            this._borderCharacter = '=';
            this._title = title;
            InitializeMenu(true, menuOptions);
            this._longestMenuOption = GetLongestLineLength();
        }
        public Menu(string title, bool quitOption,params string[] menuOptions) {
            this._menuOptions = new List<string>();
            this._borderCharacter = '=';
            this._title = title;
            InitializeMenu(quitOption,menuOptions);
        }
        //public Menu(char borderCharacter, params string[] menuOptions)
        //{
        //    this._menuOptions = new List<string>();
        //    this._borderCharacter = borderCharacter;
        //}
        public void PrintTitle()
        {
            Console.WriteLine(this._title);
        }
        private void DisplayMenu()
        {

            PrintTitle();
            PrintBorder(this._borderCharacter, this._longestMenuOption);
            for (int i = 0; i < this._menuOptions.Count; i++)
            {
                Console.WriteLine($"{(i+1)}) {this._menuOptions[i]}");
            }
            if (this._quitOption)
            {
                Console.WriteLine($"Q/quit to quit) {this._menuOptions[(this._menuOptions.Count - 1)]}");

            }
            PrintBorder(this._borderCharacter,this._longestMenuOption);
        }
        public void PrintBorder(char borderCharacter, int longestLineLength)
        {
            Console.Write(" ");
            for(int i = 0; i < (longestLineLength); i++)
            {
                Console.Write(borderCharacter);
            }
            Console.Write(" ");
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
        public void InitializeMenu(bool quit, params string[] menuOptions)
        {
            foreach (var option in menuOptions)
            {
                this._menuOptions.Add(option);
            }
            if (quit)
            {
                this._menuOptions.Add("quit");
                this._quitOption = true;
            }
            else { 
                this._quitOption = false;
            }
        }
        public int GetUserSelection()
        {
            
            bool hasQuitOption = _menuOptions.Contains("quit");
            while (true)
            {
                
                DisplayMenu();
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine()?.Trim().ToLower();

                if (hasQuitOption &&
                    (input == "q" || input == "quit")){
                    Console.WriteLine("Exiting menu...");
                    return -1;
                }
                if(int.TryParse(input, out int choice) && choice >= 1 && choice <= _menuOptions.Count)
                {
                    return choice;
                }

                Console.WriteLine("Invalid selection. Please enter a valid number" + (hasQuitOption ? " or q or quit to quit." : "."));

            }
        }
    }
}
