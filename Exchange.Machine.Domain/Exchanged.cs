using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Machine.Domain
{
    public class Exchanged : IExchanged
    {
        private readonly string _coins;
        public string Coins { get { return _coins; } }
        public string Message { get; private set; }

        public Exchanged(string coins, string message)
        {
            _coins = coins;
            Message = message;
        }

        public int[] FindCoinsForChange(int cents, byte[] typeCoinsAvailable)
        {
            int typeCoinsLength = typeCoinsAvailable.Length;

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
                    if (i - typeCoinsAvailable[j] >= 0)
                    {
                        if (min[i] > 1 + min[i - typeCoinsAvailable[j]])
                        {
                            min[i] = 1 + min[i - typeCoinsAvailable[j]];
                            coin[i] = typeCoinsAvailable[j]; // Atualiza moeda escolhida
                        }
                    }
                }
            }

            return coin;
        }
    }
}
