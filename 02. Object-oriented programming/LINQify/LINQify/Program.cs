using System;
using System.Collections.Generic;
using LINQify.Tasks;

namespace LINQify
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = Helper.GetData();

            //You can test your implementations here:

            var result1 = Task12.Execute(people);
            var result2 = Task12.ExecuteWithLINQ(people);

            PrintResult(result1);
            Console.WriteLine(new string('-', 10));
            PrintResult(result2);
        }

        private static void PrintResult(List<Person> result)
        {
            foreach (var person in result)
            {
                Console.WriteLine(person);
                Console.WriteLine();
            }
        }
    }
}