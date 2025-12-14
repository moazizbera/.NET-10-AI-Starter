using DotNet10Ai.ConsoleApp;

// ─────────────────────────────────────────────
// App Banner
// ─────────────────────────────────────────────
ConsoleUi.PrintBanner();

// ─────────────────────────────────────────────
// Create chat session + system prompt
// ─────────────────────────────────────────────
var session = new ChatSession();
session.AddSystem(ChatSession.DefaultSystemPrompt);

// Optional: show system info once
ConsoleUi.PrintSystem("AI configured as senior software architect");

// ─────────────────────────────────────────────
// Create Ollama client
// ─────────────────────────────────────────────
var client = new OllamaChatClient("http://localhost:11434");

// ─────────────────────────────────────────────
// Main chat loop
// ─────────────────────────────────────────────
while (true)
{
    ConsoleUi.PrintUserPrompt();
    var input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
        continue;

    // Exit
    if (input.Equals("/exit", StringComparison.OrdinalIgnoreCase))
        break;

    // Clear conversation
    if (input.Equals("/clear", StringComparison.OrdinalIgnoreCase))
    {
        session.Clear();
        ConsoleUi.PrintInfo("Conversation cleared.");
        continue;
    }

    // Help
    if (input.Equals("/help", StringComparison.OrdinalIgnoreCase))
    {
        ConsoleUi.PrintInfo("""
Commands:
  /help   Show commands
  /clear  Clear conversation
  /exit   Exit chat
""");
        continue;
    }

    // Add user message
    session.AddUser(input);

    // Stream AI response
    ConsoleUi.PrintAiPrefix();
    Console.CursorVisible = false;

    var reply = await client.StreamChatAsync(session.Messages);

    Console.CursorVisible = true;
    Console.WriteLine();

    session.AddAssistant(reply);
}

// ─────────────────────────────────────────────
// Exit
// ─────────────────────────────────────────────
Console.WriteLine("\nGoodbye 👋");
