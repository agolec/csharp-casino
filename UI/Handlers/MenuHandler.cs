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

        public MenuHandler()
        {
            InitializeMenus();
        }
        private void InitializeMenus()
        {
            _mainMenu = new Menu("Casino", "Play Solitare", "Play Slots");
        }

        public int GetMainMenuSelection()
        {
            return _mainMenu.GetUserSelection();
        }

    }
}
