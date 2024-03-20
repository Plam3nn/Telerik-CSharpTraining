using System;
using System.Linq;

namespace H02_Move
{
    internal class Program
    {
        static void Main()
        {
            var startingIndex = int.Parse(Console.ReadLine());

            var numbers = Console.ReadLine()
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            var totalForwardSum = 0;
            var totalBackwardsSum = 0;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "exit")
                {
                    break;
                }

                var args = input.Split();

                var steps = int.Parse(args[0]);
                var direction = args[1];
                var stepSize = int.Parse(args[2]);

                if (direction == "forward")
                {
                    totalForwardSum += GetForwardSum(numbers, ref startingIndex, steps, stepSize);
                }
                else if (direction == "backwards")
                {
                    totalBackwardsSum += GetBackwardsSum(numbers, ref startingIndex, steps, stepSize);
                }                
            }

            Console.WriteLine($"Forward: {totalForwardSum}");
            Console.WriteLine($"Backwards: {totalBackwardsSum}");
        }

        static int GetBackwardsSum(int[] numbers, ref int startingIndex, int steps, int stepSize)
        {
            var sum = 0;

            for (int i = 0; i < steps; i++)
            {
                stepSize %= numbers.Length;

                for (int j = 0; j < stepSize; j++)
                {
                    startingIndex -= 1;

                    if (startingIndex == -1)
                    {
                        startingIndex = numbers.Length - 1;
                    }
                }

                sum += numbers[startingIndex];
            }
            
            return sum;
        }

        static int GetForwardSum(int[] numbers, ref int startingIndex, int steps, int stepSize)
        {
            // Solution 1
            //var sum = 0;

            //for (int i = 0; i < steps; i++)
            //{
            //    stepSize %= numbers.Length;

            //    for (int j = 0; j < stepSize; j++)
            //    {
            //        startingIndex += 1;

            //        if (startingIndex == numbers.Length)
            //        {
            //            startingIndex = 0;
            //        }
            //    }

            //    sum += numbers[startingIndex];               
            //}

            // Solution 2
            var sum = 0;

            for (int i = 0; i < steps; i++)
            {
                startingIndex += stepSize;

                if (startingIndex >= numbers.Length)
                {
                    startingIndex %= numbers.Length;
                }

                sum += numbers[startingIndex];
            }

            return sum;
        }
    }
}