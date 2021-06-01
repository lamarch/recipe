namespace Recipe.Standard
{
    public interface IMatch<TValue>
    {
        IItem<TValue> Item { get; init; }
        double Frequency { get; init; }
        IDefinition<TValue> Matches { get; init; }
    }
}