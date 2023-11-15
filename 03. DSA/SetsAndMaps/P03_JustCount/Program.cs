using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_JustCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lowerLettersAndCounts = new Dictionary<char, int>();
            var capitalLettersAndCounts = new Dictionary<char, int>();
            var symbolsAndCounts = new Dictionary<char, int>();

            var input = Console.ReadLine();

            foreach (var character in input)
            {
                if (char.IsLower(character))
                {
                    if (!lowerLettersAndCounts.ContainsKey(character))
                    {
                        lowerLettersAndCounts[character] = 0;
                    }

                    lowerLettersAndCounts[character]++;
                }
                else if (char.IsUpper(character))
                {
                    if (!capitalLettersAndCounts.ContainsKey(character))
                    {
                        capitalLettersAndCounts[character] = 0;
                    }

                    capitalLettersAndCounts[character]++;
                }
                else
                {
                    if (!symbolsAndCounts.ContainsKey(character))
                    {
                        symbolsAndCounts[character] = 0;
                    }

                    symbolsAndCounts[character]++;
                }
            }

            var mostOccuringSymbol = GetMax(symbolsAndCounts);
            var mostOccuringLowerLetter = GetMax(lowerLettersAndCounts);
            var mostOccuringCapitalLetter = GetMax(capitalLettersAndCounts);

            Console.WriteLine(mostOccuringSymbol);
            Console.WriteLine(mostOccuringLowerLetter);
            Console.WriteLine(mostOccuringCapitalLetter);
        }

        private static string GetMax(Dictionary<char, int> repo)
        {
            var result = string.Empty;

            if (repo.Any())
            {
                foreach (var item in repo.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(1))
                {
                    result = $"{item.Key} {item.Value}";
                }
            }
            else
            {
                result = "-";
            }

            return result;
        }
    }
}
