using System;
using System.Linq;

namespace P17_LargestSurface
{
    internal class Program
    {
        private static int[,] matrix;
        private static bool[,] visited;

        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            matrix = new int[dimensions[0], dimensions[1]];
            visited = new bool[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            var maxSize = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {                
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var currentSize = GetSequenceSize(row, col, matrix[row, col]);

                    if (currentSize > maxSize)
                    {
                        maxSize = currentSize;
                    }
                }                
            }

            Console.WriteLine(maxSize);
        }

        private static int GetSequenceSize(int row, int col, int target)
        {
            if (row < 0
                || row >= matrix.GetLength(0)
                || col < 0
                || col >= matrix.GetLength(1)
                || visited[row, col]
                || matrix[row, col] != target)
            {
                return 0;
            }

            visited[row, col] = true;
            int size = 1;            

            size += GetSequenceSize(row, col - 1, target);
            size += GetSequenceSize(row, col + 1, target);
            size += GetSequenceSize(row - 1, col, target);
            size += GetSequenceSize(row + 1, col, target);

            return size;
        }
    }
}
