
namespace Recipe.Standard
{
    using System.Collections.Generic;
    public record Recipe<TValue> : IRecipe<TValue>
    {
        public IReadOnlyCollection<IItem<TValue>> Items { get; init; }
        public IReadOnlyCollection<IDefinition<TValue>> Definitions { get; init; }

        public void CreateDefinition(IItem<TValue> item, IEnumerable<(Item<TValue>, double)> matches)
        {

        }

    }
}