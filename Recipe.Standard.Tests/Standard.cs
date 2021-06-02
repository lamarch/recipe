#nullable enable
namespace Recipe.Standard.Tests
{
    using System;
    using System.Collections.Generic;

    using Xunit;

    using Standard;

    public class TestsStandard
    {
        [Fact]
        public void BasicRecipe()
        {

            Recipe<string> recipe = new();
            var a = new Item<string>("a", recipe);

            recipe.AddMatches(a,
            new List<(IItem<string>, long, long)>()
            {
                (a, 1, 2)
            });

            Assert.Equal("a", recipe.GetDefinition(a).PickRandomMatch(1).ItemRef.PickValue());
        }
    }
}
