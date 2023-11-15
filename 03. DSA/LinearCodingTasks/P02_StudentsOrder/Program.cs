using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int swapsCount = int.Parse(input[1]);

        string[] studentNames = Console.ReadLine().Split(' ');

        Dictionary<string, LinkedListNode<string>> students = new Dictionary<string, LinkedListNode<string>>();
        LinkedList<string> seats = new LinkedList<string>();

        foreach (string student in studentNames)
        {
            students[student] = seats.AddLast(student);
        }

        for (int i = 1; i <= swapsCount; i++)
        {
            string[] swap = Console.ReadLine().Split(' ').ToArray();

            string studentOne = swap[0];
            string studentTwo = swap[1];

            seats.Remove(students[studentOne]);
            seats.AddBefore(students[studentTwo], students[studentOne]);

        }

        Console.WriteLine(String.Join(" ", seats));
    }
}