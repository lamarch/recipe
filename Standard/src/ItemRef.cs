namespace Recipe.Standard
{
    public record ItemRef<TValue> : IItemRef<TValue>
    {
        public IItem<TValue> Item { get; init; }

        public IRecipe<TValue> Recipe { get; init; }
    }
}