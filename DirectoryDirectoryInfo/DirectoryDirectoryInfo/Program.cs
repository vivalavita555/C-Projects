using System;
using System.IO;

namespace DirectoryDirectoryInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory(@"c:\temp\folder1");

            //var files = Directory.GetFiles(@"c:\projects\CSharpFundamentals", "*.sln", SearchOption.AllDirectories);
            //foreach (var file in files) 
            //{
            //  Console.WriteLine(file);

            var directories = Directory.GetDirectories(@"c:\projects\CSharpFundamentals", "*.*",
                SearchOption.AllDirectories);
            foreach (var directory in directories)
            {
                Console.WriteLine(directory);
            }
            Directory.Exists("...");

            var directoryInfo = new DirectoryInfo("...");
            directoryInfo.GetFiles();
            directoryInfo.GetDirectories();
        }
    }
}
