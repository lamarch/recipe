namespace Recipe.Standard
{
    public record Matche<TValue> : IMatche<TValue>
    {
        public IItem<TValue> Item { get; init; }
        public double Frequency { get; init; }
    }
}