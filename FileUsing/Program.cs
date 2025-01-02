
using Microsoft.VisualBasic.FileIO;
using System;
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
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                dirInfo.CreateSubdirectory("New Folder");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void RemoveDir(string dirName)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                if (dirInfo.Exists)
                {
                    dirInfo.Delete(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void MoveDir(string dirName, string newPath)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                if (dirInfo.Exists && !Directory.Exists(newPath))
                {
                    dirInfo.MoveTo(newPath);
                }
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }
        public static void CreateOnDesktop(string dirName)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\user\Desktop");
                if (!Directory.Exists(dirName))
                {
                    dirInfo.CreateSubdirectory("testFolder");
                }
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }
        public static void RemoveToBin(string dirName)
        {
            try
            {
                FileSystem.DeleteDirectory(dirName, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }
        public static void CreateFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine("Олег");
                    sw.WriteLine("Дмитрий");
                    sw.WriteLine("Иван");
                }
            }
        }
        public static void ReadFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader sr = File.OpenText(filePath))
                {
                    string str = "";
                    while ((str = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(str);
                    }
                }
            }
        }
        public static void ShowCSCode()
        {
            string filePath = @"I:\SH Proj\SK\CSharp-Exercise-8\FileUsing\Program.cs";
            if (File.Exists(filePath))
            {
                using (StreamReader sr = File.OpenText(filePath))
                {
                    string str = "";
                    while ((str = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(str);
                    }
                }
            }
        }
        public static void AddLastTimeToCode()
        {
            string filePath = @"I:\SH Proj\SK\CSharp-Exercise-8\FileUsing\Program.cs";
            if (File.Exists(filePath))
            {
                using (StreamWriter sr = File.AppendText(filePath))
                {
                    sr.WriteLine("//" + DateTime.Now);
                }
            }
        }
        public static void ReadFromBinaryCFX(string filePath)
        {
            if (File.Exists(filePath))
            {
                string str;
                using (BinaryReader binaryReader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    str = binaryReader.ReadString();
                    Console.Write("Data creation: " + str);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Directories count: " + GetDirectoriesCount("C:\\"));
            Console.WriteLine("Files count:       " + GetFilesCount("C:\\"));

            ReadFromBinaryCFX(@"C:\BinaryFile.bin");



        }
    }
}
