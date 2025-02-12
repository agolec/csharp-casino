using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using Casino.PlayerNamespace;
using Casino.Util;

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

        private enum WIN_LINES {
            FORWARD_SLASH,
            BACK_SLASH,
            TOP_ROW_ROW,
            MIDDLE_ROW,
            BOTTOM_ROW
        }

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
            return player.validBet(wager);
        }

        // Spin the reels
        public void SpinReels()
        {
            bool won = false;
            Random rng = new Random();
            for(int i = 0; i < this.reels.GetLength(0); i++)
            {
                for(int j = 0;j < this.reels.GetLength(1); j++)
                {
                    this.reels[i, j] = rng.Next(6850);
                }
            }
            DisplayReels();
            List<WIN_LINES> winnings = new List<WIN_LINES>();
            winnings = CheckWinningCombinations();
            if (winnings != null || winnings.Count != 0)
            {
                won = true;
            }
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
        private List<WIN_LINES> CheckWinningCombinations()
        {
            List<WIN_LINES> linesWon = new List<WIN_LINES>();
            if (IsMatching(this.reels[0, 0], this.reels[0, 1], this.reels[0, 2]))
            {
                linesWon.Add(WIN_LINES.TOP_ROW_ROW);
            }
            if (IsMatching(this.reels[1, 0], this.reels[1, 1], this.reels[1, 2]))
            {
                linesWon.Add(WIN_LINES.MIDDLE_ROW);
            }
            if (IsMatching(this.reels[2, 0], this.reels[2, 1], this.reels[2, 2]))
            {
                linesWon.Add(WIN_LINES.BOTTOM_ROW);
            }
            //Conditions for diagonals.
            if (IsMatching(this.reels[0, 0], this.reels[1, 1], this.reels[2, 2]))
            {
                linesWon.Add(WIN_LINES.FORWARD_SLASH);
            }
            if (IsMatching(this.reels[2,0], this.reels[1, 1],this.reels[0, 2]))
            {
                linesWon.Add(WIN_LINES.BACK_SLASH);
            }
            return linesWon;
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
        public int placeBet(Player player)
        {
            int bet = 0;
            bool validWager = false;
            PromptUntilBetIsValid(player, ref bet, ref validWager);
            return bet;
        }

        private void PromptUntilBetIsValid(Player player, ref int bet, ref bool validWager)
        {
            do
            {
                bet = GetBetInput(player);
                if (player.validBet(bet)){
                    Console.WriteLine("Valid bet made.");
                    validWager = true;
                }
            } while (!validWager);
        }

        private int GetBetInput(Player player)
        {
            String prompt = "Place your bet: ";
            String errorMessage = "Error: Bet must be numeric.";

            int bet = Input.GetNumberFromInput(prompt);

            return bet;
        }
        public void PayoutToPlayer()
        {
            //todo
        }
    }
}
