namespace Recipe.Standard
{
    using System;
    using System.Collections.Generic;

    public interface IRecipe<TValue> where TValue : IEquatable<TValue>
    {
        Random Random { get; init; }
        IReadOnlyCollection<IDefinition<TValue>> Definitions { get; init; }

        void AddMatch(TValue item, (TValue item, long relativePosition, long count) match);
        void AddMatches(TValue item, IEnumerable<(TValue item, long relativePosition, long count)> matches);

        IDefinition<TValue> GetDefinition(TValue item);
    }
}