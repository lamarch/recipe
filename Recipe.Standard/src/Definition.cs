namespace Recipe.Standard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public record Definition<TValue> : IDefinition<TValue> where TValue : IEquatable<TValue>
    {
        List<IPosition<TValue>> m_positions = new();

        public Definition(IRecipe<TValue> recipe, TValue item)
        {
            Recipe = recipe;
            Item = item;
        }

        public IRecipe<TValue> Recipe { get; init; }
        public TValue Item { get; init; }

        public IReadOnlyCollection<IPosition<TValue>> Positions
        {
            get { return m_positions; }
            init { m_positions = value.ToList(); }
        }


        public IPosition<TValue> GetPosition(long relativePosition)
        {
            try
            {
                return Positions.First(position => position.RelativePosition == relativePosition);
            }
            catch
            {
                IPosition<TValue> position = new Position<TValue>(this, relativePosition);
                m_positions.Add(position);
                return position;
            }
        }

        public void AddMatch(TValue item, long relativePosition, long count)
        {
            var position = GetPosition(relativePosition);

            position.AddMatch(item, count);
        }

        public IMatch<TValue> PickRandomMatch(long relativePosition)
        {
            var position = GetPosition(relativePosition);
            return position.PickRandomMatch();
        }
    }
}