
namespace Recipe.Standard
{
    public interface IDefinition<TValue>
    {
        IItem<TValue> Reference { get; init; }
        IMatches<TValue> Matches { get; init; }
        IRecipe<TValue> Recipe { get; init; }

    }
}
