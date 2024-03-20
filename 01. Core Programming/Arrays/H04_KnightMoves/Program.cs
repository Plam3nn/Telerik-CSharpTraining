using System;

namespace H04_KnightMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            var board = new int[size, size];
            
            var currentRow = 0;
            var currentCol = 0;            
            board[currentRow, currentCol] = 1;

            var currentStep = 2;

            while (true)
            {
                // stop the loop if all squares on the board are populated
                if (currentStep == size * size + 1) 
                {
                    break;
                }

                var isPossibleTwoUpOneLeft = currentRow - 2 >= 0 && currentCol - 1 >= 0;
                var isPossibleTwoUpOneRight = currentRow - 2 >= 0 && currentCol + 1 < size;
                var isPossibleOneUpTwoLeft = currentRow - 1 >= 0 && currentCol - 2 >= 0;
                var isPossibleOneUpTwoRight = currentRow - 1 >= 0 && currentCol + 2 < size;
                var isPossibleOneDownTwoLeft = currentRow + 1 < size && currentCol - 2 >= 0;
                var isPossibleOneDownTwoRight = currentRow + 1 < size && currentCol + 2 < size;
                var isPossibleTwoDownOneLeft = currentRow + 2 < size && currentCol - 1 >= 0;
                var isPossibleTwoDownOneRight = currentRow + 2 < size && currentCol + 1 < size;

                var hasMoved = false;

                if (isPossibleTwoUpOneLeft 
                    && hasMoved == false
                    && board[currentRow - 2, currentCol - 1] == 0)
                {
                    hasMoved = true;
                    currentRow -= 2;
                    currentCol -= 1;
                }

                if (isPossibleTwoUpOneRight 
                    && hasMoved == false
                    && board[currentRow - 2, currentCol + 1] == 0)
                {
                    hasMoved = true;
                    currentRow -= 2;
                    currentCol += 1;
                }

                if (isPossibleOneUpTwoLeft 
                    && hasMoved == false
                    && board[currentRow - 1, currentCol - 2] == 0)
                {
                    hasMoved = true;
                    currentRow -= 1;
                    currentCol -= 2;
                }
                
                if (isPossibleOneUpTwoRight 
                    && hasMoved == false
                    && board[currentRow - 1, currentCol + 2] == 0)
                {
                    hasMoved = true;
                    currentRow -= 1;
                    currentCol += 2;
                }
                
                if (isPossibleOneDownTwoLeft 
                    && hasMoved == false
                    && board[currentRow + 1, currentCol - 2] == 0)
                {
                    hasMoved = true;
                    currentRow += 1;
                    currentCol -= 2;
                }
                
                if (isPossibleOneDownTwoRight 
                    && hasMoved == false
                    && board[currentRow + 1, currentCol + 2] == 0)
                {
                    hasMoved = true;
                    currentRow += 1;
                    currentCol += 2;
                }
                
                if (isPossibleTwoDownOneLeft 
                    && hasMoved == false
                    && board[currentRow + 2, currentCol - 1] == 0)
                {
                    hasMoved = true;
                    currentRow += 2;
                    currentCol -= 1;
                }
                
                if (isPossibleTwoDownOneRight 
                    && hasMoved == false
                    && board[currentRow + 2, currentCol + 1] == 0)
                {
                    hasMoved = true;
                    currentRow += 2;
                    currentCol += 1;
                }

                if (hasMoved == false)
                {
                    for (int row = 0; row < size; row++)
                    {
                        var isFound = false;

                        for (int col = 0; col < size; col++)
                        {
                            if (board[row, col] == 0)
                            {
                                isFound = true;
                                currentRow = row;
                                currentCol = col;
                                break;
                            }
                        }

                        if (isFound == true)
                        {
                            break;
                        }
                    }
                }

                board[currentRow, currentCol] = currentStep;
                currentStep++;
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(board[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
