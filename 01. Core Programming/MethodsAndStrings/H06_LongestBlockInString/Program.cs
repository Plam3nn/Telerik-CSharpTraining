using System;
using System.Linq;

namespace H06_LongestBlockInString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var input = Console.ReadLine();
            var longestBlock = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                var currentBlock = string.Empty;
                var currentChar = input[i];
                
                for (int j = i; j < input.Length; j++)
                {
                    var comparingChar = input[j];

                    if (currentChar == comparingChar)
                    {
                        currentBlock += currentChar;
                    }
                    else
                    {
                        i = j - 1;
                        break;
                    }
                }

                if (currentBlock.Length > longestBlock.Length)
                {
                    longestBlock = currentBlock;
                }
            }

            Console.WriteLine(longestBlock);
        }
    }
}
