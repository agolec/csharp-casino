using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.PlayerNamespace;
using Casino.UI;
using Casino.UI.Menus;
using Casino.UI.Handlers;
using Casino.Loop;

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
            SlotMachine machine = new SlotMachine();
            SlotsGame slotsGame = new SlotsGame(_player, machine);
            _menuHandler.RunSlotsMenu(slotsGame);
        }
    }
}
