using System;
namespace Recipe.Standard
{
    public interface IMatch<TValue> where TValue : IEquatable<TValue>
    {
        TValue Item { get; init; }
        long Count { get; init; }
        IPosition<TValue> Position { get; init; }

        void AddCount(long count);
    }
}