using System;

namespace P12_ChangePi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var result = ReplaceAll(text, "pi", "3.14");

            Console.WriteLine(result);
        }

        private static string ReplaceAll(string text, string oldValue, string newValue)
        {
            var indexOfStringToReplace = text.IndexOf(oldValue);

            if (indexOfStringToReplace == -1)
            {                
                return text;
            }

            //var previousText = text.Substring(0, indexOfStringToReplace);
            //var remainingText = text.Substring(indexOfStringToReplace + oldValue.Length);
            //var nexpiwText = previousText + newValue + remainingText;

            //return ReplaceAll(newText, oldValue, newValue);

            if (text.Substring(0, oldValue.Length) == oldValue)
            {
                return newValue + ReplaceAll(text.Substring(oldValue.Length), oldValue, newValue);
            }

            return text[0] + ReplaceAll(text.Substring(1), oldValue, newValue);
        }
    }
}
