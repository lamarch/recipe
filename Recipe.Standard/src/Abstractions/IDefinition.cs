

namespace Recipe.Standard
{
    using System.Collections.Generic;
    public interface IDefinition<TValue>
    {
        IItemRef<TValue> ItemRef { get; init; }
        IReadOnlyCollection<IPosition<TValue>> Positions { get; init; }
        IRecipe<TValue> Recipe { get; init; }


        IPosition<TValue> GetPosition(long relativePosition);
        void AddMatch(IItemRef<TValue> item, long relativePosition, long count);

        IMatch<TValue> PickRandomMatch(long relativePosition);
    }
}
