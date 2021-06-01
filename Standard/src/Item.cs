namespace Recipe.Standard
{
    public record Item<TValue> : IItem<TValue>
    {
        public TValue Value { get; init; }
        public IRecipe<TValue> Recipe { get; init; }

    }
}