namespace Recipe.Standard
{
    using System;
    using System.Collections.Generic;

    public interface IRecipe<TValue>
    {
        Random Random { get; init; }
        IReadOnlyCollection<IItem<TValue>> Items { get; init; }
        IReadOnlyCollection<IDefinition<TValue>> Definitions { get; init; }

        IItemRef<TValue> GetItemRef(IItem<TValue> item);
        void AddMatches(IItem<TValue> item, IEnumerable<(IItem<TValue> item, long relativePosition, long count)> matches);
        IDefinition<TValue> GetDefinition(IItem<TValue> item);
    }
}