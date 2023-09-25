    using System;

    namespace P03_AboveTheMainDiagonal
    {
        class Program
        {
            static void Main(string[] args)
            {
                var dimensions = int.Parse(Console.ReadLine());

                var matrix = new long[dimensions, dimensions];   
                var sum = 0L;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    var currentPower = row;

                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = (long)Math.Pow(2, currentPower++);
                    
                        if (col > row)
                        {
                            sum += matrix[row, col];
                        }
                    }
                }

                Console.WriteLine(sum);
            }
        }
    }
