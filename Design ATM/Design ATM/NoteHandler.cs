using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_ATM
{
    public abstract class NoteHandler
    {
        private NoteHandler nextHandler;
        public NoteHandler(NoteHandler handler)
        {
            this.nextHandler = handler;
        }
        public virtual void withdrawal(long amount)
        {
            if(nextHandler != null)
            {
                nextHandler.withdrawal(amount);
            }
        }
    }
}
