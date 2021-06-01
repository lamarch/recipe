namespace Recipe.Standard
{
    public interface IMatche<TValue>
    {
        IItem<TValue> Item { get; init; }
        double Frequency { get; init; }
    }
}