namespace LinkedListStackQueue
{
    using System.Text;

    public class Queue<T>
    {
        private const int InitializeValue = 4;
        private T[] values;
        private int lastIndex;
        private int firstIndex;

        public Queue()
        {
            this.values = new T[InitializeValue];
            this.lastIndex = 0;
            this.firstIndex = 0;
        }

        public int Count
        {
            get
            {
                return this.lastIndex;
            }
        }

        public int Capacity
        {
            get
            {
                return this.values.Length;
            }
        }

        public void Enqueue(T item)
        {
            if (this.values.Length == this.lastIndex)
            {
                this.Resize();
            }

            this.values[this.lastIndex] = item;
            this.lastIndex++;
        }

        public T Peek()
        {
            return this.values[this.firstIndex];
        }

        public bool Contains(T item)
        {
            for (int i = this.firstIndex; i < this.lastIndex; i++)
            {
                if (this.values[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            this.values = new T[this.values.Length];
            this.firstIndex = 0;
            this.lastIndex = 0;
        }

        public T Dequeue()
        {
            var valueToReturn = this.values[this.firstIndex];
            this.firstIndex++;
            return valueToReturn;
        }

        public T[] ToArray()
        {
            var array = new T[this.lastIndex];

            for (int i = 0, j = this.firstIndex; i < this.lastIndex; i++, j++)
            {
                array[i] = this.values[j];
            }

            return array;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            for (int i = this.firstIndex; i < this.lastIndex; i++)
            {
                result.Append(this.values[i] + " ");
            }

            return result.ToString().Trim();
        }

        public void Trim()
        {
            var newValues = new T[this.lastIndex - this.firstIndex];

            for (int i = 0, j = this.firstIndex; i < newValues.Length; i++, j++)
            {
                newValues[i] = this.values[j];
            }

            this.firstIndex = 0;
            this.lastIndex = newValues.Length - 1;
            this.values = newValues;
        }

        private void Resize()
        {
            var newValues = new T[this.values.Length * 2];

            for (int i = 0, j = this.firstIndex; i < this.values.Length; i++, j++)
            {
                newValues[i] = this.values[j];
            }

            this.values = newValues;
        }
    }
}
