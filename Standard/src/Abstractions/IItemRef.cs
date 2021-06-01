namespace Recipe.Standard
{
    public interface IItemRef<TValue>
    {

        IItem<TValue> Item { get; init; }
        IRecipe<TValue> Recipe { get; init; }
        TValue PickValue();
    }
}