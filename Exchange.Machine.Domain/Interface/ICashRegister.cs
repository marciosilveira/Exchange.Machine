namespace Exchange.Machine.Domain
{
    public interface ICashRegister
    {
        IBox Box { get; }
        IChange ToExchange(int cents);
        void SupplyCoins(byte value, int quantity);
        void Bloodletting(byte value, int quantity);
        void SupplyCoins(Dto.Coin[] coins);
        void Bloodletting(Dto.Coin[] coins);
    }
}
