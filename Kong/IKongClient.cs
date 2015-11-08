namespace Kong
{
    public interface IKongClient
    {
        Apis Apis { get; }

        Consumers Consumers { get; }
    }
}
