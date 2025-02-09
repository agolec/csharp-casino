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
        ConsoleKeyInfo mainMenuOption;
      
        public Game(Player player, MenuHandler menuHandler)
        {
            this._player = player;
            this._menuHandler = menuHandler;

        }

        public void Run()
        {
            bool running = true;
            string userInput;
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
            SlotLoop();
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
    }
}
