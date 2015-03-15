namespace GenericClass
{
    using System;
    using System.Linq;

    public class GenericList<T> where T : IComparable
    {
        private const int InitialSize = 16;
        private const int StartIndex = 0;
        private const int MinCapacity = 2;

        private T[] elements;
        private int index;

        public GenericList()
            : this(GenericList<T>.InitialSize)
        {
        }

        public GenericList(int size)
        {
            if (size < GenericList<T>.MinCapacity)
            {
                throw new InvalidOperationException("Generic list cannot be smaller than 2");
            }

            this.elements = new T[size];
            this.index = GenericList<T>.StartIndex;
        }

        public int Count
        {
            get
            {
                return this.index;
            }
        }

        public int Capacity
        {
            get
            {
                return this.elements.Length;
            }
        }

        public T this[int currentIndex]
        {
            get
            {
                if (currentIndex < 0 || currentIndex >= this.Count)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }

                return this.elements[currentIndex];
            }

            set
            {
                if (currentIndex < 0 || currentIndex >= this.Count)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }

                this.elements[currentIndex] = value;
            }
        }

        public void Add(T element)
        {
            if (this.index == this.elements.Length)
            {
                this.ResizeElements();
            }

            this.elements[this.index] = element;
            this.index++;
        }

        public void Insert(int currentIndex, T element)
        {
            if (this.Count + 1 == this.Capacity)
            {
                this.ResizeElements();
            }

            this.index++;

            for (int i = currentIndex; i < this.index; i++)
            {
                T temp = this.elements[i];
                this.elements[i] = element;
                element = temp;
            }
        }

        public void RemoveElement(int currentIndex)
        {
            if (currentIndex < 0 || currentIndex >= this.index)
            {
                throw new ArgumentOutOfRangeException("Invalid index");
            }

            this.index--;

            for (int i = currentIndex; i < this.index; i++)
            {
                this.elements[i] = this.elements[i + 1];
                if (i + 1 == this.index)
                {
                    break;
                }
            }
        }

        public void Clear()
        {
            this.index = 0;
        }

        public int Find(T element)
        {
            for (int i = 0; i < this.index; i++)
            {
                if (this.elements[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public override string ToString()
        {
            T[] temp = this.GetTempValues(); 

            return string.Join(", ", temp);
        }

        public T Min()
        {
            if (this.Count == 0)
            {
                throw new IndexOutOfRangeException("GenericList is empty");
            }

            T[] temp = this.GetTempValues();

            var sorted = temp.OrderBy(x => x);
            return sorted.First();
        }

        public T Max()
        {
            if (this.Count == 0)
            {
                throw new IndexOutOfRangeException("GenericList is empty");
            }

            T[] temp = this.GetTempValues();

            var sorted = temp.OrderByDescending(x => x);
            return sorted.First();
        }

        private T[] GetTempValues()
        {
            T[] temp = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                temp[i] = this.elements[i];
            }

            return temp;
        }

        private void ResizeElements()
        {
            T[] newElements = new T[this.Capacity * 2];

            for (int i = 0; i < this.elements.Length; i++)
            {
                newElements[i] = this.elements[i];
            }

            this.elements = newElements;
        }
    }
}
