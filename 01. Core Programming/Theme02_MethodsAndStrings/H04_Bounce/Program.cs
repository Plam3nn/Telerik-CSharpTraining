using System;
using System.Linq;

namespace H04_Bounce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var matrix = new long[dimensions[0], dimensions[1]];

            FillMatrix(matrix);
            PrintSum(matrix);            
        }

        static void PrintSum(long[,] matrix)
        {
            var result = 0L;

            if (matrix.GetLength(0) == 1 || matrix.GetLength(1) == 1)
            {
                result = 1L;
            }
            else
            {
                result = GetSumFromBouncing(matrix);
            }

            Console.WriteLine(result);
        }

        static long GetSumFromBouncing(long[,] matrix)
        {
            var sum = 0L;
            var currentRow = 0;
            var currentCol = 0;

            var hasHitBottom = false;
            var hasHitRight = false;

            while (true)
            {
                sum += matrix[currentRow, currentCol];

                var hasHitCorner = (currentRow == 0 && currentCol == 0)
                    || (currentRow == matrix.GetLength(0) - 1 && currentCol == 0)
                    || (currentRow == matrix.GetLength(0) - 1 && currentCol == matrix.GetLength(1) - 1)
                    || (currentRow == 0 && currentCol == matrix.GetLength(1) - 1);
               
                if (hasHitCorner && sum != 1)
                {
                    break;
                }

                if (currentRow == matrix.GetLength(0) - 1)
                {
                    hasHitBottom = true;
                }

                if (currentRow == 0)
                {
                    hasHitBottom = false;
                }

                if (currentCol == matrix.GetLength(1) - 1)
                {
                    hasHitRight = true;
                }

                if (currentCol == 0)
                {
                    hasHitRight = false;
                }

                if (!hasHitBottom)
                {
                    currentRow++;
                }

                if (!hasHitRight)
                {
                    currentCol++;
                }

                if (hasHitBottom)
                {
                    currentRow--;
                } 

                if (hasHitRight)
                {
                    currentCol--;
                }
            }

            return sum;
        }

        static void FillMatrix(long[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                var power = r;

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = (long)Math.Pow(2, power++);
                }
            }
        }
    }
}