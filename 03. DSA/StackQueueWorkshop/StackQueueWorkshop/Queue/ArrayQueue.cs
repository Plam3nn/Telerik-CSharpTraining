using System;
using System.Diagnostics;

namespace StackQueueWorkshop.Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private T[] items;
        private int tail;
        private int capacity;

        public ArrayQueue()
        { 
            this.capacity = 8;

            this.items = new T[capacity];
            this.tail = -1;
        }

        public int Size
        {
            get
            {
                return this.tail + 1;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.Size == 0;
            }
        }

        public void Enqueue(T element)
        {
            if (this.Size == capacity)
            {
                this.items = this.Resize();
            }

            this.items[++tail] = element;
        }

        public T Dequeue()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var removed = this.items[0];

            for (int i = 0; i < this.Size - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.tail--;

            return removed;
        }

        public T Peek()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return this.items[0];
        }

        private T[] Resize()
        {
            this.capacity *= 2;

            var resized = new T[capacity];

            for (int i = 0; i < this.items.Length; i++)
            {
                resized[i] = this.items[i];
            }

            return resized;
        }
    }
}
