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

                // Is it the end of a word ?
                if (splits.Contains(currChar))
                {
                    currChar = '\0';
                }

                // first letter
                precChar = '\0';
                if (i > 0)
                {
                    // not first letter
                    precChar = input[i - 1];
                }

                // Is it the end of a word ?
                if (splits.Contains(precChar))
                {
                    precChar = '\0';
                }

                // last letter
                nextChar = '\0';
                if (i < input.Length - 1)
                {
                    // not last letter
                    nextChar = input[i + 1];
                }

                if (splits.Contains(nextChar))
                {
                    nextChar = '\0';
                }

                // Precedent char matches
                recipe.AddMatches(precChar, new List<(char item, long relativePosition, long count)>(){
                    (currChar, +1, 1),
                    (nextChar, +2, 1)
                });

                // Current char matches
                recipe.AddMatches(currChar, new List<(char item, long relativePosition, long count)>(){
                    (precChar, -1, 1),
                    (nextChar, +1, 1)
                });

                // Next char matches
                recipe.AddMatches(nextChar, new List<(char item, long relativePosition, long count)>(){
                    (currChar, -1, 1),
                    (precChar, -2, 1)
                });
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
