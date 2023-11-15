using System;

namespace P10_CountX
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var count = CountX(text, 0);
            Console.WriteLine(count);
        }

        private static int CountX(string text, int startIndex)
        {
            if (startIndex == text.Length)
            {
                return 0 ;
            }

            if (text[startIndex] == 'x')
            {
                return 1 + CountX(text, ++startIndex);
            }

            return CountX(text, ++startIndex);
        }
    }
}
