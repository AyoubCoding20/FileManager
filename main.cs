using System;
using FileManager;

namespace FileManager
{
    public class main
    {
        public static void Main(string []args)
        {
            FileManager.File f = new FileManager.File("./lop.txt");
            f.Create();
            f.WriteText();
            f.ReadAllTextInFile();
            FileManager.Directory d = new FileManager.Directory("/data");
            d.CreateDirectory();
            System.Console.WriteLine("Dir exists ? " + d.DirExists());
            f.CopyFile("./data/");
            d.CopyDirectory("./moved/");
            f.CopyFile("./moved/lop.txt");
            FileManager.Directory d1 = new FileManager.Directory("./moved");
            d1.GetFiles();
            d1.DeleteDirectory();
            f.DeleteFile();
            d.DeleteDirectory();
        }
    }
}
