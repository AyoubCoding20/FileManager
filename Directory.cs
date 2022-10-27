namespace FileManager
{
    public class Directory
    {
        public Directory()
        {
            System.Console.WriteLine("DirectoryManager launched !");
        }
        public void CreateDirectory(string dirpath)
        {
            try
            {
                System.IO.Directory.CreateDirectory(dirpath);
            }
            catch (Exception e1)
            {
                System.Console.WriteLine(e1.Message);
            }
        }
        public void DeleteDirectory(string dirpath)
        {
            try
            {
                System.IO.Directory.Delete(dirpath, true);
            }
            catch (Exception e2)
            {
                System.Console.WriteLine(e2.Message);
            }
        }
        public void GetFiles(string dirpath)
        {
            System.String[] files = System.IO.Directory.GetFiles(dirpath);
            foreach (System.String file in files)
            {
                System.Console.WriteLine($"Files in {dirpath} : {file}");
            }
        }
        public bool DirExists(string dirpath)
        {
            return System.IO.Directory.Exists(dirpath);
        }
        public void MoveDir(string srcpath, string destinpath)
        {
            System.IO.Directory.Move(srcpath, destinpath);
            System.Console.WriteLine("Directory moved !");
        }
        public void CopyDirectory(string srcpath, string destFolder)
        {
            if (!System.IO.Directory.Exists(destFolder))
                System.IO.Directory.CreateDirectory(destFolder);
            string[] files = System.IO.Directory.GetFiles(srcpath);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                System.IO.File.Copy(file, dest);
            }
            string[] folders = System.IO.Directory.GetDirectories(srcpath);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyDirectory(destFolder);
            }
        }
    }
}
