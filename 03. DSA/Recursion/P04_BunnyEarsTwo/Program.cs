using System;

namespace P04_BunnyEarsTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bunnyCount = int.Parse(Console.ReadLine());
            var totalEars = CalculateEars(bunnyCount);
            Console.WriteLine(totalEars);
        }

        private static int CalculateEars(int bunnyCount)
        {
            if (bunnyCount == 0)
            {
                return 0;
            }

            if (bunnyCount % 2 == 0)
            {
                return 3 + CalculateEars(bunnyCount - 1);
            }
            else
            {
                return 2 + CalculateEars(bunnyCount - 1);
            }
        }
    }
}
