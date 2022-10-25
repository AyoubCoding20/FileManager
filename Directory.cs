namespace FileManager
{
    public class Directory
    {
        public string DirPath {get; set;}
        public Directory(string dirpath)
        {
            this.DirPath = dirpath;
        }
        public void CreateDirectory()
        {
            try
            {
                System.IO.Directory.CreateDirectory(this.DirPath);
            }
            catch (Exception e1)
            {
                System.Console.WriteLine(e1.Message);
            }
        }
        public void DeleteDirectory()
        {
            try
            {
                System.IO.Directory.Delete(this.DirPath, true);
            }
            catch (Exception e2)
            {
                System.Console.WriteLine(e2.Message);
            }
        }
        public void GetFiles()
        {
            System.String[] files = System.IO.Directory.GetFiles(this.DirPath);
            foreach (System.String file in files)
            {
                System.Console.WriteLine($"Files in {this.DirPath} : {file}");
            }
        }
        public bool DirExists()
        {
            if (System.IO.Directory.Exists(this.DirPath))
                return true;
            else
                return false;
        }
        public void MoveDir(string destinpath)
        {
            System.IO.Directory.Move(this.DirPath, destinpath);
            System.Console.WriteLine("Directory moved !");
        }
        public void CopyDirectory(string destFolder)
        {
            if (!System.IO.Directory.Exists(destFolder))
                System.IO.Directory.CreateDirectory(destFolder);
            string[] files = System.IO.Directory.GetFiles(this.DirPath);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                System.IO.File.Copy(file, dest);
            }
            string[] folders = System.IO.Directory.GetDirectories(this.DirPath);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyDirectory(destFolder);
            }
        }
    }
}