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
        Dictionary<MainMenuOptions, ConsoleKey> validMenuKeys;
        private enum MainMenuOptions
        {
            SLOTS,
            EXIT
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
                            "1. Play Solitaire",
                            "2. (or Q) to quit");
        }

        public void InitializeValidMenuKeys()
        {
            this.validMenuKeys = new Dictionary<MainMenuOptions, ConsoleKey>();
            this.validMenuKeys.Add(MainMenuOptions.SLOTS, ConsoleKey.D1);
            this.validMenuKeys.Add(MainMenuOptions.EXIT, ConsoleKey.Q);
        }
        public void Run()
        {
            bool running = true;
            string userInput;
            do
            {
                mainMenu.DisplayMenu();
                userInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(userInput))
                {
                    switch (userInput.ToLower())
                    {
                        case "1":
                        case "one":
                            PlaySlots();
                            break;
                        case "q":
                        case "quit":
                            running = false;
                            break;
                    }

                }
            } while (running);
        }
        void PlaySlots()
        {
            SlotMachine slots = new SlotMachine();
            placeBet(slots);
        }
        int placeBet(SlotMachine slots)
        {
            int bet;
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
