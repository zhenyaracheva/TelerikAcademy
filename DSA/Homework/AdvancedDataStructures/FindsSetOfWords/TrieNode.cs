namespace FindsSetOfWords
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public class TrieNode : IComparable<TrieNode>
    {
        private char letter;
        private int wordCount;
        private TrieNode parent = null;
        private ConcurrentDictionary<char, TrieNode> children = null;

        public TrieNode(TrieNode parent, char letter)
        {
            this.letter = letter;
            this.wordCount = 0;
            this.parent = parent;
            this.children = new ConcurrentDictionary<char, TrieNode>();
        }

        public int WordCount
        {
            get
            {
                return this.wordCount;
            }
        }

        public void AddWord(string word, int index = 0)
        {
            if (index < word.Length)
            {
                char key = word[index];
                if (char.IsLetter(key))
                {
                    if (!this.children.ContainsKey(key))
                    {
                        this.children.TryAdd(key, new TrieNode(this, key));
                    }

                    this.children[key].AddWord(word, index + 1);
                }
                else
                {
                    this.AddWord(word, index + 1);
                }
            }
            else
            {
                if (this.parent != null)
                {
                    lock (this)
                    {
                        this.wordCount++;
                    }
                }
            }
        }

        public int GetCount(string word, int index = 0)
        {
            if (index < word.Length)
            {
                char key = word[index];
                if (!this.children.ContainsKey(key))
                {
                    return -1;
                }

                return this.children[key].GetCount(word, index + 1);
            }
            else
            {
                return this.wordCount;
            }
        }

        public void GetTopCounts(ref List<TrieNode> mostCounted, ref int distinctWordCount, ref int totalWordCount)
        {
            if (this.wordCount > 0)
            {
                distinctWordCount++;
                totalWordCount += this.wordCount;
            }

            if (this.wordCount > mostCounted[0].wordCount)
            {
                mostCounted[0] = this;
                mostCounted.Sort();
            }

            foreach (char key in this.children.Keys)
            {
                this.children[key].GetTopCounts(ref mostCounted, ref distinctWordCount, ref totalWordCount);
            }
        }

        public override string ToString()
        {
            if (this.parent == null)
            {
                return string.Empty;
            }
            else
            {
                return this.parent.ToString() + this.letter;
            }
        }

        public int CompareTo(TrieNode other)
        {
            return this.wordCount.CompareTo(other.wordCount);
        }
    }
}