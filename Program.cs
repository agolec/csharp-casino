using Casino.Loop;
using Casino.PlayerNamespace;
using Casino.UI;
using Casino.UI.Handlers;
using System.Runtime.CompilerServices;
namespace Casino
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        Player player = new Player(100);
        MenuHandler menuHandler = new MenuHandler();
        Game game = new Game(player, menuHandler);
        
        game.Run();
            
        }
    }
}
