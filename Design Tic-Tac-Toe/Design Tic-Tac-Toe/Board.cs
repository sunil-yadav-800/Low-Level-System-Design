using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Tic_Tac_Toe
{
    class Board
    {
        private Piece[,] board { get; set; }
        private int size;
        public Board(int size)
        {
            this.size = size;
            board = new Piece[size,size];
        }
        public void display()
        {
            Console.WriteLine("-------------------------------");
            for(int row=0;row<size;row++)
            {
                for(int col=0;col<size;col++)
                {
                    Console.Write(" | " + (board[row, col] == null ? " " : board[row, col].pieceType.ToString()));
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------");
        }
        public bool isAllCellFilled()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (board[row, col] == null)
                        return false;
                }
            }
            return true;
        }
        public bool addPiece(int row, int col, Player player)
        {
            if (board[row, col] != null)
                return false;

            board[row, col] = player.piece;
            return true;
        }
        public bool isCurrPlayerWinner(int row, int col, Player player, int matched)
        {
            //check for row
            int count = 0;
            int currCol = col;
            while (currCol >= 0 && board[row, currCol] == player.piece)
            {
                count++;
                currCol--;
            }
            currCol = col+1;
            while (currCol < size && board[row, currCol] == player.piece)
            {
                count++;
                currCol++;
            }
            if (count >= matched)
                return true;

            //check for columns
            count = 0;
            int currRow = row;
            while(currRow>=0 && board[currRow,col] == player.piece)
            {
                count++;
                currRow--;
            }
            currRow = row+1;
            while(currRow<size && board[currRow,col] == player.piece)
            {
                count++;
                currRow++;
            }
            if (count >= matched)
                return true;

            //check for diagonal
            currRow = row;
            currCol = col;
            count = 0;
            while(currRow>=0 && currCol>=0  && board[currRow,currCol] == player.piece)
            {
                count++;
                currRow--;
                currCol--;
            }
            currRow = row + 1;
            currCol = col + 1;
            while(currRow<size && currCol<size && board[currRow,currCol] == player.piece)
            {
                count++;
                currRow++;
                currCol++;
            }
            if (count >= matched)
                return true;

            //check for antidiagonal
            currRow = row;
            currCol = col;
            count = 0;
            while(currRow>=0 && currCol<size && board[currRow,currCol] == player.piece)
            {
                count++;
                currRow--;
                currCol++;
            }
            currRow = row + 1;
            currCol = col - 1;
            while(currRow<size && currCol>=0 && board[currRow,currCol]==player.piece)
            {
                count++;
                currRow++;
                currCol--;
            }
            if (count >= matched)
                return true;

            return false;
        }
    }
}
