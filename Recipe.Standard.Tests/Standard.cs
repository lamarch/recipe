#nullable enable
namespace Recipe.Standard.Tests
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;

    using Xunit;
    using Xunit.Abstractions;

    using Standard;

    public class TestsStandard
    {
        readonly ITestOutputHelper output;
        public TestsStandard(ITestOutputHelper output)
        {
            this.output = output;
        }
        internal void Print(string s) => output.WriteLine(s);

        [Fact]
        public void BasicRecipe()
        {

            Recipe<string> recipe = new();
            var a = "a";

            recipe.AddMatches(a,
            new List<(string, long, long)>()
            {
                (a, 1, 2)
            });

            Assert.Equal("a", recipe.GetDefinition(a).PickRandomMatch(1).Item);
        }



        [Fact]
        public void Parsing()
        {
            const string input = "bonjour";
            char[] splits = new[]{
                ' ',
                ',',
                '.',
                ';',
                '\t',
                '\n',
                '\r',

            };

            Recipe<char> recipe = new();

            char precChar;
            char currChar;
            char nextChar;

            for (var i = 0; i < input.Length; i++)
            {
                currChar = input[i];

                // Add matches for precedent chars
                for (var j = i - 1; j >= 0; j--)
                {
                    precChar = input[j];
                    recipe.AddMatch(currChar, (precChar, j - i, 1));
                }

                // Add matches for next chars
                for (var j = i + 1; j < input.Length; j++)
                {
                    nextChar = input[j];
                    recipe.AddMatch(currChar, (nextChar, j - i, 1));
                }
            }

            Print("");
            Print("Recipe :");
            foreach (var definition in recipe.Definitions)
            {
                Print($"- Definition of '{definition.Item}' :");

                foreach (var position in definition.Positions)
                {
                    Print($"    - Position at {position.RelativePosition}, total = {position.TotalCount} :");

                    foreach (var match in position.Matches)
                    {
                        Print($"      - Match of '{match.Item}' {match.Count} times.");
                    }
                }


            }
        }
    }
}
