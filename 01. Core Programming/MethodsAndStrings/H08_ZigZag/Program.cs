using System;
using System.Linq;
using System.Numerics;

namespace H08_ZigZag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dimensions = ReadRowOfIntegers();
            var sum = GetZigZagSum(dimensions);
            PrintSum(sum);
        }        

        static long GetZigZagSum(int[] dimensions)
        {
            var rows = dimensions[0];
            var cols = dimensions[1];
            var sum = 0L;

            var currentCol = 0;

            for (int currentRow = 0; currentRow < rows; currentRow++)
            {
                if (currentRow % 2 == 0)
                {
                    currentCol = 0;
                }
                else
                {
                    currentCol = 1;
                }

                for (int i = 0; i < cols / 2; i++)
                {
                    var currentCellVallue = ((currentRow + currentCol) * 3) + 1;                    
                    
                    // because when going zig zag we step 2 times over this cell (inner cell)

                    if (currentRow != 0
                        && currentRow != rows - 1
                        && currentCol != 0
                        && currentCol != cols - 1)
                    {
                        currentCellVallue *= 2;    
                    }

                    sum += currentCellVallue;
                    currentCol += 2;
                }
            }

            return sum;
        }

        static int[] ReadRowOfIntegers()
        {
            return Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
        }

        static void PrintSum(long sum)
        {
            Console.WriteLine(sum);
        }
    }
}