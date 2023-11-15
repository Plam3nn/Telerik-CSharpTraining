using System;

namespace P05_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var totalBlocks = CalculateBlocks(n);
            Console.WriteLine(totalBlocks);
        }

        private static int CalculateBlocks(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            return n + CalculateBlocks(n - 1);
        }
    }
}
