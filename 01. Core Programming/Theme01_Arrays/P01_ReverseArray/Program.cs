using System;
using System.Linq;

namespace P01_ReverseArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .ToArray();

            //Array.Reverse(numbers);

            var reversedNumbers = new string[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                reversedNumbers[i] = numbers[numbers.Length - 1 - i];
            }

            Console.WriteLine(string.Join(", ", reversedNumbers));
        }
    }
}
