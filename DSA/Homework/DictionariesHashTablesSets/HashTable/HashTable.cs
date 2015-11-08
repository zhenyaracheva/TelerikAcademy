namespace HashTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<TKey, TValue>
    {
        private const int InitizlizeCapacity = 16;
        private LinkedList<KeyValuePair<TKey, TValue>>[] values;
        private ICollection<TKey> keys;

        public HashTable(int capacity)
        {
            this.values = new LinkedList<KeyValuePair<TKey, TValue>>[capacity];
            this.keys = new SortedSet<TKey>();
        }

        public HashTable()
            : this(InitizlizeCapacity)
        {
        }

        public int Capacity
        {
            get
            {
                return this.values.Length;
            }
        }

        public int Count
        {
            get
            {
                return this.keys.Count;
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                return this.keys;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                if (!this.Find(key))
                {
                    throw new ArgumentOutOfRangeException("Cannot find key " + key);
                }

                foreach (var element in this.values[this.GetIndex(key)])
                {
                    if (element.Key.Equals(key))
                    {
                        return element.Value;
                    }
                }

                return default(TValue);
            }
        }

        public void Add(TKey key, TValue value)
        {
            if (this.Count > this.Capacity * 0.75)
            {
                this.ResizeValues();
            }

            var index = this.GetIndex(key);

            if (this.values[index] == null)
            {
                this.values[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }

            if (this.values[index].Where(x => x.Key.Equals(key)).Count() != 0)
            {
                throw new ArgumentOutOfRangeException("Hash table already contains key " + key);
            }

            var element = new KeyValuePair<TKey, TValue>(key, value);
            this.keys.Add(key);
            this.values[index].AddLast(element);
        }

        public void Remove(TKey key)
        {
            var index = this.GetIndex(key);

            if (this.values[index] != null)
            {
                foreach (var item in this.values[index])
                {
                    if (item.Key.Equals(key))
                    {
                        this.values[index].Remove(item);
                        this.keys.Remove(key);
                        break;
                    }
                }
            }
        }

        public bool Find(TKey key)
        {
            var index = this.GetIndex(key);

            if (this.values[index] != null)
            {
                foreach (var item in this.values[index])
                {
                    if (item.Key.Equals(key))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void Clear()
        {
            this.values = new LinkedList<KeyValuePair<TKey, TValue>>[this.values.Length];
            this.keys = new HashSet<TKey>();
        }

        private void ResizeValues()
        {
            var newTable = new HashTable<TKey, TValue>(this.values.Length * 2);

            foreach (var elements in this.values)
            {
                if (elements != null)
                {
                    foreach (var item in elements)
                    {
                        newTable.Add(item.Key, item.Value);
                    }
                }
            }

            this.values = newTable.values;
        }

        private int GetIndex(TKey key)
        {
            var index = key.GetHashCode() % this.Capacity;
            if (index < 0)
            {
                index *= -1;
            }

            return index;
        }
    }
}
