namespace Recipe.Standard
{
    public record Match<TValue> : IMatch<TValue>
    {
        public Match(IDefinition<TValue> definition, IItemRef<TValue> item, double frequency)
        {
            Definition = definition;
            Item = item;
            Frequency = frequency;
        }

        public IDefinition<TValue> Definition { get; init; }
        public IItemRef<TValue> Item { get; init; }
        public double Frequency { get; init; }

    }
}