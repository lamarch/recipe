using System;
namespace Recipe.Standard
{
    using System.Collections.Generic;

    public interface IPosition<TValue> where TValue : IEquatable<TValue>
    {
        IDefinition<TValue> Definition { get; init; }
        long RelativePosition { get; init; }
        long TotalCount { get; }
        IReadOnlyCollection<IMatch<TValue>> Matches { get; init; }

        IMatch<TValue> GetMatch(TValue item);
        void AddMatch(TValue item, long count);

        IMatch<TValue> PickRandomMatch();

    }
}