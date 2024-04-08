using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakes_and_Ladders
{
    class Game
    {
        Board board;
        Dice dice;
        Queue<Player> players;
        public Game(int size, int noOfDices, int diceMinValue, int diceMaxValue, List<Player> noOfPlayers, int noOfSnakes, int noOfLadders)
        {
            board = new Board(size);
            dice = new Dice(noOfDices, diceMinValue, diceMaxValue);
            players = new Queue<Player>();
            foreach(Player player in noOfPlayers)
            {
                players.Enqueue(player);
            }
            board.addSnakesAndLadders(noOfSnakes, noOfLadders);

        }
        public List<string> Play()
        {
            List<string> winners = new List<string>();
            try
            {
                while (true)
                {
                    Player currPlayer = players.Dequeue();
                    int diceValue = dice.roll();
                    Console.WriteLine("--------------------------");
                    Console.WriteLine(currPlayer.Name + ": Turn");
                    Console.WriteLine("current position: " + currPlayer.Postion);
                    Console.WriteLine(currPlayer.Name + ": rolled dice and got value: " + diceValue);
                    int nextPosition = findNextPostion(currPlayer.Postion + diceValue, currPlayer);
                    currPlayer.Postion = nextPosition;
                    Console.WriteLine("new position: " + currPlayer.Postion);
                    if (nextPosition == board.Size * board.Size - 1)
                    {
                        winners.Add(currPlayer.Name);
                        Console.WriteLine(currPlayer.Name + ": reached end");
                    }
                    else
                    {
                        players.Enqueue(currPlayer);
                    }
                    if (players.Count < 2)
                    {
                        break;
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return winners;
        }
        private int findNextPostion(int newPosition, Player player)
        {
            if(newPosition >= board.Size * board.Size)
            {
                return player.Postion;
            }
            Cell cell = board.getCell(newPosition);
            if(cell!=null && cell.Jump!=null && cell.Jump.Start == newPosition)
            {
                if (cell.Jump.Start > cell.Jump.End)
                {
                    Console.WriteLine("Got bitten by a Snake");
                }
                else if(cell.Jump.Start < cell.Jump.End)
                {
                    Console.WriteLine("Got jump by a ladder");
                }
                return cell.Jump.End;
            }
            return newPosition;
        }
    }
}
