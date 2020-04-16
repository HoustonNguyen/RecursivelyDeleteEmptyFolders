using System;
using System.IO;

/// <summary>
/// This will look through each subdirectory, in a given directory, and delete any empty folder. It leaves files alone.
/// </summary>
namespace RecursivelyDeleteEmptyFolders
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = null;
            Console.WriteLine("Directory>");
            path = Console.ReadLine();

            if(string.IsNullOrEmpty(path))
            {
                Console.WriteLine("Invalid directory.");
                return;
            }
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Invalid directory.");
                return;
            }

            Console.WriteLine("Beginning Deletion...");

            checkFolder(path);

            Console.WriteLine("Deletion Complete...");
        }

        static void checkFolder(string folder)
        {
            DirectoryInfo directory = new DirectoryInfo(folder);
            DirectoryInfo[] subDirectories = directory.GetDirectories();
            FileInfo[] files = directory.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            if(subDirectories.Length == 0 && files.Length == 0)
            {
                Directory.Delete(folder);
                Console.WriteLine(folder + " Deleted.");
            }
            else if(subDirectories.Length > 0)
            {
                foreach(DirectoryInfo subDirectory in subDirectories)
                {
                    checkFolder(subDirectory.FullName);
                }
            }
        }
    }
}
