namespace TotalCommander;

public class FilesDirectory
{
    private const string PathToDocuments = "C:\\";
    public void ViewDirectory()
    {
        var files = Directory.GetFiles(PathToDocuments);
        var directories = Directory.GetDirectories(PathToDocuments);

        Console.WriteLine("Files:");
        foreach (var file in files)
        {
            Console.WriteLine(file);
        }

        Console.WriteLine("\nDirectories:");
        foreach (var directory in directories)
        {
            Console.WriteLine(directory);
        }
    }
    
    public void GoToOtherDirectory()
    {
        Console.WriteLine("Enter a directory path:");
        var path = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(path) || Path.GetInvalidPathChars()
                .Any(c => path.Contains(c)))
        {
            throw new Exception("Incorrect path.");
        }

        if (Directory.Exists(PathToDocuments + path))
        {
            Directory.SetCurrentDirectory(PathToDocuments + path);
            Console.WriteLine($"Current directory is now {PathToDocuments + path}");
            
            var files = Directory.GetFiles(PathToDocuments + path);
            var directories = Directory.GetDirectories(PathToDocuments + path);

            Console.WriteLine("Files:");
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }

            Console.WriteLine("\nDirectories:");
            foreach (var directory in directories)
            {
                Console.WriteLine(directory);
            }
        }
        else
        {
            Console.WriteLine("Directory does not exist");
        }
    }
    
    public void FileViewInfo()
    {
        Console.WriteLine("enter name");
        var fileName = Console.ReadLine();
        var fileInfo = new FileInfo(fileName!); // нужно создавать так экземпляры класса или обращаться напрямую, когда используем в циклах?
        if (fileInfo.Exists)
        {
            Console.WriteLine("File name:" + fileInfo.Name);
            Console.WriteLine("Size:" + fileInfo.Length + "bytes");
            Console.WriteLine("Created:" + fileInfo.CreationTime);
            Console.WriteLine("Last modified:" + fileInfo.LastWriteTime);
            Console.WriteLine();
        }
    }
    
    public void Help()
    {
        Console.WriteLine
        (@"
        1. dir - вывод списка файлов и папок в текущей директории
        2. cd  - переход в указанную директорию
        3. mkdir - создание новой папки с указанным именем
        4. rmdir - удаление папки с указанным именем
        5. rmfile - удаление файла с указанным именем
        6. copydir - копирование папки из одного места в другое
        7. copyfile - копирование файла из одного места в другое
        8. movefile - перемещение файла из одного места в другое
        9. movedir - перемещение папки из одного места в другое
        10. info - получение информации о файле
        11. help - вывод списка доступных команд и их описания
        12. exit q - выход из программы");
        
    }
}
