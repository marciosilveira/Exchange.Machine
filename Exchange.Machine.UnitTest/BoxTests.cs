using Exchange.Machine.Domain;
using FluentAssertions;
using Xunit;

namespace Exchange.Machine.UnitTest
{
    public class BoxTests
    {
        [Fact]
        public void Should_MustFindCoinSuccessfully_When_ValidCoin()
        {
            ICoin[] coins = new Coin[6]
            {
                new Coin(CoinEnumerator.Coin1.ToByte(), 2),
                new Coin(CoinEnumerator.Coin5.ToByte(), 0),
                new Coin(CoinEnumerator.Coin10.ToByte(), 0),
                new Coin(CoinEnumerator.Coin25.ToByte(), 0),
                new Coin(CoinEnumerator.Coin50.ToByte(), 0),
                new Coin(CoinEnumerator.Coin100.ToByte(), 0)
            };

            IBox box = new Box(coins);
            box.FindCoin(CoinEnumerator.Coin1)
                .Should()
                .NotBeNull()
                .And
                .Be(coins[0]);

            box.FindCoin(CoinEnumerator.Coin10.ToByte())
                .Should()
                .NotBeNull()
                .And
                .Be(coins[2]);
        }

        [Fact]
        public void CreateValidBoxObjectInstance()
        {
            var box = Box.New(new ICoin[1] { new Coin(1, 1) });
            box.Should().NotBeNull();
            box.Total.Should().Be(1);
        }

        [Fact]
        public void CreateEmptyBoxObjectInstance()
        {
            var box = Box.New(null);
            box.Should().NotBeNull();
            box.Total.Should().Be(default);
        }
    }
}
