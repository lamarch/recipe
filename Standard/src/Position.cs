using System;
namespace Recipe.Standard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Recipe.Standard.Extensions;

    public class Position<TValue> : IPosition<TValue>
    {
        readonly Random m_random;

        long m_totalCount = 0;
        List<IMatch<TValue>> m_matches = new();

        public Position(IDefinition<TValue> definition, long relativePosition)
        {
            Definition = definition;
            RelativePosition = relativePosition;
            m_random = definition.Recipe.Random;
        }

        public IDefinition<TValue> Definition { get; init; }
        public long RelativePosition { get; init; }
        public long TotalCount
        {
            get { return m_totalCount; }
        }

        public IReadOnlyCollection<IMatch<TValue>> Matches
        {
            get { return m_matches; }
            init { m_matches = value.ToList(); }
        }

        public IMatch<TValue> GetMatch(IItemRef<TValue> itemRef)
        {
            try
            {
                return Matches.First(match => match.ItemRef == itemRef);
            }
            catch
            {
                var match = new Match<TValue>(this, itemRef, 0);
                m_matches.Add(match);
                return match;
            }
        }

        public void AddMatch(IItemRef<TValue> item, long count)
        {
            var match = GetMatch(item);
            match.AddCount(count);
            m_totalCount.BoundAdd(count);
        }

        public IMatch<TValue> PickRandomMatch()
        {
            var rndIndex = m_random.NextLong(0, TotalCount);

            long browseIndex = 0;
            IMatch<TValue> pickedMatch = null!;

            foreach (var match in Matches)
            {
                browseIndex += match.Count;

                if (browseIndex < rndIndex)
                {
                    pickedMatch = match;
                    break;
                }
            }

            return pickedMatch!;
        }
    }
}