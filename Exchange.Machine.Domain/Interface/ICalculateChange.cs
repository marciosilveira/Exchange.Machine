using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Machine.Domain
{
    public interface ICalculateChange
    {

        Exchanged Calculate(int cents);
    }
}
