namespace TotalCommander;

public class FileManager
{
    
    public void CreateDir(string[] args)
    {
        var newDir = string.Join("", args);
        
        if (string.IsNullOrWhiteSpace(newDir) || Path.GetInvalidFileNameChars()
                .Any(c => newDir.Contains(c)))
        {
            throw new ArgumentException("Incorrect name");
        }
        
        GetPath();
        
        Directory.CreateDirectory(newDir);
        Console.SetCursorPosition(3, 44);
        Console.WriteLine($"Directory {newDir} is created.");
        Console.SetCursorPosition(3, 45);
    }

    public void RemoveDir(string[] args)
    {
        var rmNameDir = string.Join("", args);
        
        if (string.IsNullOrWhiteSpace(rmNameDir) || Path.GetInvalidFileNameChars()
                .Any(c => rmNameDir.Contains(c)))
        {
            throw new ArgumentException("Incorrect name");
        }
        
        GetPath();
        
        if (Directory.Exists(rmNameDir))
        {
            Directory.Delete(rmNameDir);
        }
        
        
        else
        {
            throw new ArgumentException("Directory is not found");
        }
        
        Console.SetCursorPosition(3, 44);
        Console.WriteLine($"Directory {rmNameDir} is removed.");
        Console.SetCursorPosition(3, 45);
    }

    public void RemoveFile(string[] args)
    {
        var rmNameFile = string.Join("", args);
        
        if (string.IsNullOrWhiteSpace(rmNameFile) || Path.GetInvalidFileNameChars()
                .Any(c => rmNameFile.Contains(c)))
        {
            throw new ArgumentException("Incorrect name");
        }
        
        GetPath();
        
        if (File.Exists(rmNameFile))
        {
            File.Delete(rmNameFile);
        }
        else
        {
            Console.SetCursorPosition(3, 44);
            Console.WriteLine("File is not found");
            Console.SetCursorPosition(0, 44);
            Thread.Sleep(3000);
            Console.Write("║ ".PadRight(75, ' ') + "║");
        }
        
        Console.SetCursorPosition(3, 44);
        Console.WriteLine($"File {rmNameFile} is removed.");
        Console.SetCursorPosition(3, 45);
    }
    
    public void CopyFile(string copyName, string trgName)
    {
        
        if (string.IsNullOrWhiteSpace(copyName) || Path.GetInvalidPathChars()
                .Any(c => copyName.Contains(c)))
        {
            throw new ArgumentException("Incorrect name");
        }
        
        if (string.IsNullOrWhiteSpace(trgName) || Path.GetInvalidPathChars()
                .Any(c => copyName.Contains(c)))
        {
            throw new ArgumentException("Incorrect target path name");
        }
    
        if (File.Exists(copyName) || Directory.Exists(trgName))
        {
            File.Copy( GetPath() + copyName,  "C:\\" + trgName + "\\" + Path.GetFileName(copyName));
        }
        else
        {
            throw new ArgumentException("File is not found");
        }
        
        Console.SetCursorPosition(1, 44);
        Console.WriteLine($"File {copyName} is copied");
        Console.SetCursorPosition(3, 45);
    }

    public void CopyDir(string sPath, string tPath)
    {

        if (string.IsNullOrWhiteSpace(sPath) || Path.GetInvalidPathChars()
                .Any(sPath.Contains))
        {
            throw new ArgumentException("Incorrect name");
        }

        if (string.IsNullOrWhiteSpace(tPath) || Path.GetInvalidPathChars()
                .Any(tPath.Contains))
        {
            throw new ArgumentException("Incorrect target path name");
        }

        var sDir = new DirectoryInfo(GetPath() + sPath);
        var tDir = new DirectoryInfo("C:\\" + tPath + "\\" + Path.GetFileName(sPath));

        if (tDir.Exists)
        {
            tDir.Create();
        }

        foreach (var file in sDir.GetFiles())
        {
            file.CopyTo(Path.Combine(tDir.FullName, file.Name), true);
        }

        foreach (var subDir in sDir.GetDirectories())
        {
            var targetSubDir = tDir.CreateSubdirectory(subDir.Name);    
            CopyFolderRecursive(subDir, targetSubDir);
        }
        
        Console.SetCursorPosition(1, 44);
        Console.WriteLine($"File {sPath} is copied");
        Console.SetCursorPosition(3, 45);
    }

    public void MoveFile(string fName, string tPath)
    {
        if (string.IsNullOrWhiteSpace(fName) || Path.GetInvalidFileNameChars()
                .Any(c => fName.Contains(c)))
        {
            throw new ArgumentException("Incorrect name");
        }

        if (string.IsNullOrWhiteSpace(tPath) || Path.GetInvalidPathChars()
                .Any(tPath.Contains))
        {
            throw new ArgumentException("Incorrect target path name");
        }

        if (File.Exists(fName))
        {
            File.Move(fName, "C:\\" + tPath + "\\" + Path.GetFileName(fName), true);
        }
        else
        {
            throw new ArgumentException("File is not found");
        }
        
        Console.SetCursorPosition(1, 44);
        Console.WriteLine($"File {fName} is moved");
        Console.SetCursorPosition(3, 45);
    }

    public void MoveDir(string dName, string tPath)
    {
        if (string.IsNullOrWhiteSpace(dName) || Path.GetInvalidFileNameChars()
                .Any(c => dName.Contains(c)))
        {
            throw new ArgumentException("Incorrect name");
        }
        
        if (string.IsNullOrWhiteSpace(tPath) || Path.GetInvalidPathChars()
                .Any(tPath.Contains))
        {
            throw new ArgumentException("Incorrect target path name");
        }

        if (Directory.Exists(dName))
        {
            Directory.Move(GetPath() + dName, "C:\\" + tPath + "\\" + Path.GetFileName(dName));
        }
        else
        {
            throw new ArgumentException("Directory is not found");
        }
        
        var sDir = new DirectoryInfo(GetPath() + dName);
        var tDir = new DirectoryInfo("C:\\" + tPath + "\\" + Path.GetFileName(tPath));
        
        foreach (var subDir in sDir.GetDirectories())
        {
            var targetSubDir = tDir.CreateSubdirectory(subDir.Name);
            CopyFolderRecursive(subDir, targetSubDir);
        }
        
        Console.SetCursorPosition(1, 44);
        Console.WriteLine($"Directory {dName} is moved");
        Console.SetCursorPosition(3, 45);
    }
    
    public void FileViewInfo(string[] args)
    {
        var fileName = string.Join("", args);
        var fileInfo = new FileInfo(fileName);
        
        if (fileInfo.Exists)
        {
            Console.SetCursorPosition(2, 41);
            Console.WriteLine("Size:" + fileInfo.Length + "bytes");
            Console.SetCursorPosition(2, 42);
            Console.WriteLine("Created:" + fileInfo.CreationTime);
            Console.SetCursorPosition(2, 43);
            Console.WriteLine("Last mod:" + fileInfo.LastWriteTime);
        }
        else
        {
            throw new ArgumentException("Incorrect name of the file");
        }
        Console.SetCursorPosition(3, 45);
    }
    private static void CopyFolderRecursive(DirectoryInfo source, DirectoryInfo target)
    {
        // Copy all files
        foreach (var file in source.GetFiles())
        {
            file.CopyTo(Path.Combine(target.FullName, file.Name), true);
        }

        // Copy all subfolders
        foreach (var subfolder in source.GetDirectories())
        {
            var targetSubfolder = target.CreateSubdirectory(subfolder.Name);
            CopyFolderRecursive(subfolder, targetSubfolder);
        }
    }
    
    private string GetPath()
    {
        var currPath = Directory.GetCurrentDirectory() + "\\";
        return currPath;
    }
}