using System;
using System.Collections.Generic;
using System.Text;

namespace P03_DoctorsOffice
{
    internal class Program
    {
        private static LinkedList<string> queue = new LinkedList<string>();

        static void Main(string[] args)
        {
            var result = new StringBuilder();

            while (true)
            {
                var input = Console.ReadLine().Split();
                var commandType = input[0];

                if (commandType == "Append")
                {
                    var name = input[1];

                    queue.AddLast(name);
                    result.AppendLine("OK");
                }
                else if (commandType == "Insert")
                {
                    var position = int.Parse(input[1]);
                    var name = input[2];

                    result.AppendLine(Insert(position, name));
                }
                else if (commandType == "Find")
                {
                    var name = input[1];
                    result.AppendLine(Find(name).ToString());
                }
                else if (commandType == "Examine")
                {
                    var count = int.Parse(input[1]);
                    result.AppendLine(Examine(count));
                }
                else if (commandType == "End")
                {
                    Console.WriteLine(result.ToString());
                    return;
                }
            }
        }

        static string Examine(int count)
        {
            if (count < 0 || count > queue.Count)
            {
                return "Error";
            }

            var examined = new StringBuilder();

            while (true)
            {
                if (count == 0)
                {
                    break;
                }

                examined.Append(queue.First.Value + " ");
                queue.RemoveFirst();
                count--;
            }

            return examined.ToString().TrimEnd();
        }

        static int Find(string name)
        {
            var current = queue.First;
            var occurences = 0;

            while (current != null)
            {
                if (current.Value == name)
                {
                    occurences++;
                }

                current = current.Next;
            }

            return occurences;
        }

        static string Insert(int position, string name)
        {
            if (position < 0 || position > queue.Count)
            {
                return "Error";
            }

            if (position == queue.Count)
            {
                queue.AddLast(name);
            }
            else if (position == 0)
            {
                queue.AddFirst(name);
            }
            else
            {
                var current = queue.First;

                for (int i = 0; i < position; i++)
                {
                    current = current.Next;
                }

                queue.AddBefore(current, new LinkedListNode<string>(name));
            }

            return "OK";
        }
    }
}