using System;

namespace H02_LongestSequenceOfEqual
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbersCount = int.Parse(Console.ReadLine());

            var numbers = new int[numbersCount];
            var longestSequenceLength = 1;

            for (int i = 0; i < numbersCount; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentLength = 0;

                for (int j = i; j < numbers.Length; j++)
                {
                    if (numbers[i] != numbers[j])
                    {
                        if (currentLength > 1)
                        {
                            i = j - 1;
                        }

                        break;                        
                    }

                    currentLength++;
                }

                if (currentLength > longestSequenceLength)
                {
                    longestSequenceLength = currentLength;
                }
            }

            Console.WriteLine(longestSequenceLength);
        }
    }
}