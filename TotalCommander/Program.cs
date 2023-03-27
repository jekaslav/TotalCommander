namespace TotalCommander
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var filesDirectory = new FilesDirectory();
            var fileManager = new FileManager();

            while (true)
            {
                Console.WriteLine("Enter a command:");
                var command = Console.ReadLine();
                
                if (String.IsNullOrWhiteSpace(command))
                {
                    throw new Exception("Incorrect");
                }
                
                switch (command)
                {
                    case "dir":
                        filesDirectory.ViewDirectory();
                        break; 
                    case "cd":
                        filesDirectory.GoToOtherDirectory();
                        break;
                    case "mkdir":
                       fileManager.CreateDir();
                       break;
                    case "rmdir":
                        fileManager.RemoveDir();
                        break;
                    case "rmfile":
                        fileManager.RemoveFile();
                        break;
                    case "copydir":
                        fileManager.CopyDir();
                        break;
                    case "copyfile":
                        fileManager.CopyFile();
                        break;
                    case "movefile":
                        fileManager.MoveFile();
                        break;
                    case "movedir":
                        fileManager.MoveDir();
                        break;
                    case "info":
                        filesDirectory.FileViewInfo();
                        break;
                    case "help": 
                        filesDirectory.Help();
                        break;
                    case "exit":
                    case "q":
                        return;
                    default:
                        Console.WriteLine("Wrong command. Enter -help-");
                        break;
                }
            } // ForegroundColor = ConsoleColor.Red;
        }
    }
}