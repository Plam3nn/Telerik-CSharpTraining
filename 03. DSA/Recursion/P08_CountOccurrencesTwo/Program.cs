using System;

namespace P08_CountOccurrencesTwo
{
    internal class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(Count(number));
        }

        private static int Count(int number)
        {
            if (number == 0)
            {
                return 0;
            }

            int counter = (number % 10 == 8) ? 1 : 0;

            if (counter == 1)
            {
                int dividedNumber = number / 10;
                counter += (dividedNumber % 10 == 8) ? 1 : 0;
            }

            return Count(number / 10) + counter;
        }
    }
}
