using System;

namespace P02_BunnyEars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bunniesCount = int.Parse(Console.ReadLine());
            var totalEars = CalculateEars(bunniesCount);
            Console.WriteLine(totalEars);
        }

        private static int CalculateEars(int bunniesCount)
        {
            if (bunniesCount  < 0)
            {
                throw new ArgumentException("Cannot have negative number of bunnies.");
            }

            if (bunniesCount == 0)
            {
                return 0;
            }

            if (bunniesCount == 1)
            {
                return 2;
            }

            return 2 + CalculateEars(bunniesCount - 1);
        }
    }
}
