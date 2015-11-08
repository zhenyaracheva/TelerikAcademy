namespace PriorityQueueTask
{
    using System;
    using System.Text;

    public class PriorityQueue<T>
        where T : IComparable
    {
        private const int InitializeSize = 16;
        private T[] data;
        private int index;

        public PriorityQueue()
        {
            this.data = new T[InitializeSize];
            this.index = 0;
        }

        public int Count
        {
            get
            {
                return this.index;
            }
        }

        public void Add(T item)
        {
            if (this.index >= this.data.Length)
            {
                this.Resize();
            }

            this.data[this.index] = item;
            var childIndex = this.index;
            var parentIndex = (childIndex - 1) / 2;

            while (parentIndex >= 0 && this.data[parentIndex].CompareTo(this.data[childIndex]) > 0)
            {
                T swapValue = this.data[parentIndex];
                this.data[parentIndex] = this.data[childIndex];
                this.data[childIndex] = swapValue;

                childIndex = parentIndex;
                parentIndex = (childIndex - 1) / 2;
            }

            this.index++;
        }

        public T Remove()
        {
            var elementToRemove = this.data[0];

            if (this.index == 0)
            {
                throw new ArgumentOutOfRangeException("Cannot remove element from empty queue!");
            }

            this.data[0] = this.data[this.index - 1];
            var parentIndex = 0;

            while (true)
            {
                var leftChildIndex = (2 * parentIndex) + 1;
                var rightChildIndex = (2 * parentIndex) + 2;

                int minElementIndex;

                if (leftChildIndex > this.index - 1 && rightChildIndex > this.index - 1)
                {
                    break;
                }
                else if (leftChildIndex > this.index - 1)
                {
                    minElementIndex = rightChildIndex;
                }
                else if (rightChildIndex > this.index - 1)
                {
                    minElementIndex = leftChildIndex;
                }
                else
                {
                    minElementIndex = this.data[rightChildIndex].CompareTo(this.data[leftChildIndex]) < 0 ? rightChildIndex : leftChildIndex;
                }

                if (this.data[parentIndex].CompareTo(this.data[minElementIndex]) < 0)
                {
                    break;
                }

                T swap = this.data[parentIndex];
                this.data[parentIndex] = this.data[minElementIndex];
                this.data[minElementIndex] = swap;
                parentIndex = minElementIndex;
            }

            this.index--;
            return elementToRemove;
        }

        public T Peek()
        {
            if (this.index == 0)
            {
                throw new ArgumentOutOfRangeException("Empty queue!");
            }

            return this.data[0];
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            for (int i = 0; i < this.index; i++)
            {
                result.Append(this.data[i] + " ");
            }

            return result.ToString().Trim();
        }

        private void Resize()
        {
            var newData = new T[this.data.Length * 2];

            for (int i = 0; i < this.data.Length; i++)
            {
                newData[i] = this.data[i];
            }

            this.data = newData;
        }
    }
}
