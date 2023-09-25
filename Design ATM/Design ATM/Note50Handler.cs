using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_ATM
{
    public class Note50Handler : NoteHandler
    {

        public Note50Handler(NoteHandler handler) : base(handler)
        {
        }
        override
        public void withdrawal(long amount)
        {
            if (amount >= 50)
            {
                Console.WriteLine("withdrawing {0} note of rupee 50", amount / 50);
                base.withdrawal(amount - (50 * (amount / 50)));
            }
            else
            {
                base.withdrawal(amount);
            }
        }
    }
}
