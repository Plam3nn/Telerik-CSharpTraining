using System;
using System.Collections;

namespace DoublyLinkedListWorkshop
{
    public class LinkedList<T> : IList<T>
    {
        private Node head;
        private Node tail;

        private int count;

        public T Head
        {
            get
            {
                return this.head == null ? throw new InvalidOperationException("Cannot get Head because the list is empty.") : this.head.Value;
            }
        }

        public T Tail
        {
            get
            {
                return this.tail == null ? throw new InvalidOperationException("Cannot get Tail because the list is empty.") : this.tail.Value;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
            private set
            {
                this.count = value;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.Count == 0;
            }
        }

        public void AddFirst(T value)
        {
            Node newNode = new Node(value);

            if (this.IsEmpty)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                newNode.Next = this.head;

                this.head.Prev = newNode;
                this.head = newNode;
            }

            this.Count++;
        }

        public void AddLast(T value)
        {
            Node newNode = new Node(value);

            if (this.IsEmpty)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                newNode.Prev = this.tail;

                this.tail.Next = newNode;
                this.tail = newNode;
            }
 
            this.Count++;
        }

        public void Add(int index, T value)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid index.");
            }

            if (index == 0)
            {
                this.AddFirst(value);
                return;
            }

            if (index == this.Count)
            {
                this.AddLast(value);
                return;
            }

            Node currentNode = this.head;

            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            Node newNode = new Node(value);

            newNode.Next = currentNode;
            newNode.Prev = currentNode.Prev;
            currentNode.Prev.Next = newNode;
            currentNode.Prev = newNode;

            this.Count++;
        }

        public T Get(int index)
        {
            int currentIndex = 0;
            Node currentNode = this.head;

            while (true)
            {
                if (currentNode == null)
                {
                    throw new ArgumentOutOfRangeException("Such index does not exist.");
                }

                if (currentIndex == index)
                {
                    break;
                }

                currentNode = currentNode.Next;
                currentIndex++;
            }

            return currentNode.Value;
        }

        public int IndexOf(T value)
        {
            int currentIndex = 0;
            Node currentNode = this.head;

            while (true)
            {
                if (currentNode == null)
                {
                    return -1;
                }

                if (currentNode.Value.Equals(value))
                {
                    break;
                }

                currentIndex++;
                currentNode = currentNode.Next;
            }

            return currentIndex;
        }

        public T RemoveFirst()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("Cannot remove because the list is empty.");
            }

            T value = this.head.Value;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.head = this.head.Next;
                this.head.Prev = null;
            }

            this.Count--;
            return value;
        }

        public T RemoveLast()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("Cannot remove because the list is empty.");
            }

            T value = this.tail.Value;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.tail = this.tail.Prev;
                this.tail.Next = null;
            }

            this.Count--;
            return value;
        }

        /// <summary>
        /// Enumerates over the linked list values from Head to Tail
        /// </summary>
        /// <returns>A Head to Tail enumerator</returns>
        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
        {
            return new ListEnumerator(this.head);
        }

        /// <summary>
        /// Enumerates over the linked list values from Head to Tail
        /// </summary>
        /// <returns>A Head to Tail enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((System.Collections.Generic.IEnumerable<T>)this).GetEnumerator();
        }

        // Use private nested class so that LinkedList users
        // don't know about the LinkedList internal structure
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value
            {
                get;
                private set;
            }

            public Node Next
            {
                get;
                set;
            }

            public Node Prev
            {
                get;
                set;
            }
        }

        // List enumerator that enables traversing all nodes of a list in a foreach loop
        private class ListEnumerator : System.Collections.Generic.IEnumerator<T>
        {
            private Node start;
            private Node current;

            internal ListEnumerator(Node head)
            {
                this.start = head;
                this.current = null;
            }

            public T Current
            {
                get
                {
                    if (this.current == null)
                    {
                        throw new InvalidOperationException();
                    }
                    return this.current.Value;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return this.Current;
                }
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (current == null)
                {
                    current = this.start;
                    return true;
                }

                if (current.Next == null)
                {
                    return false;
                }

                current = current.Next;
                return true;
            }

            public void Reset()
            {
                this.current = null;
            }
        }
    }
}