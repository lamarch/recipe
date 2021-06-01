namespace Recipe.Standard
{
    public record Definition<TValue> : IDefinition<TValue>
    {
        public IItem<TValue> Reference { get; init; }
        public IMatches<TValue> Matches { get; init; }
        public IRecipe<TValue> Recipe { get; init; }

    }
}