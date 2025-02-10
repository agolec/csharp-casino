using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.PlayerNamespace;
using Casino.UI;
using Casino.UI.Menus;
using Casino.UI.Handlers;

namespace Casino.Loop
{
    internal class Game
    {
        private Player _player;
        private MenuHandler _menuHandler;
      
        public Game(Player player, MenuHandler menuHandler)
        {
            this._player = player;
            this._menuHandler = menuHandler;

        }

        public void Run()
        {
            bool running = true;
            do
            {

                switch (this._menuHandler.GetMainMenuSelection())
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
            DisplaySlotMenu();
        }

        private void SlotLoop()
        {
            SlotMachine slots = new SlotMachine();
            bool bankEmpty = this._player.playerBankEmpty();
            do
            {
                this._player.deductBet(slots.placeBet(this._player));
                slots.SpinReels();
            } while (!this._player.playerBankEmpty());

        }
        private void DisplaySlotMenu()
        {
            bool running = true;
            do
            {
                switch (_menuHandler.GetSlotsMenuSelection())
                {
                        case (int)SlotsMenuOptions.PLACE_BET:
                            Console.WriteLine("Going to place bet;");
                            SlotLoop();
                            break;
                        case (int)SlotsMenuOptions.CHECK_BALANCE:
                            Console.WriteLine("Checking balance: ");
                            break;
                        case (int)SlotsMenuOptions.VIEW_PAYOUT:
                            Console.WriteLine("Viewing payout...");
                            break;
                        case (int)SlotsMenuOptions.CHANGE_BET:
                            Console.WriteLine("Changing Bet");
                            break;
                        case (int)SlotsMenuOptions.AUTO_SPIN:
                            Console.WriteLine("Auto spin");
                            break;
                        case (int)SlotsMenuOptions.EXIT_TO_MAIN_MENU:
                            running = false;
                            break;
                }
            } while (running);
        }
    }
}
