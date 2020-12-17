using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Machine.Domain
{
    public class Coin : ICoin
    {
        private readonly byte _value;
        private int _quantity;

        public byte Value { get { return _value; } }
        public int Quantity { get { return _quantity; } }
        public int Total { get { return _value * _quantity; } }
        public bool IsAvailable { get { return _quantity > 0; } }

        public Coin(byte value, int quantity)
        {
            _value = value;
            _quantity = quantity;
        }

        public void IncreaseQuantity(int quantity) => _quantity += quantity;
        public bool DecreaseQuantity(int quantity = 1)
        {
            var isValid = IsValidQuantityDecrease(quantity);

            if (isValid)
                _quantity -= quantity;

            return isValid;
        }

        private bool IsValidQuantityDecrease(int quantity) => _quantity >= quantity;

        public static Coin[] New() => new[]
        {
            new Coin(CoinEnumerator.Coin1.ToByte(), default),
            new Coin(CoinEnumerator.Coin5.ToByte(), default),
            new Coin(CoinEnumerator.Coin10.ToByte(), default),
            new Coin(CoinEnumerator.Coin25.ToByte(), default),
            new Coin(CoinEnumerator.Coin50.ToByte(), default),
            new Coin(CoinEnumerator.Coin100.ToByte(), default)
        };
    }

    public static class CoinExtension
    {
        public static string Formatting(this int coin, double formula = 100) => (coin / formula).ToString("0.00");
    }
}
