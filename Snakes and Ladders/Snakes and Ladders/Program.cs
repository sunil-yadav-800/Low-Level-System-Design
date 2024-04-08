using System;
using System.Collections.Generic;

namespace Snakes_and_Ladders
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>
            {
                new Player("sunil"),
                new Player("anil")
            };
            Game game = new Game(10,1,1,6,players,5,6);
            List<string> winners =  game.Play();

            Console.WriteLine("winners are: ");
            foreach(var winner in winners)
            {
                Console.Write(winner);
            }
        }
    }
}
