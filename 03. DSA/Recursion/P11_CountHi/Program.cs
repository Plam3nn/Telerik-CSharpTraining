using System;

namespace P11_CountHi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var count = CountHi(text);
            Console.WriteLine(count);
        }

        private static int CountHi(string text)
        {
            var indexOfHi = text.IndexOf("hi");

            if (indexOfHi == -1)
            {
                return 0;
            }
            else
            {
                return 1 + CountHi(text.Substring(indexOfHi + 2));
            }
        }
    }
}
