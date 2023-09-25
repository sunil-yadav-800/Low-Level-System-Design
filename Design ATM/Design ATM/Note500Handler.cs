using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_ATM
{
    public class Note500Handler : NoteHandler
    {
        public Note500Handler(NoteHandler handler) : base(handler)
        {
        }
        override
        public void withdrawal(long amount)
        {
            if(amount>=500)
            {
                Console.WriteLine("withdrawing {0} note of rupee 500", amount / 500);
                base.withdrawal(amount - (500 * (amount / 500)));
            }
            else
            {
                base.withdrawal(amount);
            }
        }
    }
}
