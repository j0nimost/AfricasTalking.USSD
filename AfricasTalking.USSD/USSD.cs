using System;
using System.Collections.Generic;
using System.Text;

namespace AfricasTalking.USSD
{
    public abstract class USSD
    {
        public abstract int[] BackHandler(string text);
    }
}
