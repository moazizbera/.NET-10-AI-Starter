using DotNet10Ai.ConsoleApp;
using DotNet10Ai.ConsoleApp.Memory;

var memory = new ConversationMemory();
var client = new OllamaChatClient("http://localhost:11434");

System.Console.WriteLine("DotNet AI Chat");
System.Console.WriteLine("Local • Ollama • Phi-3");
System.Console.WriteLine("Commands: /help, /reset, /exit");
System.Console.WriteLine();

while (true)
{
    System.Console.Write("You > ");
    var input = System.Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
        continue;

    if (input.Equals("/exit", StringComparison.OrdinalIgnoreCase))
        break;

    if (input.Equals("/help", StringComparison.OrdinalIgnoreCase))
    {
        System.Console.WriteLine("/help  - show commands");
        System.Console.WriteLine("/reset - clear memory");
        System.Console.WriteLine("/exit  - quit");
        continue;
    }

    if (input.Equals("/reset", StringComparison.OrdinalIgnoreCase))
    {
        memory.Reset();
        System.Console.WriteLine("🧹 Conversation cleared.");
        continue;
    }

    memory.AddUser(input);

    var reply = await client.StreamChatAsync(memory.Messages);

    memory.AddAssistant(reply);
}
