namespace Recipe.Standard
{
    using System.Collections.Generic;

    public interface IRecipe<TValue>
    {
        IReadOnlyCollection<IItem<TValue>> Items { get; init; }
        IReadOnlyCollection<IDefinition<TValue>> Definitions { get; init; }

        void CreateDefinition(IItem<TValue> item, IEnumerable<(Item<TValue>, double)> matches);
    }
}