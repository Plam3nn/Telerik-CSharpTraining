using System;
using System.Collections.Generic;
using System.Linq;

namespace H03_BigNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeOfArrays = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var array1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var array2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var result = new List<int>();

            var extraToAdd = 0;
            var i = 0;

            while (i < array1.Length || i < array2.Length)
            {
                var digit1 = i < array1.Length ? array1[i] : 0;
                var digit2 = i < array2.Length ? array2[i] : 0;

                var currentSum = digit1 + digit2 + extraToAdd;

                extraToAdd = currentSum / 10;
                result.Add(currentSum % 10);
                i++;
            }

            if (extraToAdd > 0)
            {
                result.Add(extraToAdd);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}