namespace Recipe.Standard
{
    public record Match<TValue> : IMatch<TValue>
    {
        public Match(IDefinition<TValue> definition, IItemRef<TValue> item, long count)
        {
            Definition = definition;
            ItemRef = item;
            Count = count;
        }

        public IDefinition<TValue> Definition { get; init; }
        public IItemRef<TValue> ItemRef { get; init; }
        public long Count { get; init; }

    }
}