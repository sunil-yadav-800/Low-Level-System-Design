using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakes_and_Ladders
{
    class Dice
    {
        public int NoOfDices { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public Dice(int noOfDices, int minValue, int maxValue)
        {
            NoOfDices = noOfDices;
            MinValue = minValue;
            MaxValue = maxValue;
        }
        public int roll()
        {
            Random rand = new Random();
            int totalValue = 0;
            for(int i=0;i<NoOfDices;i++)
            {
                totalValue += rand.Next(MinValue, MaxValue + 1);
            }
            return totalValue;
        }
    }
}
