namespace TreeTask
{
    using System.Collections.Generic;

    public class Node<T>
    {
        private T value;
        private List<Node<T>> children;
        private bool hasParent;
        private bool isLeaf;

        public Node(T value)
            : this()
        {
            this.value = value;
        }

        public Node()
        {
            this.children = new List<Node<T>>();
            this.isLeaf = true;
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public List<Node<T>> Children
        {
            get
            {
                return this.children;
            }
        }

        public bool HasParent
        {
            get
            {
                return this.hasParent;
            }
        }

        public bool IsLeaf
        {
            get
            {
                return this.isLeaf;
            }
        }

        public void AddChild(Node<T> child)
        {
            this.isLeaf = false;
            child.hasParent = true;
            this.children.Add(child);
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
