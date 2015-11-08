namespace HashTableTests
{
    using System;
    using HashTable;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HasTableTests
    {
        [TestMethod]
        public void AddMethodShouldReturnCorrectResults()
        {
            var hashtable = new HashTable<int, string>();

            for (int i = 0; i < 17; i++)
            {
                hashtable.Add(i, i.ToString());
            }

            Assert.AreEqual(17, hashtable.Count);
            Assert.AreEqual(32, hashtable.Capacity);
            Assert.AreEqual(17, hashtable.Keys.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddMethodShouldThrowWhenAddDoublicateKey()
        {
            var hashtable = new HashTable<int, int>();
            hashtable.Add(1, 1);
            hashtable.Add(1, 6);
        }

        [TestMethod]
        public void RemoveMethodShouldReturnCorrectResults()
        {
            var hashtable = new HashTable<int, int>();

            for (int i = 0; i < 20; i++)
            {
                hashtable.Add(i, i + 10);
            }

            for (int i = 10; i < 20; i++)
            {
                hashtable.Remove(i);
            }

            Assert.AreEqual(10, hashtable.Count);
            Assert.AreEqual("0 1 2 3 4 5 6 7 8 9", string.Join(" ", hashtable.Keys));
        }

        [TestMethod]
        public void FindMathodShouldReturnCorrectResults()
        {
            var hashtable = new HashTable<string, string>();

            for (int i = 0; i < 50; i++)
            {
                hashtable.Add("Key" + i, "Value" + i);
            }

            Assert.IsTrue(hashtable.Find("Key0"));
            Assert.IsTrue(hashtable.Find("Key10"));
            Assert.IsTrue(hashtable.Find("Key49"));
            Assert.IsFalse(hashtable.Find("Key50"));
            Assert.IsFalse(hashtable.Find("Key"));
        }

        [TestMethod]
        public void ClearMethodShouldReturnCorrectResult()
        {
            var hashTable = new HashTable<int, int>();

            for (int i = 0; i < 1000; i++)
            {
                hashTable.Add(i, i);
            }

            hashTable.Clear();
            Assert.AreEqual(0, hashTable.Count);
        }

        [TestMethod]
        public void IndexerToReturnCorrectResult()
        {
            var hashTable = new HashTable<int, int>();

            for (int i = 0; i < 50; i++)
            {
                hashTable.Add(i, i);
            }

            Assert.AreEqual(5, hashTable[5]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexerToThrowWhenInvalidIndex()
        {
            var hashTable = new HashTable<int, int>();

            for (int i = 0; i < 50; i++)
            {
                hashTable.Add(i, i);
            }

            Console.WriteLine(hashTable[55]);
        }
    }
}