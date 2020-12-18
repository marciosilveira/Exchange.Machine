using Exchange.Machine.Domain;
using FluentAssertions;
using Xunit;

namespace Exchange.Machine.UnitTest
{
    public class ChangeTests
    {
        [Fact]
        public void CreateValidChangeObjectInstance()
        {
            string messageCode = "Error001";
            string message = "Error test...";
            ICoin[] coinsBox = new ICoin[1] { new Coin(1, 1) };
            string coins = "0,10 | 0,25";

            var change = new Change(messageCode, message, coinsBox, coins);

            change.Should().NotBeNull();
            change.MessageCode.Should().Be(messageCode);
            change.Message.Should().Be(message);
            change.Coins.Should().Be(coins);
            change.CoinsBox.Should().BeEquivalentTo(coinsBox);
        }
    }
}
