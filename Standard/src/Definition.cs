
namespace Recipe.Standard
{
    using System.Collections.Generic;
    public record Definition<TValue> : IDefinition<TValue>
    {
        public IItemRef<TValue> Reference { get; init; }
        public IReadOnlyCollection<IMatch<TValue>> Matches { get; init; }
        public IRecipe<TValue> Recipe { get; init; }

        public void AddMatch(IItem<TValue> item, double frequency)
        {

        }

    }
}