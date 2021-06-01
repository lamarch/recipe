namespace Recipe.Standard
{
    public interface IItem<TValue>
    {
        TValue Value { get; init; }
        IRecipe<TValue> Recipe { get; init; }
    }
}