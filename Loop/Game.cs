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
    }
}
