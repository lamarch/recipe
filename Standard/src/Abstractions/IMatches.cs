namespace Recipe.Standard
{
    using System.Collections.Generic;

    public interface IMatches<TValue>
    {
        IReadOnlyCollection<IMatche<TValue>> MatcheList { get; init; }
    }
}