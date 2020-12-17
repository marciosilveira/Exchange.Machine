namespace Exchange.Machine.Domain
{
    public class Change : IChange
    {
        public string Coins { get; private set; }
        public string MessageCode { get; private set; }
        public string Message { get; private set; }
        public ICoin[] CoinsBox { get; private set; }

        public Change(string messageCode, string message, ICoin[] coinsBox, string coins = null)
        {
            Coins = coins;
            MessageCode = messageCode;
            Message = message;
            CoinsBox = coinsBox;
        }
    }
}
