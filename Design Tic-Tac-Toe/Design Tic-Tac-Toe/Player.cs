using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Tic_Tac_Toe
{
    class Player
    {
        public string Name { get; set; }
        public Piece piece { get; set; }
        public Player(string name, Piece piece)
        {
            this.Name = name;
            this.piece = piece;
        }
    }
}
