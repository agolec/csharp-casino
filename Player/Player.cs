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
        public Player(int bankAmount)
        {
            this.bank = bankAmount;
        }
        public bool playerBankEmpty()
        {
            return bank == 0;
        }
    }
}
