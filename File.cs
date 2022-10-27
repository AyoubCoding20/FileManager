using System;

namespace FileManager
{
    public class File
    {
        public File()
        {
            System.Console.WriteLine("FileManager launched !");
        }
        public void Create(System.string filepath)
        {
            try
            {
                System.IO.File.Create(filepath).Close();
            }
            catch (System.UnauthorizedAccessException e1)
            {
                System.Console.WriteLine("UnauthorizedAccessException : Permission denied or folder is read-only " + e1.Message);
            }
            catch (System.IO.IOException e2)
            {
                System.Console.WriteLine("IOExecption : I/O error " + e2.Message);
            }
        }
        public void ReadAllTextInFile(string filepath)
        {
            try
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(filepath))
                {
                    System.String text;
                    while ((text = sr.ReadLine()) != null)
                    {
                        System.Console.WriteLine("Readed text : -> " + text);
                    }
                }
            }
            catch (System.IO.FileNotFoundException e6)
            {
                System.Console.WriteLine(e6.Message);
                System.Console.WriteLine("Would you want to create the file ? (y/n) ");
                string s = Console.ReadLine();
                if (s == "y")
                    this.Create(filepath);
                else if (s == "n")
                    return;
            }
            catch (System.IO.PathTooLongException e8)
            {
                System.Console.WriteLine(e8.Message);
            }
            catch (System.IO.IOException io2)
            {
                System.Console.WriteLine(io2.Message);
            }
        }
        public void WriteText(string filepath)
        {
            try
            {
                Console.WriteLine("Text to write : ");
                System.String writetext = System.Console.ReadLine();
                using(System.IO.StreamWriter sw = new System.IO.StreamWriter(filepath))
                {
                    sw.WriteLine(writetext);
                }
            }
            catch (System.IO.FileNotFoundException e52)
            {
                System.Console.WriteLine(e52.Message);
                System.Console.WriteLine("You want to create the file ? (y/n)");
                string choice = System.Console.ReadLine();
                if (choice == "y")
                    this.Create(filepath);
                else if (choice == "n")
                    return;
            }
            catch (System.IO.IOException io)
            {
                System.Console.WriteLine(io.Message);
            }
        }
        public void CopyFile(System.string srcpath, string destpath)
        {
            try
            {
                System.IO.File.Copy(srcpath, destpath);
                System.Console.WriteLine("File copied to " + destpath);
            }
            catch (ArgumentNullException e9)
            {
                System.Console.WriteLine(e9.Message);
            }
            
        }
        public void MoveFile(System.string srcpath, string destpath)
        {
            try
            {
                System.IO.File.Move(srcpath, destpath);
                System.Console.WriteLine("File moved to " + destpath);
            }
            catch (ArgumentException e36)
            {
                System.Console.WriteLine(e36.Message);
            }
        }
        public void DeleteFile(string filepath)
        {
            try
            {
                System.IO.File.Delete(filepath);
            }
            catch (ArgumentNullException a)
            {
                System.Console.WriteLine(a.Message);
            }
            catch (System.IO.IOException i)
            {
                System.Console.WriteLine(i.Message);
            }
        }
        public bool FileExists(string filepath)   
        {
            return System.IO.File.Exists(filepath);
        }
    }
}
