using System;

namespace P06_SumDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var sum = CalculateDigitsSum(number);
            Console.WriteLine(sum);
        }

        private static int CalculateDigitsSum(int number)
        {
            if (number == 0)
            {
                return 0;
            }

            var lastDigit = number % 10;
            var newNumber = number / 10;

            return lastDigit + CalculateDigitsSum(newNumber);
        }
    }
}
