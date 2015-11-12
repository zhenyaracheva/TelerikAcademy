namespace BiDictionary
{
    public class KeyValueTuple<K1, K2, V>
    {
        public KeyValueTuple(K1 key1, K2 key2, V value)
        {
            this.Key1 = key1;
            this.Key2 = key2;
            this.Value = value;
        }

        public K1 Key1 { get; set; }

        public K2 Key2 { get; set; }

        public V Value { get; set; }
    }
}
