using Casino.PlayerNamespace;
using Casino.UI;
namespace Casino
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu mainMenu = new Menu();
            Player player = new Player(100);
            SlotMachine slots = new SlotMachine();

            mainMenu.DisplayMenu();

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
