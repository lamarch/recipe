namespace Recipe.Standard
{
    using System.Collections.Generic;

    public interface IPosition<TValue>
    {
        IDefinition<TValue> Definition { get; init; }
        long RelativePosition { get; init; }
        long TotalCount { get; }
        IReadOnlyCollection<IMatch<TValue>> Matches { get; init; }

        IMatch<TValue> GetMatch(IItemRef<TValue> item);
        void AddMatch(IItemRef<TValue> item, long count);

        IMatch<TValue> PickRandomMatch();

    }
}