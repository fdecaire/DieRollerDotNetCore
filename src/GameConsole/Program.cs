using DieRollerLibrary;
using GameLibrary;

namespace GameConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
	        var game = new Game(new DieRoller());
        }
    }
}
