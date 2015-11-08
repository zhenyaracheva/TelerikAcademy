namespace LinkedListStackQueue.LinkedLIstImplementation
{
    public interface ILinkedList<T>
    {
        int Count { get; }

        T First { get; }

        T Last { get; }

        void AddFrist(T item);

        void AddLast(T item);

        void Clear();

        bool Contaians(T item);

        int Find(T item);

        int FindLast(T item);

        void Remove(T item);

        void RemoveFirst();

        void RemoveLast();
    }
}
