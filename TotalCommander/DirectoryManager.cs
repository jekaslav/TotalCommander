namespace TotalCommander;
public class DirectoryManager
{
    private const string PathToDocuments = "C:\\";

    public string ViewDirectory(string[] args)
    {
        var drawing = new Drawing();
        var pathDir = string.Join("", args);

        var files = Directory.GetFiles(PathToDocuments + pathDir);
        var directories = Directory.GetDirectories(PathToDocuments + pathDir);
        var items = files.Concat(directories).ToArray();
        var itemsSorted = items.OrderBy(i => i).ToArray();
        Console.SetCursorPosition(2, 3);
        Console.WriteLine("Files and directories:");

        var y = 2;
        var currentPage = 1;
        var totalPages = (int)Math.Ceiling((double)itemsSorted.Length / 20);

        while (true)
        {
            Console.Clear();
            drawing.Draw();
            Console.SetCursorPosition(63, 27);
            Console.WriteLine($"Page {currentPage} of {totalPages}");

            var startIndex = (currentPage - 1) * 20;
            var endIndex = Math.Min(startIndex + 20, itemsSorted.Length);

            for (var i = startIndex; i < endIndex; i++)
            {
                Console.SetCursorPosition(1, y);
                Console.WriteLine(itemsSorted[i]);
                y++;
            }
            Console.SetCursorPosition(3, 26);
            Console.WriteLine("PRESS ESC FOR NEXT CMD");
            Console.SetCursorPosition(3, 27);
            var keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.RightArrow && currentPage < totalPages)
            {
                currentPage++;
                y = 2;
            }
            else if (keyInfo.Key == ConsoleKey.LeftArrow && currentPage > 1)
            {
                currentPage--;
                y = 2;
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.SetCursorPosition(3, 45);
                break;
            }
        }
        return null!;
    }

    public static void GoToOtherDirectory(string[] args)
    {
        var drawing = new Drawing();
        var path = string.Join("", args);

        Console.Clear();
        drawing.Draw();
        
        if (Directory.Exists(PathToDocuments + path))
        {
            Directory.SetCurrentDirectory(PathToDocuments + path);
            Console.SetCursorPosition(1, 3);
            Console.WriteLine($"Current directory is now {PathToDocuments + path}");

            var files = Directory.GetFiles(PathToDocuments + path);
            var directories = Directory.GetDirectories(PathToDocuments + path);
            var items = files.Concat(directories).ToArray();
            var itemsSorted = items.OrderBy(i => i).ToArray();
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Files and directories:");

            var y = 2;
            var currentPage = 1;
            var totalPages = (int)Math.Ceiling((double)itemsSorted.Length / 20);

            while (true)
            {
                Console.Clear();
                drawing.Draw();
                Console.SetCursorPosition(63, 27);
                Console.WriteLine($"Page {currentPage} of {totalPages}");

                var startIndex = (currentPage - 1) * 20;
                var endIndex = Math.Min(startIndex + 20, itemsSorted.Length);
                
                for (var i = startIndex; i < endIndex; i++)
                {
                    Console.SetCursorPosition(1, y);
                    Console.WriteLine(itemsSorted[i]);
                    y++;
                }
                
                Console.SetCursorPosition(3, 26);
                Console.WriteLine("PRESS ESC FOR NEXT CMD");
                Console.SetCursorPosition(3, 27);
                var keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.RightArrow && currentPage < totalPages)
                {
                    currentPage++;
                    y = 2;
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow && currentPage > 1)
                {
                    currentPage--;
                    y = 2;
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.SetCursorPosition(3, 45);
                    break;
                }
            }
        }
        else
        {
            throw new ArgumentException("Directory is not exist");
        }
        Console.SetCursorPosition(3, 45);
    }
}
