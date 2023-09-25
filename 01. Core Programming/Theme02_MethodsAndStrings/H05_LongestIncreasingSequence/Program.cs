using System;

namespace H05_LongestIncreasingSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = ReadInteger();
            var numbers = new int[n];

            FillArray(numbers);

            var result = GetLongestSequenceCount(numbers);
            PrintResult(result);
        }

        static void PrintResult(int result)
        {
            Console.WriteLine(result);
        }

        static int GetLongestSequenceCount(int[] numbers)
        {
            var longestSequenceCount = 0;
            var counter = 1;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                var currentNumber = numbers[i];
                var nextNumber = numbers[i + 1];

                if (currentNumber < nextNumber)
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                }

                if (counter > longestSequenceCount)
                {
                    longestSequenceCount = counter;
                }
            }

            return longestSequenceCount;
        }

        static void FillArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = ReadInteger();
            }
        }

        static int ReadInteger()
        {
            return int.Parse(Console.ReadLine());
        }
    }
}
