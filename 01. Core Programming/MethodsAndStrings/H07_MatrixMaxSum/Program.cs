using System;
using System.Linq;

namespace H07_MatrixMaxSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var matrix = CreateMatrix(rows);

            var coordinates = ReadRowOfIntegers();

            var maxSum = int.MinValue;
            FindMaxSum(matrix, coordinates, ref maxSum);

            Console.WriteLine(maxSum);
        }

        static int[] ReadRowOfIntegers()
        {
            return Console.ReadLine().Split().Select(int.Parse).ToArray();
        }

        static int[][] CreateMatrix(int rows)
        {
            var matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                var inputRow = ReadRowOfIntegers();

                for (int col = 0; col < inputRow.Length; col++)
                {
                    matrix[row] = inputRow;
                }
            }

            return matrix;
        }

        static void FindMaxSum(int[][] matrix, int[] coordinates, ref int maxSum)
        {
            for (int i = 0; i < coordinates.Length; i += 2)
            {
                var row = coordinates[i];
                var col = coordinates[i + 1];

                var tempRow = Math.Abs(row) - 1;
                var tempCol = Math.Abs(col) - 1;

                var currentSum = 0;

                if (row > 0)
                {
                    MoveForward(matrix, tempRow, tempCol, ref currentSum);
                }
                else if (row < 0)
                {
                    MoveBackwards(matrix, tempRow, tempCol, ref currentSum);
                }

                if (col > 0)
                {
                    MoveUp(matrix, tempRow, tempCol, ref currentSum);
                }
                else if (col < 0)
                {
                    MoveDown(matrix, tempRow, tempCol, ref currentSum);
                }


                CheckForBiggerSum(ref currentSum, ref maxSum);
            }
        }

        static void CheckForBiggerSum(ref int currentSum, ref int maxSum)
        {
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
            }
        }

        private static void MoveDown(int[][] matrix, int tempRow, int tempCol, ref int currentSum)
        {
            for (int j = tempRow + 1; j < matrix.GetLength(0); j++)
            {
                currentSum += matrix[j][tempCol];
            }
        }

        private static void MoveUp(int[][] matrix, int tempRow, int tempCol, ref int currentSum)
        {
            for (int j = tempRow - 1; j >= 0; j--)
            {
                currentSum += matrix[j][tempCol];
            }
        }

        private static void MoveBackwards(int[][] matrix, int tempRow, int tempCol, ref int currentSum)
        {
            for (int j = matrix[tempRow].Length - 1; j >= tempCol; j--)
            {
                currentSum += matrix[tempRow][j];
            }
        }

        private static void MoveForward(int[][] matrix, int tempRow, int tempCol, ref int currentSum)
        {
            for (int j = 0; j <= tempCol; j++)
            {
                currentSum += matrix[tempRow][j];
            }
        }
    }
}
