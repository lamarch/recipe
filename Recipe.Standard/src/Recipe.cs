using System;
using System.Linq.Expressions;
namespace Recipe.Standard
{
    using System.Collections.Generic;
    using System.Linq;

    public record Recipe<TValue> : IRecipe<TValue> where TValue : IEquatable<TValue>
    {
        List<IDefinition<TValue>> m_definitions = new();

        public Recipe()
        {
            Random = new Random();
        }

        public Random Random { get; init; }
        public IReadOnlyCollection<IDefinition<TValue>> Definitions
        {
            get { return m_definitions; }
            init { m_definitions = value.ToList(); }
        }


        public IDefinition<TValue> GetDefinition(TValue item)
        {
            try
            {
                return m_definitions.First(definition => definition.Item.Equals(item));
            }
            catch
            {
                var definition = new Definition<TValue>(this, item);
                m_definitions.Add(definition);
                return definition;
            }
        }

        public void AddMatches(TValue item, IEnumerable<(TValue item, long relativePosition, long count)> matches)
        {

            var definition = GetDefinition(item);

            foreach (var match in matches)
            {
                definition.AddMatch(match.item, match.relativePosition, match.count);
            }
        }
        public void AddMatch(TValue item, (TValue item, long relativePosition, long count) match)
        {
            var definition = GetDefinition(item);
            definition.AddMatch(match.item, match.relativePosition, match.count);
        }
    }
}