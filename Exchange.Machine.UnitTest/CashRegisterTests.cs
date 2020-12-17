using Exchange.Machine.Domain;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Exchange.Machine.UnitTest
{
    public class CashRegisterTests
    {
        private readonly Coin[] _coins;

        public CashRegisterTests()
        {
            _coins = new Coin[6]
            {
                new Coin(CoinEnumerator.Coin1.ToByte(), 10),
                new Coin(CoinEnumerator.Coin5.ToByte(), 5),
                new Coin(CoinEnumerator.Coin10.ToByte(), 13),
                new Coin(CoinEnumerator.Coin25.ToByte(), 8),
                new Coin(CoinEnumerator.Coin50.ToByte(), 5),
                new Coin(CoinEnumerator.Coin100.ToByte(), 3)
            };
        }

        //[Fact]
        //public void SupplyCoins_Should_By_Satisfied_By_NewCoinQuantity()
        //{
        //    var cashRegister = new CashRegister(_coins);

        //    cashRegister.SupplyCoins(CoinEnumerator.Coin1.ToByte(), 113);
        //    var coin = cashRegister.FindCoin(CoinEnumerator.Coin1.ToByte());
        //    coin.Quantity.Should().Be(123);
        //}

        //[Fact]
        //public void ExchangeMoney_Should_By_Satisfied_By_30Cents()
        //{
        //    int cents = 30;

        //   var coins = new Coin[6]
        //   {
        //        new Coin(CoinEnumerator.Coin1.ToByte(), 6),
        //        new Coin(CoinEnumerator.Coin5.ToByte(), 0),
        //        new Coin(CoinEnumerator.Coin10.ToByte(), 3),
        //        new Coin(CoinEnumerator.Coin25.ToByte(), 1),
        //        new Coin(CoinEnumerator.Coin50.ToByte(), 1),
        //        new Coin(CoinEnumerator.Coin100.ToByte(), 0)
        //   };

        //    var cashRegister = new CashRegister(coins);
        //    var exchange = cashRegister.ToExchange(cents);
        //    exchange.Coins.Should().BeEquivalentTo("10, 10, 10");
        //}

        //[Fact]
        //public void ExchangeMoney_Should_By_Satisfied_By_36Cents()
        //{
        //    int cents = 36;

        //    var coins = new Coin[6]
        //    {
        //        new Coin(CoinEnumerator.Coin1.ToByte(), 6),
        //        new Coin(CoinEnumerator.Coin5.ToByte(), 0),
        //        new Coin(CoinEnumerator.Coin10.ToByte(), 3),
        //        new Coin(CoinEnumerator.Coin25.ToByte(), 1),
        //        new Coin(CoinEnumerator.Coin50.ToByte(), 1),
        //        new Coin(CoinEnumerator.Coin100.ToByte(), 0)
        //    };

        //    var cashRegister = new CashRegister(coins);
        //    var exchange = cashRegister.ToExchange(cents);
        //    exchange.Coins.Should().BeEquivalentTo("1, 10, 25");
        //}
    }
}
