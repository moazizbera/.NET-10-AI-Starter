namespace DotNet10Ai.ConsoleApp;

public static class ConsoleUi
{
    public static void PrintBanner()
    {
        Console.WriteLine("────────────────────────────────────────");
        Console.WriteLine(" DotNet AI Chat");
        Console.WriteLine(" Local • Ollama • Phi-3");
        Console.WriteLine(" Type /help for commands");
        Console.WriteLine("────────────────────────────────────────\n");
    }

    public static void PrintUserPrompt()
    {
        Console.Write("You > ");
    }

    public static void PrintAiPrefix()
    {
        Console.Write("AI  > ");
    }

    public static void PrintSystem(string message)
    {
        Console.WriteLine($"[system] {message}\n");
    }

    public static void PrintInfo(string message)
    {
        Console.WriteLine($"{message}\n");
    }
}
