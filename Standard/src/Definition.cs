namespace Recipe.Standard
{
    using System.Collections.Generic;
    using System.Linq;

    public record Definition<TValue> : IDefinition<TValue>
    {
        List<IPosition<TValue>> m_positions = new();

        public Definition(IRecipe<TValue> recipe, IItemRef<TValue> reference)
        {
            Recipe = recipe;
            ItemRef = reference;
        }

        public IRecipe<TValue> Recipe { get; init; }
        public IItemRef<TValue> ItemRef { get; init; }

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

        public void AddMatch(IItemRef<TValue> item, long relativePosition, long count)
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