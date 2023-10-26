using Boarder.Loggers;
using Boarder.Models;
using System;

namespace Boarder
{
    class Program
    {
        static void Main(string[] args)
        {
            //var tomorrow = DateTime.Now.AddDays(1);
            BoardItem task = new Task("Write unit tests", "Peter", Convert.ToDateTime("01-01-2025"));
            //BoardItem issue = new Issue("Review tests", "Someone must review Peter's tests.", tomorrow);

            Console.WriteLine(task.ViewHistory());            
            //Console.WriteLine(issue.ViewInfo());
        }
    }
}
