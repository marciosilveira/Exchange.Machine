using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Machine.Domain
{
    public enum CoinEnumerator : byte
    {
        Coin1 = 1,
        Coin5 = 5,
        Coin10 = 10,
        Coin25 = 25,
        Coin50 = 50,
        Coin100 = 100
    }

    public static class CoinEnumeratorExteions
    {
        public static byte ToByte(this CoinEnumerator coinEnumerator) => (byte)coinEnumerator;
    }
}
