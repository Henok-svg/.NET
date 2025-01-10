class Program
{
    public static void Main()
    {
        var stopwatch = new StopWatch();


        stopwatch.OnStarted += (message) => DisplayMessage(message);
        stopwatch.OnStopped += (message) => DisplayMessage(message);
        stopwatch.OnReset += (message) => DisplayMessage(message);
        stopwatch.OnTimeUpdated += (time) => DisplayTime(time);

        while (true)
        {
            DisplayMenu();
            string? input = Console.ReadLine()?.ToUpper();

            switch (input)
            {
                case "B":
                    stopwatch.Begin();
                    break;
                case "S":
                    stopwatch.Stop();
                    DisplayMessage("Press enter to continue...");
                    Console.ReadLine();
                    break;
                case "R":
                    stopwatch.Reset();
                    DisplayMessage("Press enter to continue...");
                    Console.ReadLine();
                    break;
                case "Q":
                    Console.WriteLine("Exiting StopWatch. Goodbye!");
                    return;
                default:
                    DisplayMessage("Invalid Input. Please try again.");
                    break;
            }
        }
    }

    private static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("=== StopWatch Application ===");
        Console.WriteLine("S: Start");
        Console.WriteLine("T: Stop");
        Console.WriteLine("R: Reset");
        Console.WriteLine("Q: Quit");
        Console.WriteLine("=============================");
        Console.Write("Your Choice: ");
    }

    private static void DisplayMessage(string message)
    {
        Console.WriteLine($"\n{message}\n");
    }

    private static void DisplayTime(TimeSpan time)
    {
        Console.Clear();
        Console.WriteLine("=== StopWatch Application ===");
        Console.WriteLine($"Elapsed Time: {time:mm\\:ss}");
        Console.WriteLine("=============================");
        Console.WriteLine("Press S to Stop, R to Reset, Q to Quit, or wait to continue...");
    }


}
