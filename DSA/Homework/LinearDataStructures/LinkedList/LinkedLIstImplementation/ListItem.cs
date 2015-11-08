﻿namespace LinkedListStackQueue.LinkedLIstImplementation
{
    public class ListItem<T>
    {
        public T Value { get; set; }

        public ListItem<T> Previous { get; set; }

        public ListItem<T> Next { get; set; }
    }
}
