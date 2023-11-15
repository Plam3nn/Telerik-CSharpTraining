using System;
using System.Linq;

namespace P16_ScroogeMcDuck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var field = new int[dimensions[0], dimensions[1]];

            var startingPositionRowIndex = 0;
            var startingPositionColIndex = 0;

            FillMatrix(field);
            GetStartingPosition(field, ref startingPositionRowIndex, ref startingPositionColIndex);            

            var totalCoins = CollectCoins(field, startingPositionRowIndex, startingPositionColIndex);
            Console.WriteLine(totalCoins);
        }        

        private static int CollectCoins(int[,] field, int currentRowIndex, int currentColIndex)
        {
            var canMoveLeft = currentColIndex - 1 >= 0;
            var canMoveRight = currentColIndex + 1 < field.GetLength(1);
            var canMoveUp = currentRowIndex - 1 >= 0;
            var canMoveDown = currentRowIndex + 1 < field.GetLength(0);

            var mostCoins = 0;
            var nextRowIndex = currentRowIndex;
            var nextColIndex = currentColIndex;

            if (canMoveLeft)
            {
                var leftCoins = field[currentRowIndex, currentColIndex - 1];

                if (leftCoins > mostCoins)
                {
                    mostCoins = leftCoins;
                    nextColIndex = currentColIndex - 1;
                }                
            }
            
            if (canMoveRight)
            {
                var rightCoins = field[currentRowIndex, currentColIndex + 1];

                if (rightCoins > mostCoins)
                {
                    mostCoins = rightCoins;
                    nextColIndex = currentColIndex + 1;
                }
            }

            if (canMoveUp)
            {
                var upCoins = field[currentRowIndex - 1, currentColIndex];

                if (upCoins > mostCoins)
                {
                    mostCoins = upCoins;
                    nextRowIndex = currentRowIndex - 1;
                    nextColIndex = currentColIndex;
                }
            }

            if (canMoveDown)
            {
                var downCoins = field[currentRowIndex + 1, currentColIndex];

                if (downCoins > mostCoins)
                {
                    mostCoins = downCoins;
                    nextRowIndex = currentRowIndex + 1;
                    nextColIndex = currentColIndex;
                }
            }

            if (mostCoins == 0)
            {
                return 0;
            }

            field[nextRowIndex, nextColIndex] -= 1;

            return CollectCoins(field, nextRowIndex, nextColIndex) + 1;
        }

        private static void GetStartingPosition(int[,] field, ref int startingPositionRowIndex, ref int startingPositionColIndex)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 0)
                    {
                        startingPositionRowIndex = row;
                        startingPositionColIndex = col;
                    }
                }
            }
        }

        private static void FillMatrix(int[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                var rowInput = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < rowInput.Length; col++)
                {
                    field[row, col] = rowInput[col];
                }
            }
        }
    }
}
