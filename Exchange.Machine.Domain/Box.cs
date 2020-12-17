using System.Linq;

namespace Exchange.Machine.Domain
{
    public class Box : IBox
    {
        private readonly ICoin[] _coins;
        public ICoin[] Coins { get { return _coins; } }
        public byte[] CoinsAvailable { get { return _coins.Where(w => w.IsAvailable).Select(s => s.Value).ToArray(); } }
        public int Total { get { return _coins?.Sum(s => s.Total) ?? default; } }

        public Box(ICoin[] coins)
        {
            _coins = coins;
        }

        public ICoin FindCoin(int value) => _coins.FirstOrDefault(x => x.Value == value);
        public ICoin FindCoin(CoinEnumerator value) => FindCoin(value.ToByte());

        public static IBox New(ICoin[] coins) => new Box(coins);
    }
}
