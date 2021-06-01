namespace Recipe.Standard
{
    public interface IItem<TValue>
    {
        TValue Value { get; init; }
    }
}