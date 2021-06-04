namespace Recipe.Standard
{
    using System;
    public record Match<TValue> : IMatch<TValue> where TValue : IEquatable<TValue>
    {
        long m_count;

        public Match(IPosition<TValue> position, TValue item, long count)
        {
            Position = position;
            Item = item;
            Count = count;
        }

        public IPosition<TValue> Position { get; init; }
        public TValue Item { get; init; }
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