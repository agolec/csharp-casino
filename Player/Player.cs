using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.PlayerNamespace
{
    public class Player
    {
        public int bank { set; get; }
        public int bet { set; get; }
        public Player(int bankAmount)
        {
            this.bank = bankAmount;
        }
        public bool playerBankEmpty()
        {
            return bank == 0;
        }
        public bool negativeBet(int betAmount)
        {
            return (betAmount < 0);
        }
        public bool validBet(int betAmount)
        {
            if (this.playerBankEmpty())
            {
                Console.WriteLine($"Invalid bet: player bank empty.");
                return false;
            }
            if (negativeBet(betAmount))
            {
                Console.WriteLine($"Invalid bet: bet '{betAmount}' is negative.");
                return false;
            }
            else if (betAmount > this.bank)
            {
                Console.WriteLine($"Invalid bet: bet amount '{betAmount}' is greater than player bank: '{this.bank}'.");
                return false;
            }
            else return true;
        }
        public void deductBet(int betAmount) {
            this.bank -= betAmount;
        }
       

    }
}
