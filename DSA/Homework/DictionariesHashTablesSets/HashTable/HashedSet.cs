namespace HashTable
{
    public class HashedSet<T>
    {
        private HashTable<T, T> data;

        public HashedSet()
        {
            this.data = new HashTable<T, T>();
        }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        public void Add(T item)
        {
            this.data.Add(item, item);
        }

        public bool Find(T item)
        {
            return this.data.Find(item);
        }

        public void Remove(T item)
        {
            this.data.Remove(item);
        }

        public void Clear()
        {
            this.data.Clear();
        }

        public HashedSet<T> Union(HashedSet<T> otherSet)
        {
            var newSet = new HashedSet<T>();

            foreach (var key in otherSet.data.Keys)
            {
                newSet.Add(key);
            }

            foreach (var key in this.data.Keys)
            {
                if (!otherSet.Find(key))
                {
                    newSet.Add(key);
                }
            }

            return newSet;
        }

        public HashedSet<T> Intersect(HashedSet<T> other)
        {
            var newSet = new HashedSet<T>();
            foreach (var key in this.data.Keys)
            {
                if (other.Find(key) && this.Find(key))
                {
                    newSet.Add(key);
                }
            }

            return newSet;
        }

        public override string ToString()
        {
            return string.Join(", ", this.data.Keys);
        }
    }
}
