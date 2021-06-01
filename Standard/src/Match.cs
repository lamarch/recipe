namespace Recipe.Standard
{
    public record Match<TValue> : IMatch<TValue>
    {
        public IItem<TValue> Item { get; init; }
        public double Frequency { get; init; }
        public IDefinition<TValue> Matches { get; init; }

    }
}