namespace Recipe.Standard
{
    using Recipe.Standard.Extensions;
    public record Match<TValue> : IMatch<TValue>
    {
        long m_count;

        public Match(IPosition<TValue> position, IItemRef<TValue> item, long count)
        {
            Position = position;
            ItemRef = item;
            Count = count;
        }

        public IPosition<TValue> Position { get; init; }
        public IItemRef<TValue> ItemRef { get; init; }
        public long Count
        {
            get { return m_count; }
            init { m_count = value; }
        }

        public void AddCount(long count)
        {
            m_count += count;
        }
    }
}