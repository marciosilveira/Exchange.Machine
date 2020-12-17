using System;
using System.Collections.Generic;
using System.Text;

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

            int[] min = new int[cents + 1]; //Armazena a menor quantidade de moeda para todos os valores de 0 a n
            min[0] = 0;
            min[1] = 1;
            int[] coin = new int[cents + 1]; //Armazena a moeda escolhida para todos os valor de 0 a n
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
                            coin[i] = typeCoins[j]; // Atualiza moeda escolhida
                        }
                    }
                }
            }

            return coin;
        }

        public Exchanged Calculate(int cents)
        {
            int[] coins = FindCoinsForChange(cents);

            int typeCoinsLength = coins.Length - 1;
            string changeWithLessCoins = string.Empty;
            while (typeCoinsLength > 0)                //Enquanto o valor é maior que 0
            {
                int coin = coins[typeCoinsLength];
                bool enoughCoin = _box.FindCoin(coin)?.DecreaseQuantity() ?? false;

                if (!enoughCoin)
                    return new Exchanged(null, "Opsss... Moedas insuficientes no caixa :(");

                changeWithLessCoins += coin.ToString();
                typeCoinsLength -= coin;
                if (typeCoinsLength > 0)
                    changeWithLessCoins += ", ";
            }

            return new Exchanged(changeWithLessCoins, "Ebaaa! Troca realizada com sucesso :)");
        }
    }
}
