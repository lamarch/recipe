namespace Recipe.Standard
{
    public interface IMatch<TValue>
    {
        IItemRef<TValue> Item { get; init; }
        double Frequency { get; init; }
        IDefinition<TValue> Definition { get; init; }
    }
}