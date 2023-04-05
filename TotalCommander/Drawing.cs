namespace TotalCommander;

public class Drawing
{
    
    public void Draw()
    {   
        var managerUi = new ManagerUi();
        
        Console.SetWindowSize(79, 47);
        Console.SetBufferSize(160,400);
        
        // Зона вывода         
        Console.WriteLine("╔" + new string('═', 74) + "╗".PadRight(75, ' '));
        for (int i = 0; i < 26; i++)
        {
            Console.WriteLine("║" + new string(' ', 74) + "║".PadRight(78, ' '));
        }
        
        Console.WriteLine("║" + new string(' ', 74) + "║".PadRight(78, ' '));
        
        // Зона информации
        Console.WriteLine("╠" + new string('═', 28) + "information".PadRight(46, '═') + "╣".PadRight(8, ' '));
        managerUi.Help();
        
        // Зона командной строки
        Console.WriteLine("╠" + new string('═', 74) + "╣".PadRight(78, ' '));
        
        for (var i = 0; i < 5; i++)
        {
            Console.WriteLine("║" + new string(' ', 74) + "║".PadRight(78, ' '));
        }
        
        Console.Write("║ >".PadRight(75, ' ') + "║");

        Console.WriteLine();
        Console.WriteLine("╚" + new string('═', 74) + "╝".PadRight(78, ' '));
        Console.SetCursorPosition(3, 45);
    }
}