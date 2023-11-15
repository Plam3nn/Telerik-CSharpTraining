using System;
using System.Collections.Generic;

namespace P01_NoahsArk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var animalsAndCounts = new SortedDictionary<string, int>();
            var animalsCount = int.Parse(Console.ReadLine());

            AddAnimals(animalsAndCounts, animalsCount);
            Print(animalsAndCounts);
        }

        private static void AddAnimals(SortedDictionary<string, int> animalsAndCounts, int animalsCount)
        {
            for (int i = 0; i < animalsCount; i++)
            {
                var animal = Console.ReadLine();

                AddAnimal(animalsAndCounts, animal);
            }
        }

        private static void Print(SortedDictionary<string, int> animalsAndCounts)
        {
            foreach (var item in animalsAndCounts) 
            {
                var animal = item.Key;
                var count = item.Value;

                var isEven = count % 2 == 0 ? "Yes" : "No";
                Console.WriteLine($"{animal} {count} {isEven}");
            }
        }

        private static void AddAnimal(SortedDictionary<string, int> animalsAndCounts, string animal)
        {
            animalsAndCounts.TryAdd(animal, 0);
            animalsAndCounts[animal]++;
        }
    }
}
