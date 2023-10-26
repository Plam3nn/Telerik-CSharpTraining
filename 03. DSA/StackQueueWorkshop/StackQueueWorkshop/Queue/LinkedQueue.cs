using System;

namespace StackQueueWorkshop.Queue
{
    public class LinkedQueue<T> : IQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;
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
                return this.Size == 0;
            }
        }

        public void Enqueue(T element)
        {
            var newNode = new Node<T>();
            newNode.Data = element;

            if (this.IsEmpty)
            {
                this.head = newNode;
                this.tail = newNode;                
            }
            else
            {
                this.tail.Next = newNode;
                this.tail = newNode;
            }

            this.size++;
        }

        public T Dequeue()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var removed = this.head;

            this.head = this.head.Next;
            this.size--;

            return removed.Data;
        }

        public T Peek()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return this.head.Data;
        }
    }
}
