using System;
using System.Linq;
namespace Recipe.Standard
{
    public record Item<TValue> : IItem<TValue> where TValue : IEquatable<TValue>
    {
        public TValue Value { get; init; }
        public IRecipe<TValue> Recipe { get; init; }

        public bool Equals(IItem<TValue> item)
        {
            if (item is null) return false;
            return Value.Equals(item.Value);
        }

    }
}