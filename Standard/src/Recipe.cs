
using System.Text.RegularExpressions;
namespace Recipe.Standard
{
    using System.Collections.Generic;
    using System.Linq;

    public record Recipe<TValue> : IRecipe<TValue>
    {
        List<IItem<TValue>> m_items = new();
        List<IDefinition<TValue>> m_definitions = new();

        public Recipe()
        {

        }

        public IReadOnlyCollection<IItem<TValue>> Items
        {
            get { return m_items; }
            init { m_items = value.ToList(); }
        }
        public IReadOnlyCollection<IDefinition<TValue>> Definitions
        {
            get { return m_definitions; }
            init { m_definitions = value.ToList(); }
        }

        public void CreateDefinition(IItem<TValue> item, IEnumerable<(Item<TValue> item, long relativePosition, long count)> matches)
        {
            var definition = new Definition<TValue>(this, new ItemRef<TValue>(this, item));

            foreach (var match in matches)
            {
                definition.AddMatch(match.item, match.relativePosition, match.count);
            }

            m_definitions.Add(definition);
        }

    }
}