using System;

namespace P03_Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var array = new long[n + 1];
            var result = CalculateFibonacci(n, array);
            Console.WriteLine(result);
        }

        private static long CalculateFibonacci(int n, long[] array)
        {
            if (array[n] == 0)
            {
                if (n == 0)
                {
                    array[n] = 0;
                    return 0;
                }

                if (n == 1)
                {
                    array[n] = 1;
                    return 1;
                }

                array[n] = CalculateFibonacci(n - 1, array) + CalculateFibonacci(n - 2, array);
            }

            return array[n];
        }
    }
}
