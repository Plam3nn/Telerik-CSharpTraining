using System;
using System.Text;

namespace H01_PrimesToN
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNumber = int.Parse(Console.ReadLine());

            for (int i = 1; i <= inputNumber; i++)
            {
                var isNotDivisible = true;

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isNotDivisible = false;
                    }
                }

                if (isNotDivisible)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
