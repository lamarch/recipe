namespace Recipe.Standard
{
    public interface IMatche<TValue>
    {
        IItem<TValue> Item { get; init; }
        double Frequency { get; init; }

        IMatches<TValue> Matches { get; init; }
    }
}