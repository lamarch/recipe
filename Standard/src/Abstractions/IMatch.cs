namespace Recipe.Standard
{
    public interface IMatch<TValue>
    {
        IItemRef<TValue> ItemRef { get; init; }
        long Count { get; init; }
        IDefinition<TValue> Definition { get; init; }
    }
}