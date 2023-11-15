using System;
using System.Linq;

namespace P01_Jumps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbersCount = int.Parse(Console.ReadLine());

            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var jumps = new int[numbers.Length];
            jumps[numbers.Length - 1] = 0;

            var mostJumps = -1;

            for (int i = 0; i < numbersCount - 1; i++)
            {
                var currentNumber = numbers[i];
                var currentNumberJumps = 0;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    var nextNumber = numbers[j];

                    if (currentNumber < nextNumber)
                    {
                        currentNumber = nextNumber;
                        currentNumberJumps++;
                    }
                }

                if (currentNumberJumps > mostJumps)
                {
                    mostJumps = currentNumberJumps;
                }

                jumps[i] = currentNumberJumps;
            }

            Console.WriteLine(mostJumps);
            Console.WriteLine(string.Join(" ", jumps));
        }
    }
}
