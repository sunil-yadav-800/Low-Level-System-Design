using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_ATM
{
    public class Note100Handler : NoteHandler
    {
        public Note100Handler(NoteHandler handler) : base(handler)
        {
        }
        override
        public void withdrawal(long amount)
        {
            if (amount >= 100)
            {
                Console.WriteLine("withdrawing {0} note of rupee 100", amount / 100);
                base.withdrawal(amount - (100 * (amount / 100)));
            }
            else
            {
                base.withdrawal(amount);
            }
        }
    }
}
