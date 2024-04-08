using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakes_and_Ladders
{
    class Jump
    {
        public int Start { get; set; }
        public int End { get; set; }
        public Jump(int Start, int End)
        {
            this.Start = Start;
            this.End = End;
        }
    }
}
