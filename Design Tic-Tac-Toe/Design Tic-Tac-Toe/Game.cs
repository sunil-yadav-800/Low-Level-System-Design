using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Tic_Tac_Toe
{
    class Game
    {
        Board board;
        List<Player> players;
        Queue<Player> q;
        int matchedCondition;
        public Game(int boardSize, List<Player> players, int matchedCondition)
        {
            initializeGame(boardSize, players, matchedCondition); 
        }
        private void initializeGame(int boardSize, List<Player> players, int matchedCondition)
        {
            board = new Board(boardSize);
            this.players = players;
             q = new Queue<Player>();
            foreach (var player in players)
            {
                q.Enqueue(player);
            }
            this.matchedCondition = matchedCondition;
        }
        public string startGame()
        {
            while(true)
            {
                //display board
                board.display();

                //check any cell is free or not
                bool isAllCellFilled =  board.isAllCellFilled();
                if(isAllCellFilled)
                {
                    return "Tie";
                }

                Player currPlayer = q.Peek();
                Console.WriteLine(currPlayer.Name + ": Enter row,col where you want to put your piece ");
                string inputValues = Console.ReadLine();
                string[] inputArray = inputValues.Split(",");
                int row = int.Parse(inputArray[0]);
                int col = int.Parse(inputArray[1]);
                //put you piece at row,col
                bool addedPiece = board.addPiece(row, col, currPlayer);

                //if piece is not added than currPlayer can try with different position.
                if(!addedPiece)
                {
                    Console.WriteLine(currPlayer.Name + ": given wrong value, Please try again!");
                    continue;
                }
                //if piece is added to that location
                //check currPlayer is winner or not
                bool isWinner = board.isCurrPlayerWinner(row, col, currPlayer, matchedCondition);
                if(isWinner)
                {
                    return "Whoo! " + currPlayer.Name + " is the winner";
                }
                //if curr player is not winner than next player has to play next
                q.Dequeue();
                //put the currPlayer at the end
                q.Enqueue(currPlayer);

            }
        }
    }
}
