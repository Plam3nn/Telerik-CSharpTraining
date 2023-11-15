using System;

namespace P09_PowerN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var power = int.Parse(Console.ReadLine());

            var result = CalculatePower(number, power);
            Console.WriteLine(result);
        }

        private static int CalculatePower(int number, int power)
        {
            if (power == 0)
            {
                return 1;
            }

            power--;
            number *= CalculatePower(number, power);

            return number;
        }
    }
}
