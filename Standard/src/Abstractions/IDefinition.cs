

namespace Recipe.Standard
{
    using System.Collections.Generic;
    public interface IDefinition<TValue>
    {
        IItemRef<TValue> Reference { get; init; }
        IReadOnlyCollection<IMatch<TValue>> Matches { get; init; }
        IRecipe<TValue> Recipe { get; init; }

        void AddMatch(IItem<TValue> item, double frequency);
    }
}
