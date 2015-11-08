namespace LinkedListStackQueue
{
    using System.Text;

    public class Stack<T>
    {
        private const int InitializeValue = 4;
        private T[] values;
        private int lastIndex;

        public Stack()
        {
            this.values = new T[InitializeValue];
            this.lastIndex = 0;
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

        public void Push(T item)
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
            return this.values[this.lastIndex - 1];
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.lastIndex; i++)
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
            this.lastIndex = 0;
        }

        public T Pop()
        {
            var valueToReturn = this.values[this.lastIndex];
            this.lastIndex--;
            return valueToReturn;
        }

        public T[] ToArray()
        {
            var array = new T[this.lastIndex];

            for (int i = 0; i < this.lastIndex; i++)
            {
                array[i] = this.values[i];
            }

            return array;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            for (int i = 0; i < this.lastIndex; i++)
            {
                result.Append(this.values[i] + " ");
            }

            return result.ToString().Trim();
        }

        public void Trim()
        {
            var newValues = new T[this.lastIndex];

            for (int i = 0; i < newValues.Length; i++)
            {
                newValues[i] = this.values[i];
            }

            this.lastIndex = newValues.Length;
            this.values = newValues;
        }

        private void Resize()
        {
            var newValues = new T[this.values.Length * 2];

            for (int i = 0; i < this.values.Length; i++)
            {
                newValues[i] = this.values[i];
            }

            this.values = newValues;
        }
    }
}
