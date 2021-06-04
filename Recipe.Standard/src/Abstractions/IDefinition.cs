

namespace Recipe.Standard
{
    using System;
    using System.Collections.Generic;
    public interface IDefinition<TValue> where TValue : IEquatable<TValue>
    {
        TValue Item { get; init; }
        IReadOnlyCollection<IPosition<TValue>> Positions { get; init; }
        IRecipe<TValue> Recipe { get; init; }


        IPosition<TValue> GetPosition(long relativePosition);
        void AddMatch(TValue item, long relativePosition, long count);

        IMatch<TValue> PickRandomMatch(long relativePosition);
    }
}
