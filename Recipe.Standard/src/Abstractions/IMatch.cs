namespace Recipe.Standard
{
    public interface IMatch<TValue>
    {
        IItemRef<TValue> ItemRef { get; init; }
        long Count { get; init; }
        IPosition<TValue> Position { get; init; }

        void AddCount(long count);
    }
}