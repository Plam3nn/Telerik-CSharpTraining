using StackQueueWorkshop.Queue;
using StackQueueWorkshop.Stack;
using System;

class Program
{
    static void Main(string[] args)
    {
        var queue = new LinkedQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);


        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Peek());
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());
    }
}
