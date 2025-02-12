using Casino.PlayerNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Casino.Loop
{
    internal class SlotsGame
    {
        private Player _player { set; get; }
        private SlotMachine _slotMachine;
        private int _turnNumber;
        private int bet;
        public int Bet {
            get => bet;
            set
            {
                if(value < 0)
                {
                    Console.WriteLine("Bet not set. Negative value given.");
                    return;
                }
                if (this._slotMachine.ValidWager(this._player, value))
                {
                    bet = value;
                }
                else
                {
                    Console.WriteLine("Invalid wager. Bet not set.");
                }
            }   
        }
        public int Turn
        {
            get { return _turnNumber; }
        }
        

        public SlotsGame(Player player,SlotMachine slotMachine)
        {
            if(player == null)
            {
                throw new ArgumentNullException("Error: player is null.");
            }
            this._player = player;
            if(slotMachine == null)
            {
                throw new ArgumentNullException("Error: Slot machine is null");
            }
            this._slotMachine = slotMachine;
            this._turnNumber = 1;
        }
        public void PullLever()
        {
            this._slotMachine.SpinReels();
        }
        public int PromptForUserBet()
        {
            return Util.Input.GetNumberFromInput("Enter your bet: ");
        }
        public String DisplayBet()
        {
            return $"Current bet: {Bet}";
        }
        public override string ToString()
        {
            return String.Empty;
        }
    }
}
