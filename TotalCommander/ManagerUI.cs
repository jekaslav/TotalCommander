namespace TotalCommander;

public class ManagerUi
{
    public void Start()
    {
        var drawing = new Drawing();
        var directoryManager = new DirectoryManager();
        var fileManager = new FileManager();

        // var music = new Music();
        // music.MusicSong();

        Console.Clear();
        drawing.Draw();

        try
        {
            while (true)
            {
                Console.SetCursorPosition(0, 45);
                Console.Write("║ >".PadRight(75, ' ') + "║");
                Console.SetCursorPosition(3, 45);

                var input = Console.ReadLine();
                var parts = input?.Split(' ');
                var command = parts?[0];
                var args = parts.Skip(1).ToArray();

                switch (command)
                {
                    case "dir":
                        directoryManager.ViewDirectory(args);
                        break;
                    case "cd":
                        DirectoryManager.GoToOtherDirectory(args);
                        break;
                    case "mkdir":
                        fileManager.CreateDir(args);
                        break;
                    case "rmdir":
                        fileManager.RemoveDir(args);
                        break;
                    case "rmfile":
                        fileManager.RemoveFile(args);
                        break;
                    case "copydir":
                        fileManager.CopyDir(args[0], args[1]);
                        break;
                    case "copyfile":
                        fileManager.CopyFile(args[0], args[1]);
                        break;
                    case "movefile":
                        fileManager.MoveFile(args[0], args[1]);
                        break;
                    case "movedir":
                        fileManager.MoveDir(args[0], args[1]);
                        break;
                    case "info":
                        fileManager.FileViewInfo(args);
                        break;
                    case "exit":
                        return;
                    default:
                        Console.SetCursorPosition(3, 44);
                        Console.WriteLine("Unknown command");
                        Thread.Sleep(3000);
                        Console.Write("║ ".PadRight(75, ' ') + "║");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.SetCursorPosition(3, 44);
            Console.WriteLine($"Error: {ex.Message}");
            Console.SetCursorPosition(0, 44);
            Thread.Sleep(3000);
            Console.Write("║ ".PadRight(75, ' ') + "║");
            Console.SetCursorPosition(3, 45);
        }
    }

    public void Help()
    {

        string[] commands =
        {
            "1. dir - вывод списка файлов и папок в текущей директории",
            "2. cd  - <папка> переход в указанную директорию",
            "3. mkdir - <имя> создание новой папки с указанным именем",
            "4. rmdir - <имя> удаление папки с указанным именем",
            "5. rmfile - <имя>удаление файла с указанным именем",
            "6. copydir - <имя папки> <имя конечного пути> копирование папки",
            "7. copyfile - <имя файла> <имя конечного пути> копирование файла",
            "8. movefile - <имя файла> <имя конечного пути> перемещение файла",
            "9. movedir - <имя папки> <имя конечного пути> перемещение папки",
            "10. info - <имя> получение информации о файле",
        };


        foreach (string command in commands)
        {
            Console.WriteLine("║ " + command.PadRight(73, ' ') + "║");
        }
    }
}
    
