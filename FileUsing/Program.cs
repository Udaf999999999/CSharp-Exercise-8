

using System.Management;

namespace FileUsing
{

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
        static void GetCatalogs()
        {
            string dirName = @"C:\\"; // Прописываем путь к корневой директории MacOS (для Windows скорее всего тут будет "C:\\")
            if (Directory.Exists(dirName)) // Проверим, что директория существует
            {
                Console.WriteLine("Папки:");
                string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога

                foreach (string d in dirs) // Выведем их все
                    Console.WriteLine(d);

                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);// Получим все файлы корневого каталога

                foreach (string s in files)   // Выведем их все
                    Console.WriteLine(s);
            }
        }
        public static int GetDirectoriesCount(string dirName)
        {
            try
            {
                if (Directory.Exists(dirName))
                {
                    return Directory.GetDirectories(dirName).Length;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return 0;
        }
        public static int GetFilesCount(string dirName)
        {
            try
            {
                if (Directory.Exists(dirName))
                {
                    return Directory.GetFiles(dirName).Length;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return 0;
        }
        public static void CreateDir(string dirName)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirName);
            if(!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory("New Folder");dirInfo.
        }
        static void Main(string[] args)
        {
            CreateDir(@"C:\Serious Folder");
            GetCatalogs();
            Console.WriteLine("Directories count: " + GetDirectoriesCount("C:\\"));
            Console.WriteLine("Files count:       " + GetFilesCount("C:\\"));
        }
    }
}
