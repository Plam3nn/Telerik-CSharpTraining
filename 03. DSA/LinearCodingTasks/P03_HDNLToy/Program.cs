using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03_HDNLToy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberOfTags = int.Parse(Console.ReadLine());

            var tags = new string[numberOfTags];

            for (int i = 0; i < numberOfTags; i++)
            {
                tags[i] = Console.ReadLine();
            }

            var result = new StringBuilder();
            var indentationCounter = 0;
            var closingTags = new Stack<string>();

            for (int i = 0; i < tags.Length; i++)
            {
                var currentTag = tags[i];

                if (!closingTags.Any())
                {
                    result.AppendLine($"{new string(' ', indentationCounter++)}<{currentTag}>");
                    closingTags.Push(currentTag);
                    continue;
                }

                var currentTagLevel = int.Parse(currentTag.Substring(1));

                var previousTag = closingTags.Peek();
                var previousTagLevel = int.Parse(previousTag.Substring(1));

                if (currentTagLevel > previousTagLevel)
                {
                    result.AppendLine($"{new string(' ', indentationCounter++)}<{currentTag}>");
                    closingTags.Push(currentTag);
                }
                else
                {
                    result.AppendLine($"{new string(' ', --indentationCounter)}</{closingTags.Pop()}>");
                    i--;
                }
            }

            while (closingTags.Any())
            {
                result.AppendLine($"{new string(' ', --indentationCounter)}</{closingTags.Pop()}>");
            }

            Console.WriteLine(result);
        }
    }
}