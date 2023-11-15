using System;
using System.Collections.Generic;
using System.Linq;

namespace P18_Variations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var length = int.Parse(Console.ReadLine());
            var chars = Console.ReadLine().Split().Select(char.Parse).ToArray();

            var firstChar = chars.Min();
            var secondChar = chars.Max();

            var variations = new List<string>();

            GetVariations(variations, firstChar, secondChar, length, string.Empty);

            Console.WriteLine(string.Join(Environment.NewLine, variations));
        }

        private static void GetVariations(List<string> variations, char firstChar, char secondChar, int length, string currentVariation)
        {
            if (currentVariation.Length == length)
            {
                variations.Add(currentVariation);
                return;
            }

            GetVariations(variations, firstChar, secondChar, length, currentVariation + firstChar);
            GetVariations(variations, firstChar, secondChar, length, currentVariation + secondChar);
        }
    }
}
