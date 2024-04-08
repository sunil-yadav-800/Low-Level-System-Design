using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakes_and_Ladders
{
    class Board
    {
        public int Size { get; set; }
        public Cell[,] board { get; set; }
        public Board(int Size)
        {
            this.Size = Size;
            board = new Cell[this.Size,this.Size];
            for(int i=0;i<Size;i++)
            {
                for(int j=0;j<Size;j++)
                {
                    board[i, j] = new Cell();
                }
            }
        }
        public void addSnakesAndLadders(int noOfSnakes, int noOfLadders)
        {
            Random rand = new Random();
            while (noOfSnakes > 0)
            {
                int snakeHead = rand.Next(0, Size * Size - 2);
                int snakeTail = rand.Next(0, Size * Size - 2);
                if(snakeHead > snakeTail && snakeHead/Size != snakeTail/Size)
                {
                    Cell cell = getCell(snakeHead);
                    cell.Jump = new Jump(snakeHead, snakeTail);
                    noOfSnakes--;
                }
            }
            while (noOfLadders > 0)
            {
                int ladderStart = rand.Next(0, Size * Size - 1);
                int ladderEnd = rand.Next(0, Size * Size - 1);
                if (ladderStart < ladderEnd && ladderStart/Size!=ladderEnd/Size)
                {
                    Cell cell = getCell(ladderStart);
                    cell.Jump = new Jump(ladderStart, ladderEnd);
                    noOfLadders--;
                }
            }
        }
        public Cell getCell(int position)
        {
            //assuming board will be like
            /*
             0 1 2 3
             7 6 5 4
             8 9 10 11
             15 14 13 12
             */

            int row = position / Size;
            int col = position % Size;
            if(row%2!=0)
            {
                col = (Size - 1) - col;
            }
            return board[row, col];
        }
    }
}
