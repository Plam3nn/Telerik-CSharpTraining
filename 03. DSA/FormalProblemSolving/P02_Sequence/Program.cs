using System;
using System.Collections.Generic;

namespace P02_Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            var element = int.Parse(input[0]);
            var count = int.Parse(input[1]);

            if (count == 1)
            {
                Console.WriteLine(element);
                return;
            }

            var currentCount = 1;

            var elements = new List<int> { element };

            var nextElementIndex = 0;

            while (true)
            {
                var currentElement = elements[nextElementIndex];

                for (int i = 0; i < 3; i++)
                {
                    if (++currentCount <= count)
                    {
                        if (i == 0)
                        {
                            elements.Add(currentElement + 1);   
                        }
                        else if (i == 1)
                        {
                            elements.Add(2 * currentElement + 1);
                        }
                        else if (i == 2)
                        {
                            elements.Add(currentElement + 2);
                        }
                    }

                    if (currentCount == count)
                    {
                        Console.WriteLine(elements[currentCount - 1]);
                        return;
                    }
                }

                nextElementIndex++;
            }        
        }
    }
}