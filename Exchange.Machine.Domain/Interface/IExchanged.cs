using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Machine.Domain
{
    public interface IExchanged
    {
        string Coins { get; }
        string Message { get; }

        int[] FindCoinsForChange(int cents, byte[] typeCoinsAvailable);
    }
}
