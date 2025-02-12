using Casino.Loop;
using Casino.UI.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.UI.Handlers
{
    internal class MenuHandler
    {
        private Menu _mainMenu;
        private Menu _slotsMenu;
        private Menu _statsMenu;

        public MenuHandler()
        {
            InitializeMenus();
        }
        private void InitializeMenus()
        {
            _mainMenu = new Menu("Casino", "Play Solitare", "Play Slots");
            _slotsMenu = new Menu("Play Slots",false,"Place Bet", "View Payout Table", "Check Stats", "Change Bet Amount", "Auto-Spin", "Exit to Main Menu");
            _statsMenu = new Menu("Stats", false, "Return to Game");
        }

        public int GetMainMenuSelection()
        {
            return _mainMenu.GetUserSelection();
        }
        public int GetSlotsMenuSelection()
        {
            return _slotsMenu.GetUserSelection();
        }
        public int GetStatsMenuSelection()
        {
            return _statsMenu.GetUserSelection();
        }

        public bool RunMainMenu(Game game)
        {
            switch (this.GetMainMenuSelection())
            {
                case (int)MainMenuOptions.SOLITARE:
                    Console.WriteLine("ToDo: make Solitare game.");
                    return true;
                case (int)MainMenuOptions.SLOTS:
                    Console.WriteLine("going to play slots.");
                    game.PlaySlots();
                    return true;
                case (int)MainMenuOptions.EXIT:
                    Console.WriteLine("Exiting program.");
                    return false;
                default:
                    Console.WriteLine("Invalid selection.");
                    return true;
            }
        }
        public void RunSlotsMenu(SlotsGame slotGame)
        {
            bool running = true;
            while (running)
            {
                switch (this.GetSlotsMenuSelection())
                {
                    case (int)SlotsMenuOptions.PLACE_BET:
                        Console.WriteLine("Going to place bet;");
                        slotGame.Bet = slotGame.PromptForUserBet();
                        Console.WriteLine(slotGame.DisplayBet());
                        break;
                    case (int)SlotsMenuOptions.CHECK_STATS:
                        Console.WriteLine("Checking stats");
                        this.HandleStatsMenu();
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
                    case (int)SlotsMenuOptions.PULL_LEVER:
                        slotGame.PullLever();
                        break;
                    case (int)SlotsMenuOptions.EXIT_TO_MAIN_MENU:
                        running = false;
                        break;
                }
            }
        }
        public void HandleStatsMenu()
        {
            while (true)
            {
                if(_statsMenu.GetUserSelection() == (int)StatsMenuOptions.RETURN_TO_GAME)
                {
                    break;
                }
            }
        }
    }
}
