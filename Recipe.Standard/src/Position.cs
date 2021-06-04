using System;
namespace Recipe.Standard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Recipe.Standard.Extensions;

    public class Position<TValue> : IPosition<TValue> where TValue : IEquatable<TValue>
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

        public IMatch<TValue> GetMatch(TValue item)
        {
            try
            {
                return Matches.First(match => match.Item.Equals(item));
            }
            catch
            {
                var match = new Match<TValue>(this, item, 0);
                m_matches.Add(match);
                return match;
            }
        }

        public void AddMatch(TValue item, long count)
        {
            var match = GetMatch(item);
            match.AddCount(count);
            m_totalCount += count;
        }

        public IMatch<TValue> PickRandomMatch()
        {
            var rndIndex = m_random.NextLong(0, TotalCount);

            long browseIndex = 0;
            IMatch<TValue> pickedMatch = null!;

            foreach (var match in Matches)
            {

                if (browseIndex < rndIndex)
                {
                    pickedMatch = match;
                    break;
                }
                browseIndex += match.Count;
            }

            return pickedMatch!;
        }
    }
}