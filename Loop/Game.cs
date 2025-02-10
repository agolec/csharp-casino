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
            while(running)
            {
                running = _menuHandler.RunMainMenu(this);
            }
        }
        public void PlaySlots()
        {
            _menuHandler.RunSlotsMenu(this);
            DisplaySlotMenu();
        }

        public void PullLever()
        {
            SlotMachine slots = new SlotMachine();
            while (!_player.playerBankEmpty())
            {
                _player.deductBet(slots.placeBet(_player));
                slots.SpinReels();
            }

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
                            PullLever();
                            break;
                        case (int)SlotsMenuOptions.CHECK_STATS:
                            Console.WriteLine("Checking stats");
                            DisplayStatsMenu();
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
        private void DisplayStatsMenu()
        {
            bool displayMenu = true;
            do
            {
                switch (_menuHandler.GetStatsMenuSelection())
                {
                    case (int)StatsMenuOptions.RETURN_TO_GAME:
                        displayMenu = false;
                        break;
                    default:
                        Console.WriteLine("Error: invalid menu input.");
                        break;
                }
            } while (displayMenu);
        }
    }
}
