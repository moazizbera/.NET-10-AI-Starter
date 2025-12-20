namespace DotNet10Ai.ConsoleApp;

public static class ConsoleUi
{
    public static void PrintBanner()
    {
        System.Console.WriteLine("────────────────────────────────────────");
        System.Console.WriteLine(" DotNet AI Chat");
        System.Console.WriteLine(" Local • Ollama • Phi-3");
        System.Console.WriteLine(" Type /help for commands");
        System.Console.WriteLine("────────────────────────────────────────\n");
    }

    public static void PrintUserPrompt()
    {
        System.Console.Write("You > ");
    }

    public static void PrintAiPrefix()
    {
        System.Console.Write("AI  > ");
    }

    public static void PrintSystem(string message)
    {
        System.Console.WriteLine($"[system] {message}\n");
    }

    public static void PrintInfo(string message)
    {
        System.Console.WriteLine($"{message}\n");
    }
}
