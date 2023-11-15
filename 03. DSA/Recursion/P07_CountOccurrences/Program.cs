using System;

namespace P07_CountOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            int occurences = CountOccurrences(number);
            Console.WriteLine(occurences);
        }

        private static int CountOccurrences(int number)
        {
            if (number == 0)
            {
                return 0;
            }

            var lastDigit = number % 10;
            number /= 10;

            if (lastDigit == 7)
            {
                return 1 + CountOccurrences(number);
            }

            return CountOccurrences(number);
        }
    }
}
