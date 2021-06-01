
namespace Recipe.Standard
{
    public interface IDefinition<TValue>
    {
        IMatches<TValue> Matches { get; init; }

    }
}
