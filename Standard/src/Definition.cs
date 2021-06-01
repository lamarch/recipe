
using System.Text.RegularExpressions;
namespace Recipe.Standard
{
    using System.Collections.Generic;
    using System.Linq;

    public record Definition<TValue> : IDefinition<TValue>
    {
        List<IMatch<TValue>> m_matches = new();
        public Definition(IRecipe<TValue> recipe, IItemRef<TValue> reference)
        {
            Recipe = recipe;
            Reference = reference;
        }

        public IRecipe<TValue> Recipe { get; init; }
        public IItemRef<TValue> Reference { get; init; }
        public IReadOnlyCollection<IMatch<TValue>> Matches
        {
            get { return m_matches; }
            init { m_matches = value.ToList(); }
        }

        public void AddMatch(IItem<TValue> item, double frequency)
        {
            var match = new Match<TValue>(this, new ItemRef<TValue>(Recipe, item), frequency);
            m_matches.Add(match);
        }

    }
}