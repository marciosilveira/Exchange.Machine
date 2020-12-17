using Exchange.Machine.Domain.Const;

namespace Exchange.Machine.Domain
{
    public class CashRegister : ICashRegister
    {
        private readonly IBox _box;
        private readonly ICalculateChange _calculateChange;

        public IBox Box { get { return _box; } }

        public CashRegister(IBox box, ICalculateChange calculateChange)
        {
            _box = box;
            _calculateChange = calculateChange;
        }

        public IChange ToExchange(int cents)
        {
            if (!IsValidMoney(cents))
                return new Change(nameof(AppConsts.ChangeIsNotValid), AppConsts.ChangeIsNotValid, _box.Coins);

            if (!EnoughMoney(cents))
                return new Change(nameof(AppConsts.InsufficientCoins), AppConsts.InsufficientCoins, _box.Coins);

            return _calculateChange.Calculate(cents);
        }

        public void SupplyCoins(byte value, int quantity)
        {
            var coin = _box.FindCoin(value);
            coin?.IncreaseQuantity(quantity);
        }

        public void Bloodletting(byte value, int quantity)
        {
            var coin = _box.FindCoin(value);
            coin?.DecreaseQuantity(quantity);
        }

        public void SupplyCoins(Dto.Coin[] coins)
        {
            if (coins.Length == 0)
                return;

            foreach (var item in coins)
            {
                SupplyCoins((byte)item.Value, item.Quantity);
            }
        }

        public void Bloodletting(Dto.Coin[] coins)
        {
            if (coins.Length == 0)
                return;

            foreach (var item in coins)
            {
                Bloodletting((byte)item.Value, item.Quantity);
            }
        }

        private bool EnoughMoney(int cents) => _box.Total >= cents;

        private bool IsValidMoney(int cents) => cents > 0;
    }
}
