using System;
using System.Linq;

namespace P02_SymmetricArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfArrays = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfArrays; i++)
            {
                bool isSymmetric = true;

                var currentArray = Console.ReadLine()
                    .Split()
                    .ToArray();

                for (int j = 0; j < currentArray.Length / 2; j++)
                {
                    if (currentArray[j] != currentArray[currentArray.Length - 1 - j])
                    {
                        isSymmetric = false;
                    }
                }

                if (isSymmetric)
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }
        }
    }
}
