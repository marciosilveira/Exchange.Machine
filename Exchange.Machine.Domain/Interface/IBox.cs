using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Machine.Domain
{
    public interface IBox
    {
        ICoin[] Coins { get; }
        byte[] CoinsAvailable { get; }
        int Total { get; }
        ICoin FindCoin(int value);
    }
}
