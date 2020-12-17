using Exchange.Machine.Domain;
using Exchange.Machine.Domain.Const;
using FluentAssertions;
using Moq;
using Xunit;

namespace Exchange.Machine.UnitTest
{
    public class CashRegisterTests
    {
        [Fact]
        public void Should_NotChangeMoney_When_CentsLessThanOrEqualZero()
        {
            const byte coin = 5;
            const int quantity = 7;

            Mock<IBox> mockBox = new Mock<IBox>();
            mockBox
                .Setup(o => o.FindCoin(It.IsAny<int>()))
                .Returns(new Coin(coin, quantity));

            var cashRegister = new CashRegister(mockBox.Object, null);
            var exchange = cashRegister.ToExchange(0);
            exchange.MessageCode.Should().Be(nameof(AppConsts.ChangeIsNotValid));
        }

        [Fact]
        public void Should_NotChangeMoney_When_DoesntHaveEnoughMoney()
        {
            const byte coin = 5;
            const int quantity = 1;

            Mock<IBox> mockBox = new Mock<IBox>();
            mockBox
                .Setup(o => o.FindCoin(It.IsAny<int>()))
                .Returns(new Coin(coin, quantity));

            var cashRegister = new CashRegister(mockBox.Object, null);
            var exchange = cashRegister.ToExchange(50);
            exchange.MessageCode.Should().Be(nameof(AppConsts.InsufficientCoins));
        }
    }
}
