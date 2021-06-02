using System;
using System.Linq.Expressions;
namespace Recipe.Standard
{
    using System.Collections.Generic;
    using System.Linq;

    public record Recipe<TValue> : IRecipe<TValue> where TValue : IEquatable<TValue>
    {
        List<IItem<TValue>> m_items = new();
        List<IDefinition<TValue>> m_definitions = new();

        public Recipe()
        {
            Random = new Random();
        }

        public Random Random { get; init; }
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

        public IItem<TValue> GetItem(TValue value)
        {
            return new Item<TValue>(value, this);
        }

        public IItemRef<TValue> GetItemRef(IItem<TValue> item)
        {
            // Item already exists ?
            if (!m_items.Contains(item))
                m_items.Add(item);

            return new ItemRef<TValue>(this, item);
        }

        public IDefinition<TValue> GetDefinition(IItem<TValue> item)
        {
            var itemRef = GetItemRef(item);
            try
            {
                return m_definitions.First(definition => definition.ItemRef.Item == itemRef.Item);
            }
            catch
            {
                var definition = new Definition<TValue>(this, itemRef);
                m_definitions.Add(definition);
                return definition;
            }
        }

        public void AddMatches(IItem<TValue> item, IEnumerable<(IItem<TValue> item, long relativePosition, long count)> matches)
        {

            var definition = GetDefinition(item);

            foreach (var match in matches)
            {
                definition.AddMatch(GetItemRef(match.item), match.relativePosition, match.count);
            }
        }

        public void AddMatch(IItem<TValue> item, (IItem<TValue> item, long relativePosition, long count) match)
        {
            var definition = GetDefinition(item);
            definition.AddMatch(GetItemRef(match.item), match.relativePosition, match.count);
        }
    }
}