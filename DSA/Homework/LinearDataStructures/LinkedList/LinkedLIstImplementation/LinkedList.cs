namespace LinkedListStackQueue.LinkedLIstImplementation
{
    using System.Text;

    public class LinkedList<T> : ILinkedList<T>, System.Collections.Generic.IEnumerable<T>
    {
        private ListItem<T> head;
        private ListItem<T> tail;
        private int count;

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public T First
        {
            get
            {
                return this.head.Value;
            }
        }

        public T Last
        {
            get
            {
                return this.tail.Value;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void AddFrist(T item)
        {
            var newItem = new ListItem<T>
            {
                Value = item
            };

            if (this.head == null && this.tail == null)
            {
                this.head = newItem;
                this.tail = newItem;
            }
            else
            {
                this.head.Previous = newItem;
                newItem.Next = this.head;
                this.head = newItem;
            }

            this.count++;
        }

        public void AddLast(T item)
        {
            var newItem = new ListItem<T>
            {
                Value = item
            };

            if (this.head == null && this.tail == null)
            {
                this.head = newItem;
                this.tail = newItem;
            }
            else
            {
                this.tail.Next = newItem;
                newItem.Previous = this.tail;
                this.tail = newItem;
            }

            this.count++;
        }

        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public bool Contaians(T item)
        {
            var node = this.head;
            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    return true;
                }

                node = node.Next;
            }

            return false;
        }

        public int Find(T item)
        {
            var index = 0;
            var node = this.head;
            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    return index;
                }

                node = node.Next;
                index++;
            }

            return -1;
        }

        public int FindLast(T item)
        {
            var index = 0;
            int lastIndex = -1;
            var node = this.head;
            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    lastIndex = index;
                }

                node = node.Next;
                index++;
            }

            return lastIndex;
        }

        public void Remove(T item)
        {
            var node = this.head;

            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    this.count--;

                    if (node.Next != null && node.Previous != null)
                    {
                        node.Previous.Next = node.Next;
                        node.Next.Previous = node.Previous;
                        node = node.Previous;
                        continue;
                    }
                    else if (node.Previous != null && node.Next == null)
                    {
                        node.Previous.Next = null;
                        this.tail = node.Previous;
                        node = node.Previous;
                        continue;
                    }
                    else if (node.Previous == null && node.Next != null)
                    {
                        node.Next.Previous = null;
                        this.head = node.Next;
                    }
                }

                node = node.Next;
            }
        }

        public void RemoveFirst()
        {
            if (this.head != null && this.head.Next != null)
            {
                this.head.Next.Previous = null;
                this.head = this.head.Next;
            }
            else if (this.head != null)
            {
                this.head = null;
                this.tail = null;
            }

            this.count--;
        }

        public void RemoveLast()
        {
            if (this.tail != null && this.tail.Previous != null)
            {
                this.tail.Previous.Next = null;
                this.tail = this.tail.Previous;
            }
            else if (this.tail != null)
            {
                this.head = null;
                this.tail = null;
            }

            this.count--;
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            var node = this.head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            var buider = new StringBuilder();
            var node = this.head;
            while (node != null)
            {
                buider.Append(node.Value + " ");
                node = node.Next;
            }

            return buider.ToString().Trim();
        }
    }
}
