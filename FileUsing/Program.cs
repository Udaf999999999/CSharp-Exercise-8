namespace FileUsing;

internal class Program
{
    public class Folder
    {
        public List<string> Files { get; set; } = new List<string>();
        Dictionary<string, Folder> Folders = new Dictionary<string, Folder>();
        public void AddFolder(string folderName)
        {
            Folders.Add(folderName, new Folder());
        }
    }
    public class Drive
    {
        public string Name { get; }
        public long Space { get; }
        public long FreeSpace { get; }

        public Drive(string name, long space, long freeSpace)
        {
            Name = name;
            Space = space;
            FreeSpace = freeSpace;
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
