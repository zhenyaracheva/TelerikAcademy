namespace TraverseDirectoryDefineClasses
{
    public class File
    {
        public File(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }

        string Name { get; set; }

        long Size { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
