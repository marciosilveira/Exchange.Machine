using Exchange.Machine.Domain;
using FluentAssertions;
using Xunit;

namespace Exchange.Machine.UnitTest
{
    public class CalculateChangeTests
    {
        [Fact]
        public void ExchangeMoney_Should_Be_Satisfied_By_30Cents()
        {
            IBox box = new Box(new Coin[6]
            {
                 new Coin(CoinEnumerator.Coin1.ToByte(), 6),
                 new Coin(CoinEnumerator.Coin5.ToByte(), 0),
                 new Coin(CoinEnumerator.Coin10.ToByte(), 3),
                 new Coin(CoinEnumerator.Coin25.ToByte(), 1),
                 new Coin(CoinEnumerator.Coin50.ToByte(), 1),
                 new Coin(CoinEnumerator.Coin100.ToByte(), 0)
            });

            int cents = 30;

            var calculateChange = new CalculateChange(box);
            var change = calculateChange.Calculate(cents);
            change.Coins.Should().Be("0,10 | 0,10 | 0,10");
        }

        [Fact]
        public void ExchangeMoney_Should_Be_Satisfied_By_36Cents()
        {
            IBox box = new Box(new Coin[6]
            {
                new Coin(CoinEnumerator.Coin1.ToByte(), 6),
                new Coin(CoinEnumerator.Coin5.ToByte(), 0),
                new Coin(CoinEnumerator.Coin10.ToByte(), 3),
                new Coin(CoinEnumerator.Coin25.ToByte(), 1),
                new Coin(CoinEnumerator.Coin50.ToByte(), 1),
                new Coin(CoinEnumerator.Coin100.ToByte(), 0)
            });

            int cents = 36;

            var calculateChange = new CalculateChange(box);
            var change = calculateChange.Calculate(cents);
            change.Coins.Should().Be("0,01 | 0,10 | 0,25");
        }
    }
}
