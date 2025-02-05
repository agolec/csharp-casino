using Casino.Loop;
using Casino.PlayerNamespace;
using Casino.UI;
using System.Runtime.CompilerServices;
namespace Casino
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Menu mainMenu = new Menu(
                                "Casino",
                                "Play Solitaire",
                                "Play Slots");
        
        Player player = new Player(100);
        Game game = new Game(player, mainMenu);
        
        game.Run();
            
        }
    }
}
