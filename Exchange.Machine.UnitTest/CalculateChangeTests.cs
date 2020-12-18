using Exchange.Machine.Domain;
using FluentAssertions;
using Xunit;

namespace Exchange.Machine.UnitTest
{
    public class CalculateChangeTests
    {
        [Fact]
        public void ExchangeMoney_Should_Be_Satisfied_By_67Cents()
        {
            IBox box = new Box(new Coin[6]
            {
                 new Coin(CoinEnumerator.Coin1.ToByte(), 3),
                 new Coin(CoinEnumerator.Coin5.ToByte(), 3),
                 new Coin(CoinEnumerator.Coin10.ToByte(), 3),
                 new Coin(CoinEnumerator.Coin25.ToByte(), 3),
                 new Coin(CoinEnumerator.Coin50.ToByte(), 3),
                 new Coin(CoinEnumerator.Coin100.ToByte(), 3)
            });

            int cents = 67;

            var calculateChange = new CalculateChange(box);
            var change = calculateChange.Calculate(cents);
            change.Coins.Should().Be("0,01 | 0,01 | 0,05 | 0,10 | 0,50");
        }

        [Fact]
        public void ExchangeMoney_Should_Be_Satisfied_By_92Cents()
        {
            IBox box = new Box(new Coin[6]
            {
                new Coin(CoinEnumerator.Coin1.ToByte(), 2),
                new Coin(CoinEnumerator.Coin5.ToByte(), 3),
                new Coin(CoinEnumerator.Coin10.ToByte(), 4),
                new Coin(CoinEnumerator.Coin25.ToByte(), 5),
                new Coin(CoinEnumerator.Coin50.ToByte(), 6),
                new Coin(CoinEnumerator.Coin100.ToByte(), 7)
            });

            int cents = 92;

            var calculateChange = new CalculateChange(box);
            var change = calculateChange.Calculate(cents);
            change.Coins.Should().Be("0,01 | 0,01 | 0,05 | 0,10 | 0,25 | 0,50");
        }
    }
}
