namespace Recipe.Standard
{
    using System.Collections.Generic;

    public record Matches<TValue> : IMatches<TValue>
    {
        public IReadOnlyCollection<IMatche<TValue>> MatcheList { get; init; }
        public IDefinition<TValue> Definition { get; init; }

    }
}