using System.Collections.Generic;
using System.Text;
namespace TraverseDirectoryDefineClasses
{
    public class Folder
    {
        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }

        public string Name { get; set; }

        public List<File> Files { get; set; }

        public List<Folder> ChildFolders { get; set; }

        public override string ToString()
        {
            // var builder = new StringBuilder();
            // builder.AppendLine("Folder: " + this.Name);
            // 
            // var childFolders = ChildFolders.Count == 0 ? "No ChildFolders" : string.Join(", ", this.ChildFolders);
            // builder.AppendLine("    ChildFolders: " + childFolders);
            // 
            // var files = this.Files.Count == 0 ? "No Files" : string.Join(", ", this.Files);
            // builder.Append("    Files: " + files);

            return this.Name; //builder.ToString();
        }
    }
}
