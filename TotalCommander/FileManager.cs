namespace TotalCommander;

public class FileManager
{
    public void CreateDir()
    {
        Console.WriteLine("Enter a directory name:");
        var newDir = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(newDir) || Path.GetInvalidFileNameChars()
                .Any(c => newDir.Contains(c)))
        {
            throw new Exception("Incorrect");
        }
        
        GetPath();
        
        Directory.CreateDirectory(newDir);

        Console.WriteLine($"Directory {newDir} is created.");
    }

    public void RemoveDir()
    {
        Console.WriteLine("Enter a directory name:");
        var rmNameDir = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(rmNameDir) || Path.GetInvalidFileNameChars()
                .Any(c => rmNameDir.Contains(c)))
        {
            throw new Exception("Incorrect");
        }
        
        GetPath();
        
        if (Directory.Exists(rmNameDir))
        {
            Directory.Delete(rmNameDir);
        }
        else
        {
            throw new Exception("error");
        }

        Console.WriteLine($"Directory {rmNameDir} is removed.");
    }

    public void RemoveFile()
    {
        Console.WriteLine("Enter a file name:");
        var rmNameFile = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(rmNameFile) || Path.GetInvalidFileNameChars()
                .Any(c => rmNameFile.Contains(c)))
        {
            throw new Exception("Incorrect");
        }
        
        GetPath();
        
        if (File.Exists(rmNameFile))
        {
            File.Delete(rmNameFile);
        }
        else
        {
            throw new Exception("where is the file?");
        }

        Console.WriteLine($"File {rmNameFile} is removed.");
    }
    
    public void CopyFile()
    {
        Console.WriteLine("Enter a file name in current directory:");
        var copyName = Console.ReadLine();
    
        if (string.IsNullOrWhiteSpace(copyName) || Path.GetInvalidPathChars()
                .Any(c => copyName.Contains(c)))
        {
            throw new Exception("Incorrect path to the file.");
        }
        
        Console.WriteLine("Enter a target name in the new directory for the file:");
        var trgName = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(trgName) || Path.GetInvalidPathChars()
                .Any(c => copyName.Contains(c)))
        {
            throw new Exception("Incorrect path to the file.");
        }
    
        if (File.Exists(copyName) || Directory.Exists(trgName))
        {
            File.Copy( GetPath() + copyName,  "C:\\" + trgName + "\\" + Path.GetFileName(copyName));
        }
        else
        {
            throw new Exception("where is the file?");
        }
    
        Console.WriteLine($"File {copyName} is copied");
    }

    public void CopyDir()
    {
        Console.WriteLine("enter source dir:");
        var sPath = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(sPath) || Path.GetInvalidPathChars()
                .Any(c => sPath.Contains(c)))
        {
            throw new Exception("Incorrect path.");
        }

        Console.WriteLine("enter target dir:");
        var tPath = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(tPath) || Path.GetInvalidPathChars()
                .Any(c => tPath.Contains(c)))
        {
            throw new Exception("Incorrect path.");
        }

        var sDir = new DirectoryInfo(GetPath() + sPath); // нужно создавать так экземпляры класса или обращаться напрямую, когда используем в циклах?
        var tDir = new DirectoryInfo("C:\\" + tPath + "\\" + Path.GetFileName(sPath));

        if (tDir.Exists)
        {
            tDir.Create();
        }

        foreach (var file in sDir.GetFiles())
        {
            file.CopyTo(Path.Combine(tDir.FullName, file.Name), true);
        }

        foreach (var subDir in sDir.GetDirectories())                // подпапки
        {
            var targetSubDir = tDir.CreateSubdirectory(subDir.Name);    
            CopyFolderRecursive(subDir, targetSubDir);
        }
        
        Console.WriteLine($"File {sPath} is copied");
    }

    public void MoveFile()
    {
        Console.WriteLine("enter a file name:");
        var fName = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(fName) || Path.GetInvalidFileNameChars()
                .Any(c => fName.Contains(c)))
        {
            throw new Exception("Incorrect");
        }
        
        Console.WriteLine("enter a target path:");
        var tPath = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(tPath) || Path.GetInvalidPathChars()
                .Any(c => tPath.Contains(c)))
        {
            throw new Exception("Incorrect path to the file.");
        }

        if (File.Exists(fName))
        {
            File.Move(fName, "C:\\" + tPath + "\\" + Path.GetFileName(fName), true);
        }
        else
        {
            throw new FileNotFoundException("where is the file");
        }
    }

    public void MoveDir()
    {
        Console.WriteLine("Enter the directory name:");
        var dName = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(dName) || Path.GetInvalidFileNameChars()
                .Any(c => dName.Contains(c)))
        {
            throw new Exception("Incorrect");
        }
        
        Console.WriteLine("Enter a target path for the directory:");
        var tPath = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(tPath) || Path.GetInvalidPathChars()
                .Any(c => tPath.Contains(c)))
        {
            throw new Exception("Incorrect path.");
        }

        if (Directory.Exists(dName))
        {
            Directory.Move(GetPath() + dName, "C:\\" + tPath + "\\" + Path.GetFileName(dName));
        }
        else
        {
            throw new DirectoryNotFoundException("where is the directory");
        }
        
        var sDir = new DirectoryInfo(GetPath() + dName);
        var tDir = new DirectoryInfo("C:\\" + tPath + "\\" + Path.GetFileName(tPath));
        
        foreach (var subDir in sDir.GetDirectories())
        {
            var targetSubDir = tDir.CreateSubdirectory(subDir.Name);
            CopyFolderRecursive(subDir, targetSubDir);
        }
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