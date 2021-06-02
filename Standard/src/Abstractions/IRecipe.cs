namespace Recipe.Standard
{
    using System.Collections.Generic;

    public interface IRecipe<TValue>
    {
        IReadOnlyCollection<IItem<TValue>> Items { get; init; }
        IReadOnlyCollection<IDefinition<TValue>> Definitions { get; init; }

        IItemRef<TValue> AddItem(IItem<TValue> item);
        void CreateDefinition(IItem<TValue> item, IEnumerable<(IItem<TValue> item, long relativePosition, long count)> matches);
    }
}