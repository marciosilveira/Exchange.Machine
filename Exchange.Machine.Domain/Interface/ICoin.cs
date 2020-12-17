using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Machine.Domain
{
    public interface ICoin
    {
        byte Value { get; }
        int Quantity { get; }
        int Total { get; }
        bool IsAvailable { get; }

        void IncreaseQuantity(int quantity);
        bool DecreaseQuantity(int quantity = 1);
    }
}
