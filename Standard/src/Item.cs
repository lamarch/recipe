namespace Recipe.Standard
{
    public record Item<TValue> : IItem<TValue>
    {
        public TValue Value { get; init; }
    }
}