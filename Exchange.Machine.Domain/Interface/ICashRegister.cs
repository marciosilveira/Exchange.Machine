using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Machine.Domain
{
    public interface ICashRegister
    {
        IBox Box { get; }
        IExchanged ToExchange(int cents);
        void SupplyCoins(byte value, int quantity);
        void Bloodletting(byte value, int quantity);
        void SupplyCoins(Dto.Coin[] coins);
        void Bloodletting(Dto.Coin[] coins);
        bool EnoughMoney(int cents);
        bool IsValidMoney(int cents);
    }
}
