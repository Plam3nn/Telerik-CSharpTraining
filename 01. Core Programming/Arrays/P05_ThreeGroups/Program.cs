using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_ThreeGroups
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var numbersWithRemainderZero = new List<int>();
            var numbersWithRemainderOne = new List<int>();
            var numbersWithRemainderTwo = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNumber = numbers[i];

                if (currentNumber % 3 == 0)
                {
                    numbersWithRemainderZero.Add(currentNumber);
                }
                else if (currentNumber % 3 == 1)
                {
                    numbersWithRemainderOne.Add(currentNumber);
                }
                else
                {
                    numbersWithRemainderTwo.Add(currentNumber);
                }
            }

            Console.WriteLine(string.Join(" ", numbersWithRemainderZero));
            Console.WriteLine(string.Join(" ", numbersWithRemainderOne));
            Console.WriteLine(string.Join(" ", numbersWithRemainderTwo));
        }
    }
}
