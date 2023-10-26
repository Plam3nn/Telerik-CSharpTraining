using System;

namespace StackQueueWorkshop.Stack
{
    public class LinkedStack<T> : IStack<T>
    {
        private Node<T> top;
        private int size;

        public int Size
        {
            get
            {
                return this.size;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.size == 0;
            }
        }

        public void Push(T element)
        {
            var newNode = new Node<T>();

            newNode.Data = element;
            newNode.Next = this.top;

            this.top = newNode;
            this.size++;
        }

        public T Pop()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            var removed = this.top;

            this.top = this.top.Next;
            this.size--;

            return removed.Data;
        }

        public T Peek()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return this.top.Data;
        }
    }
}
