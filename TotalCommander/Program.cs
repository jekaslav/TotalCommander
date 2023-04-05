namespace TotalCommander
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                var managerUi = new ManagerUi();
                managerUi.Start();
            }
        }
    }
}