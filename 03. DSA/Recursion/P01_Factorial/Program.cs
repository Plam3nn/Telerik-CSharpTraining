using System;

namespace P01_Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var result = CalculateFactorial(n);
            Console.WriteLine(result);
        }

        private static long CalculateFactorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException($"Factorial of negative numbers is not defined.");
            }

            if (n <= 1)
            {
                return 1;
            }

            return n * CalculateFactorial(n - 1);
        }
    }
}
