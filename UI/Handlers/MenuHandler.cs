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
            _slotsMenu = new Menu("Play Slots",false,"Place Bet", "View Payout Table", "Check Balance", "Change Bet Amount", "Auto-Spin", "Exit to Main Menu");
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

    }
}
