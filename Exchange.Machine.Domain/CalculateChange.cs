using Exchange.Machine.Domain.Const;

namespace Exchange.Machine.Domain
{
    public class CalculateChange : ICalculateChange
    {
        private readonly IBox _box;

        public CalculateChange(IBox box)
        {
            _box = box;
        }

        private int[] FindCoinsForChange(int cents)
        {
            var typeCoins = _box.CoinsAvailable;
            int typeCoinsLength = typeCoins.Length;

            int[] min = new int[cents + 1]; // Stores the least amount of coin for all values from 0 to n
            min[0] = 0;
            min[1] = 1;
            int[] coin = new int[cents + 1]; // Stores the chosen coin for all values from 0 to n
            coin[0] = 0;
            coin[1] = 1;

            for (int i = 2; i <= cents; i++)
            {
                min[i] = int.MaxValue;
                for (int j = 0; j < typeCoinsLength; j++)
                {
                    if (i - typeCoins[j] >= 0)
                    {
                        if (min[i] > 1 + min[i - typeCoins[j]])
                        {
                            min[i] = 1 + min[i - typeCoins[j]];
                            coin[i] = typeCoins[j]; // Updates chosen coin
                        }
                    }
                }
            }

            return coin;
        }

        public Change Calculate(int cents)
        {
            int[] coins = FindCoinsForChange(cents);

            int typeCoinsLength = coins.Length - 1;
            string changeWithLessCoins = string.Empty;
            while (typeCoinsLength > 0) // While the value greater than 0
            {
                int coin = coins[typeCoinsLength];
                bool enoughCoin = _box.FindCoin(coin)?.DecreaseQuantity() ?? false;

                if (!enoughCoin)
                    return new Change(nameof(AppConsts.InsufficientCoins), AppConsts.InsufficientCoins, _box.Coins);

                changeWithLessCoins += coin.Formatting();
                typeCoinsLength -= coin;
                if (typeCoinsLength > 0)
                    changeWithLessCoins += " | ";
            }

            return new Change(nameof(AppConsts.ExchangeSuccessful), AppConsts.ExchangeSuccessful, _box.Coins, changeWithLessCoins);
        }
    }
}
