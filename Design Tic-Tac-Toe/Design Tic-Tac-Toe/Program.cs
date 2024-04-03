using System;
using System.Collections.Generic;

namespace Design_Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player> { new Player("sunil",new PieceX()), new Player("Anil", new PieceO())};
            Game game = new Game(3,players,3);
            Console.WriteLine(game.startGame());
        }
    }
}
