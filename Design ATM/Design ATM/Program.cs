using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            Note500Handler noteHandler = new Note500Handler(new Note100Handler(new Note50Handler(null)));
            long amount = 18900;
            if(amount%50 != 0)
            {
                Console.WriteLine("Please enter the amount which is multiple of 50");
            }
            else
            {
                noteHandler.withdrawal(amount);
            }
           
            Console.ReadKey();
        }
    }
}
