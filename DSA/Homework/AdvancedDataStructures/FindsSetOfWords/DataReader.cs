namespace FindsSetOfWords
{
    using System.IO;

    public class DataReader
    {
        private TrieNode root;
        private string path;

        public DataReader(string path, ref TrieNode root)
        {
            this.root = root;
            this.path = path;
        }

        public void ThreadRun()
        {
            using (var stream = new FileStream(this.path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(stream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] chunks = line.Split(null);

                        foreach (string chunk in chunks)
                        {
                            this.root.AddWord(chunk.Trim());
                        }
                    }
                }
            }
        }
    }
}