namespace BiDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class BiDictionary<K1, K2, V>
    {
        private MultiDictionary<K1, KeyValueTuple<K1, K2, V>> key1;
        private MultiDictionary<K2, KeyValueTuple<K1, K2, V>> key2;
        private MultiDictionary<Tuple<K1, K2>, KeyValueTuple<K1, K2, V>> key1Key2;

        public BiDictionary(bool allowDublicateValues)
        {
            this.key1 = new MultiDictionary<K1, KeyValueTuple<K1, K2, V>>(allowDublicateValues);
            this.key2 = new MultiDictionary<K2, KeyValueTuple<K1, K2, V>>(allowDublicateValues);
            this.key1Key2 = new MultiDictionary<Tuple<K1, K2>, KeyValueTuple<K1, K2, V>>(allowDublicateValues);
        }

        public ICollection<KeyValueTuple<K1, K2, V>> Values
        {
            get
            {
                return this.key1Key2.Values.ToArray();
            }
        }

        public int Count
        {
            get
            {
                return this.key1Key2.KeyValuePairs.Count;
            }
        }

        public void Add(K1 key1, K2 key2, V value)
        {
            var tuple = new KeyValueTuple<K1, K2, V>(key1, key2, value);
            var key1Key2 = new Tuple<K1, K2>(key1, key2);

            this.key1[key1].Add(tuple);
            this.key2[key2].Add(tuple);
            this.key1Key2[key1Key2].Add(tuple);
        }

        public ICollection<V> GetByFirstKey(K1 key1)
        {
            return this.key1[key1].Select(a => a.Value).ToArray();
        }

        public ICollection<V> GetBySecondKey(K2 key2)
        {
            return this.key2[key2].Select(a => a.Value).ToArray();
        }

        public ICollection<V> GetByTwoKeys(K1 key1, K2 key2)
        {
            return this.key1Key2[new Tuple<K1, K2>(key1, key2)].Select(a => a.Value).ToArray();
        }

        public void RemoveByFirstKey(K1 key1)
        {
            var values = this.key1[key1];

            foreach (var tuple in values)
            {
                this.key2.Remove(tuple.Key2, tuple);
                this.key1Key2.Remove(new Tuple<K1, K2>(tuple.Key1, tuple.Key2), tuple);
            }

            this.key1.Remove(key1);
        }

        public void RemoveBySecondKey(K2 key2)
        {
            var values = this.key2[key2];

            foreach (var tuple in values)
            {
                this.key1.Remove(tuple.Key1, tuple);
                this.key1Key2.Remove(new Tuple<K1, K2>(tuple.Key1, tuple.Key2), tuple);
            }

            this.key2.Remove(key2);
        }

        public void RemoveByTwoKeys(K1 key1, K2 key2)
        {
            var tuple = new Tuple<K1, K2>(key1, key2);
            var values = this.key1Key2[tuple];

            foreach (var value in values)
            {
                this.key1.Remove(key1, value);
                this.key2.Remove(key2, value);
            }

            this.key1Key2.Remove(tuple);
        }

        public void Clear()
        {
            this.key1.Clear();
            this.key2.Clear();
            this.key1Key2.Clear();
        }
    }
}