using Casino.PlayerNamespace;
using Casino;
using System.Runtime.ExceptionServices;
namespace Casino
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(100);
            SlotMachine slots = new SlotMachine();

            for (int i = 0; i < 10; i++)
            {
                if (slots.ValidWager(player, 10))
                {
                    Console.WriteLine("Spinning " + (i + 1) + " time");
                    slots.SpinReels();
                }
                else
                {
                    Console.WriteLine("invalid wager.");
                }
                Console.WriteLine();
            }
            
        }
    }
}
