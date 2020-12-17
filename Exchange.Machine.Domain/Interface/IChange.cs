namespace Exchange.Machine.Domain
{
    public interface IChange
    {
        string Coins { get; }
        string MessageCode { get; }
        string Message { get; }
        ICoin[] CoinsBox { get; }
    }
}
