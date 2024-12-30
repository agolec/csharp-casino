using System;
using System.Collections.Generic;
using Casino.PlayerNamespace;

namespace Casino
{
    internal class SlotMachine
    {
        const string FIRST_BRACKET = "FirstBracket";
        const string SECOND_BRACKET = "SecondBracket";
        const string THIRD_BRACKET = "ThirdBracket";
        const string FOURTH_BRACKET = "FourthBracket";
        const string FIFTH_BRACKET = "FifthBracket";
        const string SIXTH_BRACKET = "SixthBracket";
        const string SEVENTH_BRACKET = "SeventhBracket";

        private List<string> reelGraphics; // List of symbols represented by strings
        private int[,] reels;          // 3x3 grid for the reels
        private string[] symbolBounds;
        private int wager;
        private Dictionary<string, int> payoutOdds; // Winning combinations and their payout odds

        public SlotMachine()
        {
            this.reelGraphics = new List<string> { "!", "@", "#", "$", "%", "^","&","*"}; // Symbols for slot reels
            this.reels = new int[3, 3]; // 3x3 grid
            this.symbolBounds = ["[","]"];

            InitializeDictionary();
        }
        private void InitializeDictionary()
        {
            
            this.payoutOdds = new Dictionary<string,int>();
            this.payoutOdds.Add(FIRST_BRACKET, 50);
            this.payoutOdds.Add(SECOND_BRACKET, 150);
            this.payoutOdds.Add(THIRD_BRACKET, 350);
            this.payoutOdds.Add(FOURTH_BRACKET, 850);
            this.payoutOdds.Add(FIFTH_BRACKET, 1850);
            this.payoutOdds.Add(SIXTH_BRACKET, 3850);
            this.payoutOdds.Add(SEVENTH_BRACKET, 6850);
        }
        private String GetSymbol(int roll)
        {
            if (roll < this.payoutOdds[FIRST_BRACKET])
            {
                return this.reelGraphics[0];
            }
            else if (roll < this.payoutOdds[SECOND_BRACKET])
            {
                return this.reelGraphics[1];
            }
            else if (roll < this.payoutOdds[THIRD_BRACKET])
            {
                return this.reelGraphics[2];
            }
            else if (roll < this.payoutOdds[FOURTH_BRACKET])
            {
                return this.reelGraphics[3];
            }
            else if (roll < this.payoutOdds[FIFTH_BRACKET])
            {
                return this.reelGraphics[4];
            }
            else if (roll < this.payoutOdds[SIXTH_BRACKET])
            {
                return this.reelGraphics[5];
            }
            else
            {
                return this.reelGraphics[7];
            }
        }
        // Validate the wager
        public bool ValidWager(Player player, int wager)
        {
            return !(player.playerBankEmpty() || wager > player.bank);
        }

        // Spin the reels
        public void SpinReels()
        {
            Random rng = new Random();
            for(int i = 0; i < this.reels.GetLength(0); i++)
            {
                for(int j = 0;j < this.reels.GetLength(1); j++)
                {
                    this.reels[i, j] = rng.Next(6850);
                }
            }
            DisplayReels();
        }

        // Display the reels grid
        private void DisplayReels()
        {
            for (int i = 0; i < this.reels.GetLength(0); i++)
            {
                for (int j = 0; j < this.reels.GetLength(1); j++)
                {
                    Console.Write(this.symbolBounds[0]);
                    Console.Write(GetSymbol(this.reels[i, j]));
                    Console.Write(this.symbolBounds[1]);
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
      
            }
            
        }

        // Check all possible winning combinations
        private string CheckWinningCombinations()
        {
            return "";
        }

        // Check if three symbols match.
        private bool IsMatching(int a, int b, int c)
        {
            //Short-circuit the method. if a != b, then there is no match and we can leave immediately.
            if (a != b)
            {
                return false;
            }
            //If above check passes, we can check whether b is == to c, since it will be known that a == c by then.
            return b == c;
        }
    }
}
