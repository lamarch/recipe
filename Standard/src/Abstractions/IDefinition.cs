
namespace Recipe.Standard
{
    public interface IDefinition<TValue>
    {
        IItem<TValue> Reference { get; init; }
        IMatches<TValue> Matches { get; init; }

    }
}
