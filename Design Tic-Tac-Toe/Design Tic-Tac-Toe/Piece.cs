using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Tic_Tac_Toe
{
    class Piece
    {
        public PieceType pieceType;
        public Piece(PieceType pieceType)
        {
            this.pieceType = pieceType;
        }
    }
}
