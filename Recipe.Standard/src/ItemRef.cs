namespace Recipe.Standard
{
    public record ItemRef<TValue> : IItemRef<TValue>
    {
        public ItemRef(IRecipe<TValue> recipe, IItem<TValue> item)
        {
            Item = item;
            Recipe = recipe;
        }

        public IRecipe<TValue> Recipe { get; init; }
        public IItem<TValue> Item { get; init; }

        public TValue PickValue()
        {
            return Item.Value;
        }
    }
}