using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.PlayerNamespace;
using Casino.UI;

namespace Casino.Loop
{
    internal class Game
    {
        Player player;
        Menu mainMenu;
        ConsoleKeyInfo mainMenuOption;
        private enum MainMenuOptions
        {
            SOLITARE = 1,
            SLOTS = 2,
            EXIT = 3
        }
        public Game(Player player)
        {
            this.player = player;
            InitilizeMainMenu();

        }

        private void InitilizeMainMenu()
        {
            this.mainMenu = new Menu(
                            "Casino",
                            "Play Solitaire",
                            "Play Slots");
        }

        
        public void Run()
        {
            bool running = true;
            string userInput;
            do
            {

                switch (this.mainMenu.GetUserSelection())
                {
                    case (int)MainMenuOptions.SOLITARE:
                        Console.WriteLine("ToDo: make Solitare game.");
                        break;
                    case (int)MainMenuOptions.SLOTS:
                        Console.WriteLine("going to play slots.");
                        PlaySlots();
                        break;
                    case (int)MainMenuOptions.EXIT:
                        Console.WriteLine("Exiting program.");
                        running = false;
                        break;
                }
            } while (running);
        }
        void PlaySlots()
        {
            //SlotMachine slots = new SlotMachine();
            //placeBet(slots);
            Console.WriteLine("ToDo: implement slots.");
        }
        public int placeBet(SlotMachine slots)
        {
            int bet = 0;
            bool validWager = false;
            Console.WriteLine("Place your bet: ");
            do
            {
                try
                {
                    bet = int.Parse(Console.ReadLine());
                    if (slots.ValidWager(this.player, bet)){
                        validWager = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid wager.");
                        Console.WriteLine("Place your bet: ");
                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error: bet must be numeric");
                    Console.WriteLine("Place your bet: ");
                }
            } while (!validWager);
            return bet;
        }
    }
}
