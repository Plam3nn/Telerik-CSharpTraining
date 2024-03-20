using System;
using System.Linq;
using System.Numerics;

namespace H03_Navigation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = new BigInteger[rows, cols];
            FillMatrix(matrix);

            var numberOfCodes = int.Parse(Console.ReadLine());

            var codes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var currentRow = matrix.GetLength(0) - 1;
            var currentCol = 0;
            var sum = matrix[currentRow, currentCol];
            matrix[currentRow, currentCol] = 0;

            var coefficient = Math.Max(rows, cols);
            
            for (int i = 0; i < numberOfCodes; i++)               
            {
                var currentCode = codes[i];
                var row = CalculateRow(currentCode, coefficient);
                var col = CalculateCol(currentCode, coefficient);

                if (currentCol < col)
                {
                    //Move right
                    var moves = col - currentCol;

                    for (int j = 0; j < moves; j++)
                    {
                        currentCol++;
                        sum += matrix[currentRow, currentCol];
                        matrix[currentRow, currentCol] = 0;                        
                    }
                }
                else if (currentCol > col)
                {
                    //Move left
                    var moves = currentCol - col;

                    for (int j = 0; j < moves; j++)
                    {
                        currentCol--;
                        sum += matrix[currentRow, currentCol];
                        matrix[currentRow, currentCol] = 0;
                    }
                }

                if (currentRow > row)
                {
                    //Move up
                    var moves = currentRow - row;

                    for (int j = 0; j < moves; j++)
                    {
                        currentRow--;
                        sum += matrix[currentRow, currentCol];
                        matrix[currentRow, currentCol] = 0;
                    }
                }
                else if (currentRow < row)
                {
                    //Move down
                    var moves = row - currentRow;

                    for (int j = 0; j < moves; j++)
                    {
                        currentRow++;
                        sum += matrix[currentRow, currentCol];
                        matrix[currentRow, currentCol] = 0;
                    }
                }
            }

            Console.WriteLine(sum);
        }

        static int CalculateRow(int code, int coefficient)
        {
            return code / coefficient;
        }

        static int CalculateCol(int code, int coefficient)
        {
            return code % coefficient;
        }

        static void FillMatrix(BigInteger[,] matrix)
        {
            var rowStartPower = 0L;

            for (int r = matrix.GetLength(0) - 1; r >= 0; r--)            
            {
                var currentRowStartPower = rowStartPower;

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = (BigInteger)Math.Pow(2, currentRowStartPower);
                    currentRowStartPower++;
                }

                rowStartPower++;
            }
        }
    }
}
