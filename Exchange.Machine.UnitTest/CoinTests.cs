using Exchange.Machine.Domain;
using FluentAssertions;
using System;
using Xunit;

namespace Exchange.Machine.UnitTest
{
    public class CoinTests
    {
        private readonly byte _coinValue;
        private readonly int _coinQuantity;
        private readonly int _coinTotal;

        public CoinTests()
        {
            _coinValue = 25;
            _coinQuantity = 1548;
            _coinTotal = _coinValue * _coinQuantity;
        }

        [Fact]
        public void CoinMustHaveValue_Should_Be_Satisfied_By_When_IsValidValue()
        {
            var coin = new Coin(_coinValue, _coinQuantity);
            coin.Value.Should().Be(_coinValue, "Coin value does not match");
        }

        [Fact]
        public void CoinMustHaveQuantity_Should_Be_Satisfied_By_When_IsValidQuantity()
        {
            var coin = new Coin(_coinValue, _coinQuantity);
            coin.Quantity.Should().Be(_coinQuantity, "Coin quantity does not match");
        }

        [Fact]
        public void CoinMustHaveTotal_Should_Be_Satisfied_By_When_IsValidCoinValueAndQuantity()
        {
            var coin = new Coin(_coinValue, _coinQuantity);
            coin.Total.Should().Be(_coinTotal, "Coin total does not match");
        }

        [Fact]
        public void IncreaseCoinQuantity_Should_Be_Safisfied_By_When_IsValidCoinQuantity()
        {
            int increaseQuantity = 123;
            var newQuantity = _coinQuantity + increaseQuantity;

            var coin = new Coin(_coinValue, _coinQuantity);
            coin.IncreaseQuantity(increaseQuantity);

            coin.Quantity.Should().Be(newQuantity);
        }

        [Fact]
        public void DecreaseCoinQuantity_Should_Be_Satisfied_By_When_IsValidCoinQuantity()
        {
            int decreaseQuantity = 10;
            var newQuantity = _coinQuantity - decreaseQuantity;

            var coin = new Coin(_coinValue, _coinQuantity);
            coin.DecreaseQuantity(decreaseQuantity);
            coin.Quantity.Should().Be(newQuantity);
        }

        [Fact]
        public void DecreaseCoinQuantity_Should_Warn_When_TotalAmountWouldBeNegative()
        {
            int decreaseQuantity = _coinQuantity + 1;

            var coin = new Coin(_coinValue, _coinQuantity);
            coin.DecreaseQuantity(decreaseQuantity);
            coin.Quantity.Should().Be(_coinQuantity);
        }
    }
}
