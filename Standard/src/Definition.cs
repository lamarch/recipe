
using System.Text.RegularExpressions;
namespace Recipe.Standard
{
    using System.Collections.Generic;
    using System.Linq;

    public record Definition<TValue> : IDefinition<TValue>
    {
        Dictionary<long, IMatch<TValue>> m_matches = new();

        public Definition(IRecipe<TValue> recipe, IItemRef<TValue> reference)
        {
            Recipe = recipe;
            Reference = reference;
        }

        public IRecipe<TValue> Recipe { get; init; }
        public IItemRef<TValue> Reference { get; init; }

        public IReadOnlyDictionary<long, IMatch<TValue>> Matches
        {
            get { return m_matches; }
            init { m_matches = value.ToDictionary(kvp => kvp.Key, kvp => kvp.Value); }
        }

        public void AddMatch(IItem<TValue> item, long relativePosition, long count)
        {

            if (m_matches.TryGetValue(relativePosition, out IMatch<TValue> _match))
            {
                m_matches[relativePosition] = new Match<TValue>(this, _match.ItemRef, _match.Count + count);
            }
            else
            {
                var match = new Match<TValue>(this, new ItemRef<TValue>(Recipe, item), count);
                m_matches[relativePosition] = match;
            }
        }

    }
}