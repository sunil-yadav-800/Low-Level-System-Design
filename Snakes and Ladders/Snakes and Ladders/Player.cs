using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakes_and_Ladders
{
    class Player
    {
        public Player(string name)
        {
            Name = name;
            Postion = 0;
        }

        public string Name { get; set; }
        public int Postion { get; set; }
    }
}
