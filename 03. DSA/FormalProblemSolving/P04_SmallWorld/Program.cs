using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_SmallWorld
{
    internal class Program
    {
        private static int[,] matrix;
        private static List<int> sequences = new List<int>();

        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            matrix = new int[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowInput = Console.ReadLine()
                .ToCharArray()
                .Select(x => int.Parse(x.ToString()))
                .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var sequenceLength = GetSequence(row, col);

                    if (sequenceLength != 0)
                    {
                        sequences.Add(sequenceLength);
                    }
                }
            }

            foreach (var sequence in sequences.OrderByDescending(x => x))
            {
                Console.WriteLine(sequence);
            }
        }

        static int GetSequence(int row, int col)
        {
            if (row < 0
                || row >= matrix.GetLength(0)
                || col < 0
                || col >= matrix.GetLength(1)
                || matrix[row, col] == 0
                )
            {
                return 0;
            }

            matrix[row, col] = 0;
            var size = 1;

            size += GetSequence(row, col - 1);
            size += GetSequence(row, col + 1);
            size += GetSequence(row - 1, col);
            size += GetSequence(row + 1, col);

            return size;
        }
    }
}
