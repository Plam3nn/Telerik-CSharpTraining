using System;

namespace StackQueueWorkshop.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        private T[] items;
        private int top;
        private int capacity;

        public ArrayStack()
        {
            this.capacity = 8;

            this.items = new T[this.capacity];
            this.top = -1;
        }

        public int Size
        {
            get
            {
                return this.top + 1;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.top < 0;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public void Push(T element)
        {
            if (this.Size == capacity)
            {
                this.items = this.Resize();
            }

            this.items[++top] = element;
        }

        public T Pop()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return this.items[this.top--];
        }

        public T Peek()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return this.items[this.top];
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
